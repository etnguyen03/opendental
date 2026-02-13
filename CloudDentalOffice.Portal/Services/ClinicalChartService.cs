using CloudDentalOffice.Portal.Models;
using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Services;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

public class ClinicalChartService : IClinicalChartService
{
    private readonly PortalDbContext _context;
    private readonly ITenantService _tenantService;

    public ClinicalChartService(PortalDbContext context, ITenantService tenantService)
    {
        _context = context;
        _tenantService = tenantService;
    }

    public async Task<List<CompletedProcedureDto>> GetCompletedProceduresAsync(int patientId)
    {
        var tenantId = _tenantService.GetCurrentTenantId();

        // Get completed procedures from claims
        var completedProcs = await _context.ClaimProcedures
            .Where(cp => cp.TenantId == tenantId && 
                         cp.Claim.PatientId == patientId &&
                         (cp.Claim.Status == "Paid" || cp.Claim.Status == "Submitted"))
            .Select(cp => new CompletedProcedureDto
            {
                ProcedureId = cp.ClaimProcedureId,
                ServiceDate = cp.ServiceDate,
                CDTCode = cp.CDTCode,
                Description = cp.Description,
                ToothNumber = cp.ToothNumber,
                Surface = cp.Surface,
                ProviderName = cp.Claim.Provider != null ? cp.Claim.Provider.FullName : "Unknown",
                ChargeAmount = cp.ChargeAmount,
                Status = cp.Claim.Status ?? "Unknown"
            })
            .OrderByDescending(p => p.ServiceDate)
            .ToListAsync();

        return completedProcs;
    }

    public async Task<List<PlannedProcedure>> GetPlannedProceduresAsync(int patientId)
    {
        var tenantId = _tenantService.GetCurrentTenantId();

        var plannedProcs = await _context.PlannedProcedures
            .Include(pp => pp.TreatmentPlan)
            .Where(pp => pp.TenantId == tenantId &&
                         pp.TreatmentPlan.PatientId == patientId &&
                         pp.Status == "Planned")
            .OrderBy(pp => pp.SequenceNumber)
            .ToListAsync();

        return plannedProcs;
    }

    public async Task<List<ClinicalNoteDto>> GetClinicalNotesAsync(int patientId)
    {
        // For now, return mock data until we add a ClinicalNotes table
        await Task.CompletedTask;
        
        return new List<ClinicalNoteDto>
        {
            new ClinicalNoteDto
            {
                NoteId = 1,
                NoteDate = DateTime.Now.AddDays(-7),
                NoteText = "Patient presented with tooth sensitivity on #14. Recommended sensitivity toothpaste.",
                CreatedBy = "Dr. John Smith",
                NoteType = "Clinical"
            },
            new ClinicalNoteDto
            {
                NoteId = 2,
                NoteDate = DateTime.Now.AddDays(-30),
                NoteText = "Completed routine cleaning. No cavities detected. Excellent oral hygiene.",
                CreatedBy = "Dr. Sarah Johnson",
                NoteType = "Clinical"
            }
        };
    }

    public async Task<ClinicalNoteDto> AddClinicalNoteAsync(int patientId, string noteText)
    {
        // TODO: Implement actual note creation when ClinicalNotes table is added
        await Task.CompletedTask;
        
        return new ClinicalNoteDto
        {
            NoteId = new Random().Next(1000, 9999),
            NoteDate = DateTime.Now,
            NoteText = noteText,
            CreatedBy = "Current User",
            NoteType = "Clinical"
        };
    }

    public async Task<PatientMedicalInfoDto> GetPatientMedicalInfoAsync(int patientId)
    {
        // TODO: Get actual medical info from patient record
        await Task.CompletedTask;
        
        return new PatientMedicalInfoDto
        {
            Allergies = new List<string> { "Penicillin", "Latex" },
            MedicalConditions = new List<string> { "Hypertension", "Type 2 Diabetes" },
            Medications = new List<string> { "Lisinopril 10mg", "Metformin 500mg" },
            BloodPressure = "120/80",
            HeartRate = 72,
            Temperature = 98.6m
        };
    }

    public async Task<Dictionary<string, List<ToothProcedureDto>>> GetToothChartDataAsync(int patientId)
    {
        var tenantId = _tenantService.GetCurrentTenantId();
        var toothData = new Dictionary<string, List<ToothProcedureDto>>();

        // Get completed procedures grouped by tooth
        var completedByTooth = await _context.ClaimProcedures
            .Where(cp => cp.TenantId == tenantId &&
                         cp.Claim.PatientId == patientId &&
                         !string.IsNullOrEmpty(cp.ToothNumber))
            .GroupBy(cp => cp.ToothNumber!)
            .Select(g => new
            {
                ToothNumber = g.Key,
                Procedures = g.Select(cp => new ToothProcedureDto
                {
                    CDTCode = cp.CDTCode,
                    Description = cp.Description,
                    Status = "Completed",
                    Color = "#00ff00",
                    ServiceDate = cp.ServiceDate
                }).ToList()
            })
            .ToListAsync();

        foreach (var item in completedByTooth)
        {
            toothData[item.ToothNumber] = item.Procedures;
        }

        // Get planned procedures grouped by tooth
        var plannedByTooth = await _context.PlannedProcedures
            .Where(pp => pp.TenantId == tenantId &&
                         pp.TreatmentPlan.PatientId == patientId &&
                         !string.IsNullOrEmpty(pp.ToothNumber) &&
                         pp.Status == "Planned")
            .GroupBy(pp => pp.ToothNumber!)
            .Select(g => new
            {
                ToothNumber = g.Key,
                Procedures = g.Select(pp => new ToothProcedureDto
                {
                    CDTCode = pp.CDTCode,
                    Description = pp.Description,
                    Status = "Planned",
                    Color = "#ffff00",
                    ServiceDate = null
                }).ToList()
            })
            .ToListAsync();

        foreach (var item in plannedByTooth)
        {
            if (toothData.ContainsKey(item.ToothNumber))
            {
                toothData[item.ToothNumber].AddRange(item.Procedures);
            }
            else
            {
                toothData[item.ToothNumber] = item.Procedures;
            }
        }

        return toothData;
    }
}
