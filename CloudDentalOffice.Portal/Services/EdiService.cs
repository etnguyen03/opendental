namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// EDI Service implementation
/// Connects to CloudHealthOffice EDI platform for X12 processing
/// </summary>
public class EdiService : IEdiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<EdiService> _logger;
    private readonly string _ediApiBaseUrl;

    public EdiService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<EdiService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
        
        _ediApiBaseUrl = configuration["EdiApi:BaseUrl"] ?? "https://edi.cloudhealthoffice.com/api";
        _httpClient.BaseAddress = new Uri(_ediApiBaseUrl);
        
        // Add authentication header
        var apiKey = configuration["EdiApi:ApiKey"];
        if (!string.IsNullOrEmpty(apiKey))
        {
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
        }
    }

    public async Task<ClaimSubmissionResult> SubmitDentalClaim837D(DentalClaimRequest claim)
    {
        try
        {
            _logger.LogInformation("Submitting 837D dental claim {ClaimNumber}", claim.ClaimNumber);

            var response = await _httpClient.PostAsJsonAsync("/claims/837d/submit", claim);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ClaimSubmissionResult>();
            return result ?? throw new Exception("Failed to deserialize claim submission result");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error submitting 837D claim {ClaimNumber}", claim.ClaimNumber);
            return new ClaimSubmissionResult
            {
                ClaimNumber = claim.ClaimNumber,
                IsSuccessful = false,
                ErrorMessage = ex.Message,
                SubmissionDate = DateTime.UtcNow
            };
        }
    }

    public async Task<List<ClaimSubmissionResult>> GetPendingClaims()
    {
        try
        {
            var response = await _httpClient.GetAsync("/claims/837d/pending");
            response.EnsureSuccessStatusCode();

            var claims = await response.Content.ReadFromJsonAsync<List<ClaimSubmissionResult>>();
            return claims ?? new List<ClaimSubmissionResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving pending claims");
            return new List<ClaimSubmissionResult>();
        }
    }

    public async Task<EligibilityResponse> VerifyEligibility270(EligibilityRequest request)
    {
        try
        {
            _logger.LogInformation("Verifying eligibility for member {MemberId}", request.MemberId);

            var response = await _httpClient.PostAsJsonAsync("/eligibility/270/verify", request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<EligibilityResponse>();
            return result ?? throw new Exception("Failed to deserialize eligibility response");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error verifying eligibility for member {MemberId}", request.MemberId);
            return new EligibilityResponse
            {
                MemberId = request.MemberId,
                IsEligible = false
            };
        }
    }

    public async Task<List<EligibilityResponse>> GetRecentEligibilityChecks()
    {
        try
        {
            var response = await _httpClient.GetAsync("/eligibility/271/recent");
            response.EnsureSuccessStatusCode();

            var checks = await response.Content.ReadFromJsonAsync<List<EligibilityResponse>>();
            return checks ?? new List<EligibilityResponse>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving recent eligibility checks");
            return new List<EligibilityResponse>();
        }
    }

    public async Task<ClaimStatusResponse> InquireClaimStatus276(ClaimStatusRequest request)
    {
        try
        {
            _logger.LogInformation("Inquiring status for claim {ClaimNumber}", request.ClaimNumber);

            var response = await _httpClient.PostAsJsonAsync("/claimstatus/276/inquire", request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ClaimStatusResponse>();
            return result ?? throw new Exception("Failed to deserialize claim status response");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inquiring status for claim {ClaimNumber}", request.ClaimNumber);
            return new ClaimStatusResponse
            {
                ClaimNumber = request.ClaimNumber,
                StatusCode = "ERROR",
                StatusDescription = "Error retrieving claim status",
                StatusDate = DateTime.UtcNow
            };
        }
    }

    public async Task<List<ClaimStatusResponse>> GetClaimStatusUpdates()
    {
        try
        {
            var response = await _httpClient.GetAsync("/claimstatus/277/updates");
            response.EnsureSuccessStatusCode();

            var updates = await response.Content.ReadFromJsonAsync<List<ClaimStatusResponse>>();
            return updates ?? new List<ClaimStatusResponse>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving claim status updates");
            return new List<ClaimStatusResponse>();
        }
    }

    public async Task<PriorAuthResponse> RequestPriorAuthorization278(PriorAuthRequest request)
    {
        try
        {
            _logger.LogInformation("Requesting prior authorization for patient {PatientId}", request.PatientId);

            var response = await _httpClient.PostAsJsonAsync("/priorauth/278/request", request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PriorAuthResponse>();
            return result ?? throw new Exception("Failed to deserialize prior auth response");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error requesting prior authorization for patient {PatientId}", request.PatientId);
            return new PriorAuthResponse
            {
                Status = "Error",
                DenialReason = ex.Message
            };
        }
    }

    public async Task<List<PriorAuthResponse>> GetPendingPriorAuths()
    {
        try
        {
            var response = await _httpClient.GetAsync("/priorauth/278/pending");
            response.EnsureSuccessStatusCode();

            var auths = await response.Content.ReadFromJsonAsync<List<PriorAuthResponse>>();
            return auths ?? new List<PriorAuthResponse>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving pending prior authorizations");
            return new List<PriorAuthResponse>();
        }
    }

    public async Task<EnrollmentResponse> ProcessEnrollment834(EnrollmentRequest request)
    {
        try
        {
            _logger.LogInformation("Processing 834 enrollment for member {MemberId}", request.MemberId);

            var response = await _httpClient.PostAsJsonAsync("/enrollment/834/process", request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<EnrollmentResponse>();
            return result ?? throw new Exception("Failed to deserialize enrollment response");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing enrollment for member {MemberId}", request.MemberId);
            return new EnrollmentResponse
            {
                MemberId = request.MemberId,
                Status = "Error",
                ProcessedDate = DateTime.UtcNow,
                ErrorMessage = ex.Message
            };
        }
    }

    public async Task<List<EnrollmentResponse>> GetEnrollmentUpdates()
    {
        try
        {
            var response = await _httpClient.GetAsync("/enrollment/834/updates");
            response.EnsureSuccessStatusCode();

            var updates = await response.Content.ReadFromJsonAsync<List<EnrollmentResponse>>();
            return updates ?? new List<EnrollmentResponse>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving enrollment updates");
            return new List<EnrollmentResponse>();
        }
    }

    public async Task<RemittanceResponse> ProcessRemittance835(RemittanceRequest request)
    {
        try
        {
            _logger.LogInformation("Processing 835 remittance for payer {PayerId}", request.PayerId);

            var response = await _httpClient.PostAsJsonAsync("/remittance/835/process", request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<RemittanceResponse>();
            return result ?? throw new Exception("Failed to deserialize remittance response");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing remittance for payer {PayerId}", request.PayerId);
            return new RemittanceResponse
            {
                PayerId = request.PayerId,
                PaymentDate = request.PaymentDate,
                TotalAmount = 0
            };
        }
    }

    public async Task<List<RemittanceResponse>> GetRemittanceAdvices(DateTime startDate, DateTime endDate)
    {
        try
        {
            var response = await _httpClient.GetAsync(
                $"/remittance/835/list?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
            response.EnsureSuccessStatusCode();

            var remittances = await response.Content.ReadFromJsonAsync<List<RemittanceResponse>>();
            return remittances ?? new List<RemittanceResponse>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving remittance advices");
            return new List<RemittanceResponse>();
        }
    }
}
