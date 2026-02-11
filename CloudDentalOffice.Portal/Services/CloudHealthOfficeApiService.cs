using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Client for CloudHealthOffice REST API
/// Sends claims as JSON payloads instead of X12 files
/// </summary>
public interface ICloudHealthOfficeApiService
{
    Task<CloudHealthOfficeResponse> SubmitClaimAsync(Claim claim, InsurancePlan payer);
    Task<bool> TestConnectionAsync(InsurancePlan payer);
}

public class CloudHealthOfficeApiService : ICloudHealthOfficeApiService
{
    private readonly CloudDentalDbContext _context;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<CloudHealthOfficeApiService> _logger;

    public CloudHealthOfficeApiService(
        CloudDentalDbContext context,
        IHttpClientFactory httpClientFactory,
        ILogger<CloudHealthOfficeApiService> logger)
    {
        _context = context;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<CloudHealthOfficeResponse> SubmitClaimAsync(Claim claim, InsurancePlan payer)
    {
        if (string.IsNullOrEmpty(payer.ApiEndpoint))
            throw new InvalidOperationException($"Payer {payer.PayerName} has no API endpoint configured");

        // Load full claim with all relationships
        var fullClaim = await _context.Claims
            .Include(c => c.Patient)
            .Include(c => c.Provider)
            .Include(c => c.PatientInsurance)
                .ThenInclude(pi => pi!.InsurancePlan)
            .Include(c => c.Procedures)
            .FirstOrDefaultAsync(c => c.ClaimId == claim.ClaimId);

        if (fullClaim == null)
            throw new InvalidOperationException($"Claim {claim.ClaimNumber} not found");

        // Build JSON payload
        var payload = new Claim837DRequest
        {
            ClaimNumber = fullClaim.ClaimNumber,
            ServiceDateFrom = fullClaim.ServiceDateFrom,
            ServiceDateTo = fullClaim.ServiceDateTo,
            TotalChargeAmount = fullClaim.TotalChargeAmount,
            PlaceOfService = "11", // Office
            Patient = new PatientInfo
            {
                FirstName = fullClaim.Patient?.FirstName ?? "",
                LastName = fullClaim.Patient?.LastName ?? "",
                DateOfBirth = fullClaim.Patient?.DateOfBirth ?? DateTime.MinValue,
                Gender = fullClaim.Patient?.Gender ?? "Unknown",
                Address1 = fullClaim.Patient?.Address1,
                City = fullClaim.Patient?.City,
                State = fullClaim.Patient?.State,
                ZipCode = fullClaim.Patient?.ZipCode,
                Phone = fullClaim.Patient?.PrimaryPhone
            },
            Subscriber = new SubscriberInfo
            {
                MemberId = fullClaim.PatientInsurance?.MemberId ?? fullClaim.Patient?.PatientId.ToString() ?? "",
                GroupNumber = fullClaim.PatientInsurance?.GroupNumber,
                RelationshipToPatient = "Self" // TODO: Handle dependents
            },
            Provider = new ProviderInfo
            {
                NPI = fullClaim.Provider?.NPI ?? "",
                FirstName = fullClaim.Provider?.FirstName ?? "",
                LastName = fullClaim.Provider?.LastName ?? "",
                TaxId = "123456789", // TODO: Store in Provider model
                Address1 = "123 Dental Plaza",
                City = "Anytown",
                State = "CA",
                ZipCode = "90210",
                Phone = "5555551234"
            },
            Payer = new PayerInfo
            {
                PayerId = fullClaim.PatientInsurance?.InsurancePlan?.EdiPayerId ?? fullClaim.PatientInsurance?.InsurancePlan?.PayerId ?? "",
                PayerName = fullClaim.PatientInsurance?.InsurancePlan?.PayerName ?? ""
            },
            Procedures = fullClaim.Procedures.Select(p => new ProcedureInfo
            {
                ProcedureCode = p.CDTCode,
                Description = p.Description,
                ServiceDate = p.ServiceDate,
                ChargeAmount = p.ChargeAmount,
                ToothNumber = p.ToothNumber,
                DiagnosisCodePointers = null // TODO: Add DiagnosisCodePointers field to ClaimProcedure
            }).ToList()
        };

        _logger.LogInformation("Submitting claim {ClaimNumber} to CloudHealthOffice API: {Endpoint}",
            fullClaim.ClaimNumber, payer.ApiEndpoint);

        try
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(payer.ApiEndpoint);
            client.Timeout = TimeSpan.FromSeconds(30);

            // Add authentication
            if (!string.IsNullOrEmpty(payer.ApiKeyEncrypted))
            {
                var apiKey = DecryptValue(payer.ApiKeyEncrypted);
                
                if (payer.ApiAuthType == "Bearer")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                }
                else // ApiKey or default
                {
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                }
            }

            // POST to /api/claims/837d
            var response = await client.PostAsJsonAsync("/api/claims/837d", payload);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CloudHealthOfficeResponse>();
                
                _logger.LogInformation("Successfully submitted claim {ClaimNumber} to CloudHealthOffice. Tracking ID: {TrackingId}",
                    fullClaim.ClaimNumber, result?.TrackingId);

                return result ?? new CloudHealthOfficeResponse
                {
                    Success = true,
                    Message = "Claim submitted successfully"
                };
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("CloudHealthOffice API returned {StatusCode}: {Error}",
                    response.StatusCode, errorContent);

                throw new InvalidOperationException($"API returned {response.StatusCode}: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to submit claim {ClaimNumber} to CloudHealthOffice API",
                fullClaim.ClaimNumber);
            throw;
        }
    }

    public async Task<bool> TestConnectionAsync(InsurancePlan payer)
    {
        if (string.IsNullOrEmpty(payer.ApiEndpoint))
            return false;

        try
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(payer.ApiEndpoint);
            client.Timeout = TimeSpan.FromSeconds(10);

            if (!string.IsNullOrEmpty(payer.ApiKeyEncrypted))
            {
                var apiKey = DecryptValue(payer.ApiKeyEncrypted);
                if (payer.ApiAuthType == "Bearer")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                }
                else
                {
                    client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                }
            }

            // Test endpoint - /api/health or /api/ping
            var response = await client.GetAsync("/api/health");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "CloudHealthOffice API connection test failed for {Endpoint}",
                payer.ApiEndpoint);
            return false;
        }
    }

    private string DecryptValue(string encryptedValue)
    {
        // TODO: Implement proper encryption/decryption
        if (string.IsNullOrEmpty(encryptedValue))
            return string.Empty;

        try
        {
            var bytes = Convert.FromBase64String(encryptedValue);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
        catch
        {
            return encryptedValue;
        }
    }
}

// DTOs for CloudHealthOffice API

public class Claim837DRequest
{
    [JsonPropertyName("claimNumber")]
    public string ClaimNumber { get; set; } = string.Empty;

    [JsonPropertyName("serviceDateFrom")]
    public DateTime ServiceDateFrom { get; set; }

    [JsonPropertyName("serviceDateTo")]
    public DateTime? ServiceDateTo { get; set; }

    [JsonPropertyName("totalChargeAmount")]
    public decimal TotalChargeAmount { get; set; }

    [JsonPropertyName("placeOfService")]
    public string PlaceOfService { get; set; } = string.Empty;

    [JsonPropertyName("patient")]
    public PatientInfo Patient { get; set; } = new();

    [JsonPropertyName("subscriber")]
    public SubscriberInfo Subscriber { get; set; } = new();

    [JsonPropertyName("provider")]
    public ProviderInfo Provider { get; set; } = new();

    [JsonPropertyName("payer")]
    public PayerInfo Payer { get; set; } = new();

    [JsonPropertyName("procedures")]
    public List<ProcedureInfo> Procedures { get; set; } = new();
}

public class PatientInfo
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("dateOfBirth")]
    public DateTime? DateOfBirth { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; } = string.Empty;

    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("zipCode")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }
}

public class SubscriberInfo
{
    [JsonPropertyName("memberId")]
    public string MemberId { get; set; } = string.Empty;

    [JsonPropertyName("groupNumber")]
    public string? GroupNumber { get; set; }

    [JsonPropertyName("relationshipToPatient")]
    public string RelationshipToPatient { get; set; } = "Self";
}

public class ProviderInfo
{
    [JsonPropertyName("npi")]
    public string NPI { get; set; } = string.Empty;

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("taxId")]
    public string TaxId { get; set; } = string.Empty;

    [JsonPropertyName("address1")]
    public string Address1 { get; set; } = string.Empty;

    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("zipCode")]
    public string ZipCode { get; set; } = string.Empty;

    [JsonPropertyName("phone")]
    public string Phone { get; set; } = string.Empty;
}

public class PayerInfo
{
    [JsonPropertyName("payerId")]
    public string PayerId { get; set; } = string.Empty;

    [JsonPropertyName("payerName")]
    public string PayerName { get; set; } = string.Empty;
}

public class ProcedureInfo
{
    [JsonPropertyName("procedureCode")]
    public string ProcedureCode { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("serviceDate")]
    public DateTime ServiceDate { get; set; }

    [JsonPropertyName("chargeAmount")]
    public decimal ChargeAmount { get; set; }

    [JsonPropertyName("toothNumber")]
    public string? ToothNumber { get; set; }

    [JsonPropertyName("diagnosisCodePointers")]
    public string? DiagnosisCodePointers { get; set; }
}

public class CloudHealthOfficeResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("trackingId")]
    public string? TrackingId { get; set; }

    [JsonPropertyName("ediControlNumber")]
    public string? EdiControlNumber { get; set; }

    [JsonPropertyName("errors")]
    public List<string>? Errors { get; set; }
}
