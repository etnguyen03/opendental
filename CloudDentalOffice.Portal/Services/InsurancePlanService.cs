using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Service for managing insurance plans and payer configurations
/// </summary>
public interface IInsurancePlanService
{
    Task<List<InsurancePlan>> GetInsurancePlansAsync();
    Task<InsurancePlan?> GetInsurancePlanByIdAsync(int insurancePlanId);
    Task<InsurancePlan> CreateInsurancePlanAsync(InsurancePlan plan);
    Task<InsurancePlan> UpdateInsurancePlanAsync(InsurancePlan plan);
    Task DeleteInsurancePlanAsync(int insurancePlanId);
    Task<bool> TestEdiConnectionAsync(int insurancePlanId);
}

public class InsurancePlanService : IInsurancePlanService
{
    private readonly CloudDentalDbContext _context;
    private readonly IEdiSubmissionService _ediSubmissionService;
    private readonly ILogger<InsurancePlanService> _logger;

    public InsurancePlanService(
        CloudDentalDbContext context,
        IEdiSubmissionService ediSubmissionService,
        ILogger<InsurancePlanService> logger)
    {
        _context = context;
        _ediSubmissionService = ediSubmissionService;
        _logger = logger;
    }

    public async Task<List<InsurancePlan>> GetInsurancePlansAsync()
    {
        try
        {
            return await _context.InsurancePlans
                .OrderBy(p => p.PayerName)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving insurance plans");
            return new List<InsurancePlan>();
        }
    }

    public async Task<InsurancePlan?> GetInsurancePlanByIdAsync(int insurancePlanId)
    {
        try
        {
            return await _context.InsurancePlans
                .FirstOrDefaultAsync(p => p.InsurancePlanId == insurancePlanId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving insurance plan {InsurancePlanId}", insurancePlanId);
            return null;
        }
    }

    public async Task<InsurancePlan> CreateInsurancePlanAsync(InsurancePlan plan)
    {
        try
        {
            plan.CreatedDate = DateTime.UtcNow;
            _context.InsurancePlans.Add(plan);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Created insurance plan {PayerName}", plan.PayerName);
            return plan;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating insurance plan {PayerName}", plan.PayerName);
            throw;
        }
    }

    public async Task<InsurancePlan> UpdateInsurancePlanAsync(InsurancePlan plan)
    {
        try
        {
            plan.ModifiedDate = DateTime.UtcNow;
            _context.InsurancePlans.Update(plan);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Updated insurance plan {PayerName}", plan.PayerName);
            return plan;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating insurance plan {InsurancePlanId}", plan.InsurancePlanId);
            throw;
        }
    }

    public async Task DeleteInsurancePlanAsync(int insurancePlanId)
    {
        try
        {
            var plan = await _context.InsurancePlans.FindAsync(insurancePlanId);
            if (plan != null)
            {
                _context.InsurancePlans.Remove(plan);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Deleted insurance plan {PayerName}", plan.PayerName);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting insurance plan {InsurancePlanId}", insurancePlanId);
            throw;
        }
    }

    public async Task<bool> TestEdiConnectionAsync(int insurancePlanId)
    {
        try
        {
            return await _ediSubmissionService.TestPayerConnectionAsync(insurancePlanId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error testing EDI connection for insurance plan {InsurancePlanId}", insurancePlanId);
            return false;
        }
    }
}
