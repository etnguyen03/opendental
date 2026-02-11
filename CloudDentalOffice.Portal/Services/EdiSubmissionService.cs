using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Orchestrates EDI claim submission across multiple channels (SFTP, API)
/// Determines the appropriate submission method based on payer configuration
/// </summary>
public interface IEdiSubmissionService
{
    Task<EdiSubmissionResult> SubmitClaimAsync(Claim claim);
    Task<bool> TestPayerConnectionAsync(int insurancePlanId);
}

public class EdiSubmissionService : IEdiSubmissionService
{
    private readonly CloudDentalDbContext _context;
    private readonly IEdiX12Service _x12Service;
    private readonly IEdiSftpService _sftpService;
    private readonly ICloudHealthOfficeApiService _apiService;
    private readonly ILogger<EdiSubmissionService> _logger;

    public EdiSubmissionService(
        CloudDentalDbContext context,
        IEdiX12Service x12Service,
        IEdiSftpService sftpService,
        ICloudHealthOfficeApiService apiService,
        ILogger<EdiSubmissionService> logger)
    {
        _context = context;
        _x12Service = x12Service;
        _sftpService = sftpService;
        _apiService = apiService;
        _logger = logger;
    }

    public async Task<EdiSubmissionResult> SubmitClaimAsync(Claim claim)
    {
        // Load claim with insurance plan
        var fullClaim = await _context.Claims
            .Include(c => c.PatientInsurance)
                .ThenInclude(pi => pi!.InsurancePlan)
            .FirstOrDefaultAsync(c => c.ClaimId == claim.ClaimId);

        if (fullClaim?.PatientInsurance?.InsurancePlan == null)
        {
            return new EdiSubmissionResult
            {
                Success = false,
                ErrorMessage = "Claim has no associated insurance plan"
            };
        }

        var payer = fullClaim.PatientInsurance.InsurancePlan;

        if (!payer.EdiEnabled)
        {
            return new EdiSubmissionResult
            {
                Success = false,
                ErrorMessage = $"EDI is not enabled for payer {payer.PayerName}"
            };
        }

        _logger.LogInformation("Submitting claim {ClaimNumber} via {SubmissionType} for payer {PayerName}",
            fullClaim.ClaimNumber, payer.EdiSubmissionType, payer.PayerName);

        var result = new EdiSubmissionResult
        {
            ClaimNumber = fullClaim.ClaimNumber,
            PayerName = payer.PayerName,
            SubmissionType = payer.EdiSubmissionType ?? "Unknown"
        };

        try
        {
            switch (payer.EdiSubmissionType?.ToUpper())
            {
                case "SFTP":
                    await SubmitViaSftpAsync(fullClaim, payer, result);
                    break;

                case "API":
                    await SubmitViaApiAsync(fullClaim, payer, result);
                    break;

                case "BOTH":
                    // Submit via both channels
                    await SubmitViaSftpAsync(fullClaim, payer, result);
                    await SubmitViaApiAsync(fullClaim, payer, result);
                    break;

                default:
                    result.Success = false;
                    result.ErrorMessage = $"Unknown EDI submission type: {payer.EdiSubmissionType}";
                    break;
            }

            if (result.Success)
            {
                _logger.LogInformation("Successfully submitted claim {ClaimNumber} via {SubmissionType}",
                    fullClaim.ClaimNumber, payer.EdiSubmissionType);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to submit claim {ClaimNumber} for payer {PayerName}",
                fullClaim.ClaimNumber, payer.PayerName);

            result.Success = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    public async Task<bool> TestPayerConnectionAsync(int insurancePlanId)
    {
        var payer = await _context.InsurancePlans.FindAsync(insurancePlanId);
        if (payer == null)
            return false;

        if (!payer.EdiEnabled)
            return false;

        switch (payer.EdiSubmissionType?.ToUpper())
        {
            case "SFTP":
                return await _sftpService.TestConnectionAsync(payer);

            case "API":
                return await _apiService.TestConnectionAsync(payer);

            case "BOTH":
                var sftpOk = await _sftpService.TestConnectionAsync(payer);
                var apiOk = await _apiService.TestConnectionAsync(payer);
                return sftpOk && apiOk;

            default:
                return false;
        }
    }

    private async Task SubmitViaSftpAsync(Claim claim, InsurancePlan payer, EdiSubmissionResult result)
    {
        try
        {
            // Generate X12 837D
            var x12Content = await _x12Service.Generate837DTransactionAsync(claim);

            // Upload to SFTP
            var remotePath = await _sftpService.UploadClaimAsync(claim, payer, x12Content);

            result.Success = true;
            result.SftpFilePath = remotePath;
            result.X12Generated = true;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorMessage = $"SFTP submission failed: {ex.Message}";
            throw;
        }
    }

    private async Task SubmitViaApiAsync(Claim claim, InsurancePlan payer, EdiSubmissionResult result)
    {
        try
        {
            // Submit via CloudHealthOffice API
            var apiResponse = await _apiService.SubmitClaimAsync(claim, payer);

            if (apiResponse.Success)
            {
                result.Success = true;
                result.ApiTrackingId = apiResponse.TrackingId;
                result.EdiControlNumber = apiResponse.EdiControlNumber;
            }
            else
            {
                result.Success = false;
                result.ErrorMessage = $"API submission failed: {apiResponse.Message}";
                
                if (apiResponse.Errors?.Any() == true)
                {
                    result.ErrorMessage += " - " + string.Join(", ", apiResponse.Errors);
                }
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorMessage = $"API submission failed: {ex.Message}";
            throw;
        }
    }
}

/// <summary>
/// Result of EDI claim submission
/// </summary>
public class EdiSubmissionResult
{
    public bool Success { get; set; }
    public string? ClaimNumber { get; set; }
    public string? PayerName { get; set; }
    public string? SubmissionType { get; set; }
    public string? ErrorMessage { get; set; }

    // SFTP-specific
    public bool X12Generated { get; set; }
    public string? SftpFilePath { get; set; }

    // API-specific
    public string? ApiTrackingId { get; set; }
    public string? EdiControlNumber { get; set; }
}
