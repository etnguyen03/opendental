using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Claim service implementation with EF Core
/// </summary>
public class ClaimServiceImpl : IClaimService
{
    private readonly CloudDentalDbContext _context;
    private readonly IEdiSubmissionService _ediSubmissionService;
    private readonly ILogger<ClaimServiceImpl> _logger;

    public ClaimServiceImpl(
        CloudDentalDbContext context,
        IEdiSubmissionService ediSubmissionService,
        ILogger<ClaimServiceImpl> logger)
    {
        _context = context;
        _ediSubmissionService = ediSubmissionService;
        _logger = logger;
    }

    public async Task<List<Models.Claim>> GetClaimsAsync()
    {
        try
        {
            return await _context.Claims
                .Include(c => c.Patient)
                .Include(c => c.Provider)
                .Include(c => c.PatientInsurance)
                    .ThenInclude(pi => pi.InsurancePlan)
                .Include(c => c.Procedures)
                .OrderByDescending(c => c.CreatedDate)
                .Take(100) // Limit to most recent 100
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving claims");
            return new List<Models.Claim>();
        }
    }

    public async Task<Models.Claim?> GetClaimByIdAsync(string claimId)
    {
        if (!int.TryParse(claimId, out var id))
            return null;

        try
        {
            return await _context.Claims
                .Include(c => c.Patient)
                .Include(c => c.Provider)
                .Include(c => c.PatientInsurance)
                    .ThenInclude(pi => pi.InsurancePlan)
                .Include(c => c.Procedures)
                .FirstOrDefaultAsync(c => c.ClaimId == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving claim {ClaimId}", claimId);
            return null;
        }
    }

    public async Task<Models.Claim> CreateClaimAsync(Models.Claim claim)
    {
        try
        {
            // Generate claim number if not provided
            if (string.IsNullOrEmpty(claim.ClaimNumber))
            {
                claim.ClaimNumber = await GenerateClaimNumberAsync();
            }

            claim.CreatedDate = DateTime.UtcNow;
            claim.Status = "Draft";

            // Calculate total charge amount from procedures
            claim.TotalChargeAmount = claim.Procedures.Sum(p => p.ChargeAmount);

            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Created claim {ClaimNumber} for patient {PatientId}", claim.ClaimNumber, claim.PatientId);
            return claim;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating claim for patient {PatientId}", claim.PatientId);
            throw;
        }
    }

    public async Task<Models.Claim> UpdateClaimStatusAsync(string claimId, string status)
    {
        if (!int.TryParse(claimId, out var id))
            throw new ArgumentException("Invalid claim ID", nameof(claimId));

        try
        {
            var claim = await _context.Claims
                .Include(c => c.Procedures)
                .FirstOrDefaultAsync(c => c.ClaimId == id);

            if (claim == null)
                throw new KeyNotFoundException($"Claim {claimId} not found");

            claim.Status = status;
            claim.ModifiedDate = DateTime.UtcNow;

            if (status == "Submitted")
            {
                claim.SubmittedDate = DateTime.UtcNow;
            }
            else if (status == "Paid" || status == "Processed")
            {
                claim.ProcessedDate = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation("Updated claim {ClaimNumber} status to {Status}", claim.ClaimNumber, status);
            return claim;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating claim {ClaimId} status", claimId);
            throw;
        }
    }

    public async Task<Models.Claim> SubmitClaimAsync(string claimId)
    {
        if (!int.TryParse(claimId, out var id))
            throw new ArgumentException("Invalid claim ID");

        try
        {
            var claim = await _context.Claims
                .Include(c => c.Patient)
                .Include(c => c.Provider)
                .Include(c => c.PatientInsurance)
                    .ThenInclude(pi => pi.InsurancePlan)
                .Include(c => c.Procedures)
                .FirstOrDefaultAsync(c => c.ClaimId == id);

            if (claim == null)
                throw new KeyNotFoundException($"Claim {claimId} not found");

            // Submit claim via EDI (SFTP, API, or both depending on payer configuration)
            var submissionResult = await _ediSubmissionService.SubmitClaimAsync(claim);

            if (submissionResult.Success)
            {
                claim.Status = "Submitted";
                claim.SubmittedDate = DateTime.UtcNow;
                claim.ModifiedDate = DateTime.UtcNow;

                // Store EDI control number if available (from API submission)
                if (!string.IsNullOrEmpty(submissionResult.EdiControlNumber))
                {
                    claim.EdiControlNumber = submissionResult.EdiControlNumber;
                }

                await _context.SaveChangesAsync();

                _logger.LogInformation(
                    "Successfully submitted claim {ClaimNumber} via {SubmissionType}. SFTP: {SftpPath}, API Tracking: {TrackingId}",
                    claim.ClaimNumber, submissionResult.SubmissionType, submissionResult.SftpFilePath, submissionResult.ApiTrackingId);
            }
            else
            {
                _logger.LogError("Failed to submit claim {ClaimNumber}: {Error}",
                    claim.ClaimNumber, submissionResult.ErrorMessage);

                throw new InvalidOperationException($"EDI submission failed: {submissionResult.ErrorMessage}");
            }

            return claim;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error submitting claim {ClaimId}", claimId);
            throw;
        }
    }

    private async Task<string> GenerateClaimNumberAsync()
    {
        var year = DateTime.Now.Year;
        var lastClaim = await _context.Claims
            .Where(c => c.ClaimNumber.StartsWith($"CLM-{year}-"))
            .OrderByDescending(c => c.ClaimNumber)
            .FirstOrDefaultAsync();

        int nextNumber = 1;
        if (lastClaim != null)
        {
            var parts = lastClaim.ClaimNumber.Split('-');
            if (parts.Length == 3 && int.TryParse(parts[2], out var lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }

        return $"CLM-{year}-{nextNumber:D4}";
    }
}
