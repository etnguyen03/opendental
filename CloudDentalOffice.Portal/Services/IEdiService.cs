namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// EDI Service for handling X12 transactions
/// Integrates with CloudHealthOffice EDI flows for dental practice management
/// </summary>
public interface IEdiService
{
    // 837D - Dental Claims
    Task<ClaimSubmissionResult> SubmitDentalClaim837D(DentalClaimRequest claim);
    Task<List<ClaimSubmissionResult>> GetPendingClaims();
    
    // 270/271 - Eligibility Verification
    Task<EligibilityResponse> VerifyEligibility270(EligibilityRequest request);
    Task<List<EligibilityResponse>> GetRecentEligibilityChecks();
    
    // 276/277 - Claim Status Inquiry
    Task<ClaimStatusResponse> InquireClaimStatus276(ClaimStatusRequest request);
    Task<List<ClaimStatusResponse>> GetClaimStatusUpdates();
    
    // 278 - Prior Authorization
    Task<PriorAuthResponse> RequestPriorAuthorization278(PriorAuthRequest request);
    Task<List<PriorAuthResponse>> GetPendingPriorAuths();
    
    // 834 - Benefit Enrollment
    Task<EnrollmentResponse> ProcessEnrollment834(EnrollmentRequest request);
    Task<List<EnrollmentResponse>> GetEnrollmentUpdates();
    
    // 835 - Remittance Advice
    Task<RemittanceResponse> ProcessRemittance835(RemittanceRequest request);
    Task<List<RemittanceResponse>> GetRemittanceAdvices(DateTime startDate, DateTime endDate);
}

// DTOs for EDI transactions

public class DentalClaimRequest
{
    public string ClaimNumber { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public string SubscriberId { get; set; } = string.Empty;
    public string PayerId { get; set; } = string.Empty;
    public string ProviderId { get; set; } = string.Empty;
    public string ProviderNPI { get; set; } = string.Empty;
    public DateTime ServiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<DentalProcedure> Procedures { get; set; } = new();
}

public class DentalProcedure
{
    public string CDTCode { get; set; } = string.Empty; // CDT = Current Dental Terminology
    public string ToothNumber { get; set; } = string.Empty;
    public string Surface { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Fee { get; set; }
    public int Quantity { get; set; }
}

public class ClaimSubmissionResult
{
    public string ClaimNumber { get; set; } = string.Empty;
    public string ControlNumber { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime SubmissionDate { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsSuccessful { get; set; }
}

public class EligibilityRequest
{
    public string MemberId { get; set; } = string.Empty;
    public string PayerId { get; set; } = string.Empty;
    public string ProviderId { get; set; } = string.Empty;
    public DateTime ServiceDate { get; set; }
    public List<string> ServiceTypeCodes { get; set; } = new();
}

public class EligibilityResponse
{
    public string MemberId { get; set; } = string.Empty;
    public bool IsEligible { get; set; }
    public string? PlanName { get; set; }
    public string? GroupNumber { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public decimal? Deductible { get; set; }
    public decimal? DeductibleMet { get; set; }
    public decimal? OutOfPocketMax { get; set; }
    public decimal? OutOfPocketMet { get; set; }
    public List<BenefitInfo> Benefits { get; set; } = new();
}

public class BenefitInfo
{
    public string ServiceType { get; set; } = string.Empty;
    public string CoverageLevel { get; set; } = string.Empty;
    public decimal? CoveragePercent { get; set; }
    public decimal? AnnualMax { get; set; }
    public decimal? AnnualMaxRemaining { get; set; }
}

public class ClaimStatusRequest
{
    public string ClaimNumber { get; set; } = string.Empty;
    public string PayerId { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public DateTime ServiceDate { get; set; }
}

public class ClaimStatusResponse
{
    public string ClaimNumber { get; set; } = string.Empty;
    public string StatusCode { get; set; } = string.Empty;
    public string StatusDescription { get; set; } = string.Empty;
    public DateTime StatusDate { get; set; }
    public decimal? PaidAmount { get; set; }
    public string? CheckNumber { get; set; }
    public DateTime? PaymentDate { get; set; }
}

public class PriorAuthRequest
{
    public string PatientId { get; set; } = string.Empty;
    public string MemberId { get; set; } = string.Empty;
    public string PayerId { get; set; } = string.Empty;
    public string ProviderId { get; set; } = string.Empty;
    public List<DentalProcedure> RequestedProcedures { get; set; } = new();
    public string ClinicalJustification { get; set; } = string.Empty;
}

public class PriorAuthResponse
{
    public string AuthorizationNumber { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty; // Approved, Denied, Pending
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public List<DentalProcedure> ApprovedProcedures { get; set; } = new();
    public string? DenialReason { get; set; }
}

public class EnrollmentRequest
{
    public string MemberId { get; set; } = string.Empty;
    public string SubscriberId { get; set; } = string.Empty;
    public string PayerId { get; set; } = string.Empty;
    public string TransactionType { get; set; } = string.Empty; // Add, Change, Cancel
    public DateTime EffectiveDate { get; set; }
    public PatientDemographics Demographics { get; set; } = new();
}

public class PatientDemographics
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string SSN { get; set; } = string.Empty;
    public Address Address { get; set; } = new();
}

public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}

public class EnrollmentResponse
{
    public string MemberId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime ProcessedDate { get; set; }
    public string? ErrorMessage { get; set; }
}

public class RemittanceRequest
{
    public string PayerId { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
}

public class RemittanceResponse
{
    public string CheckNumber { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PayerId { get; set; } = string.Empty;
    public string PayerName { get; set; } = string.Empty;
    public List<ClaimPayment> ClaimPayments { get; set; } = new();
}

public class ClaimPayment
{
    public string ClaimNumber { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public decimal BilledAmount { get; set; }
    public decimal AllowedAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal PatientResponsibility { get; set; }
    public List<Adjustment> Adjustments { get; set; } = new();
}

public class Adjustment
{
    public string ReasonCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
