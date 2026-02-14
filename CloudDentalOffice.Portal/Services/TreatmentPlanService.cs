using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using CloudDentalOffice.Portal.Services.Tenancy;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

public class TreatmentPlanService : ITreatmentPlanService
{
    private readonly CloudDentalDbContext _context;
    private readonly ITenantProvider _tenantProvider;

    public TreatmentPlanService(CloudDentalDbContext context, ITenantProvider tenantProvider)
    {
        _context = context;
        _tenantProvider = tenantProvider;
    }

    public async Task<List<TreatmentPlan>> GetAllTreatmentPlansAsync()
    {
        var tenantId = _tenantProvider.TenantId;
        if (string.IsNullOrEmpty(tenantId))
            throw new InvalidOperationException("Tenant ID is not available");

        return await _context.TreatmentPlans
            .Include(tp => tp.Patient)
            .Include(tp => tp.Provider)
            .Include(tp => tp.PlannedProcedures)
            .Where(tp => tp.TenantId == tenantId)
            .OrderByDescending(tp => tp.CreatedDate)
            .ToListAsync();
    }

    public async Task<List<TreatmentPlan>> GetTreatmentPlansAsync(string patientId)
    {
        var tenantId = _tenantProvider.TenantId;
        if (string.IsNullOrEmpty(tenantId))
            throw new InvalidOperationException("Tenant ID is not available");

        if (!int.TryParse(patientId, out int patientIdInt))
            throw new ArgumentException("Invalid patient ID format", nameof(patientId));

        return await _context.TreatmentPlans
            .Include(tp => tp.Patient)
            .Include(tp => tp.Provider)
            .Include(tp => tp.PlannedProcedures)
            .Where(tp => tp.TenantId == tenantId && tp.PatientId == patientIdInt)
            .OrderByDescending(tp => tp.CreatedDate)
            .ToListAsync();
    }

    public async Task<TreatmentPlan?> GetTreatmentPlanByIdAsync(string treatmentPlanId)
    {
        var tenantId = _tenantProvider.TenantId;
        if (string.IsNullOrEmpty(tenantId))
            throw new InvalidOperationException("Tenant ID is not available");

        if (!int.TryParse(treatmentPlanId, out int planIdInt))
            throw new ArgumentException("Invalid treatment plan ID format", nameof(treatmentPlanId));

        return await _context.TreatmentPlans
            .Include(tp => tp.Patient)
            .Include(tp => tp.Provider)
            .Include(tp => tp.PlannedProcedures)
            .Where(tp => tp.TenantId == tenantId && tp.TreatmentPlanId == planIdInt)
            .FirstOrDefaultAsync();
    }

    public async Task<TreatmentPlan> CreateTreatmentPlanAsync(TreatmentPlan plan)
    {
        var tenantId = _tenantProvider.TenantId;
        if (string.IsNullOrEmpty(tenantId))
            throw new InvalidOperationException("Tenant ID is not available");

        // Set tenant ID and dates
        plan.TenantId = tenantId;
        plan.CreatedDate = DateTime.UtcNow;
        plan.PresentedDate = NormalizeToUtc(plan.PresentedDate);
        plan.AcceptedDate = NormalizeToUtc(plan.AcceptedDate);
        plan.CompletedDate = NormalizeToUtc(plan.CompletedDate);
        
        // Ensure all planned procedures have the correct tenant ID
        foreach (var procedure in plan.PlannedProcedures)
        {
            procedure.TenantId = tenantId;
            procedure.CreatedDate = DateTime.UtcNow;
            procedure.CompletedDate = NormalizeToUtc(procedure.CompletedDate);
        }

        _context.TreatmentPlans.Add(plan);
        await _context.SaveChangesAsync();

        // Reload with navigation properties
        return await GetTreatmentPlanByIdAsync(plan.TreatmentPlanId.ToString()) 
               ?? throw new InvalidOperationException("Failed to retrieve created treatment plan");
    }

    public async Task<TreatmentPlan> UpdateTreatmentPlanAsync(TreatmentPlan plan)
    {
        var tenantId = _tenantProvider.TenantId;
        if (string.IsNullOrEmpty(tenantId))
            throw new InvalidOperationException("Tenant ID is not available");

        // Verify the treatment plan exists and belongs to the tenant
        var existingPlan = await _context.TreatmentPlans
            .Include(tp => tp.PlannedProcedures)
            .Where(tp => tp.TenantId == tenantId && tp.TreatmentPlanId == plan.TreatmentPlanId)
            .FirstOrDefaultAsync();

        if (existingPlan == null)
            throw new InvalidOperationException("Treatment plan not found or access denied");

        // Update treatment plan properties
        existingPlan.ProviderId = plan.ProviderId;
        existingPlan.Status = plan.Status;
        existingPlan.Title = plan.Title;
        existingPlan.Description = plan.Description;
        existingPlan.PresentedDate = NormalizeToUtc(plan.PresentedDate);
        existingPlan.AcceptedDate = NormalizeToUtc(plan.AcceptedDate);
        existingPlan.CompletedDate = NormalizeToUtc(plan.CompletedDate);
        existingPlan.ModifiedDate = DateTime.UtcNow;

        // Update planned procedures
        // Remove procedures that are no longer in the plan
        var proceduresToRemove = existingPlan.PlannedProcedures
            .Where(existingProc => !plan.PlannedProcedures.Any(p => p.PlannedProcedureId == existingProc.PlannedProcedureId))
            .ToList();
        
        foreach (var procedure in proceduresToRemove)
        {
            _context.PlannedProcedures.Remove(procedure);
        }

        // Add or update procedures
        foreach (var procedure in plan.PlannedProcedures)
        {
            if (procedure.PlannedProcedureId == 0)
            {
                // New procedure
                procedure.TenantId = tenantId;
                procedure.TreatmentPlanId = plan.TreatmentPlanId;
                procedure.CreatedDate = DateTime.UtcNow;
                existingPlan.PlannedProcedures.Add(procedure);
            }
            else
            {
                // Update existing procedure
                var existingProc = existingPlan.PlannedProcedures
                    .FirstOrDefault(p => p.PlannedProcedureId == procedure.PlannedProcedureId);
                
                if (existingProc != null)
                {
                    existingProc.CDTCode = procedure.CDTCode;
                    existingProc.Description = procedure.Description;
                    existingProc.ToothNumber = procedure.ToothNumber;
                    existingProc.Surface = procedure.Surface;
                    existingProc.EstimatedFee = procedure.EstimatedFee;
                    existingProc.Status = procedure.Status;
                    existingProc.CompletedDate = NormalizeToUtc(procedure.CompletedDate);
                    existingProc.ModifiedDate = DateTime.UtcNow;
                }
            }
        }

        await _context.SaveChangesAsync();

        // Reload with all navigation properties
        return await GetTreatmentPlanByIdAsync(plan.TreatmentPlanId.ToString()) 
               ?? throw new InvalidOperationException("Failed to retrieve updated treatment plan");
    }

    private static DateTime? NormalizeToUtc(DateTime? value)
    {
        if (!value.HasValue)
            return null;

        var dateValue = value.Value;
        if (dateValue.Kind == DateTimeKind.Local)
            return dateValue.ToUniversalTime();

        if (dateValue.Kind == DateTimeKind.Unspecified)
            return DateTime.SpecifyKind(dateValue, DateTimeKind.Local).ToUniversalTime();

        return dateValue;
    }
}
