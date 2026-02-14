using CloudDentalOffice.Portal.Models;
using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Services.Tenancy;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

public class ClinicalChartService : IClinicalChartService
{
    private readonly CloudDentalDbContext _context;
    private readonly ITenantProvider _tenantProvider;

    public ClinicalChartService(CloudDentalDbContext context, ITenantProvider tenantProvider)
    {
        _context = context;
        _tenantProvider = tenantProvider;
    }

    public async Task<List<CompletedProcedureDto>> GetCompletedProceduresAsync(int patientId)
    {
        var tenantId = _tenantProvider.TenantId;

        // Get completed procedures from Procedures table
        var completedProcs = await _context.Procedures
            .Include(p => p.Provider)
            .Where(p => p.TenantId == tenantId && p.PatientId == patientId)
            .Select(p => new CompletedProcedureDto
            {
                ProcedureId = p.ProcedureId,
                ServiceDate = p.ServiceDate,
                CDTCode = p.CDTCode,
                Description = p.Description,
                ToothNumber = p.ToothNumber,
                Surface = p.Surface,
                ProviderName = p.Provider.FullName,
                ChargeAmount = p.ChargeAmount,
                Status = p.Status
            })
            .OrderByDescending(p => p.ServiceDate)
            .ToListAsync();

        return completedProcs;
    }

    public async Task<List<PlannedProcedure>> GetPlannedProceduresAsync(int patientId)
    {
        var tenantId = _tenantProvider.TenantId;

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
        var tenantId = _tenantProvider.TenantId;

        var notes = await _context.ClinicalNotes
            .Include(cn => cn.Provider)
            .Where(cn => cn.TenantId == tenantId && cn.PatientId == patientId)
            .Select(cn => new ClinicalNoteDto
            {
                NoteId = cn.ClinicalNoteId,
                NoteDate = cn.NoteDate,
                NoteText = cn.NoteText,
                CreatedBy = cn.Provider != null ? cn.Provider.FullName : (cn.CreatedBy ?? "Unknown"),
                NoteType = cn.NoteType
            })
            .OrderByDescending(cn => cn.NoteDate)
            .ToListAsync();

        return notes;
    }

    public async Task<ClinicalNoteDto> AddClinicalNoteAsync(int patientId, string noteText)
    {
        var tenantId = _tenantProvider.TenantId;

        var newNote = new ClinicalNote
        {
            TenantId = tenantId,
            PatientId = patientId,
            NoteDate = DateTime.UtcNow,
            NoteText = noteText,
            NoteType = "Clinical",
            CreatedBy = "Current User", // TODO: Get from auth context
            CreatedDate = DateTime.UtcNow
        };

        _context.ClinicalNotes.Add(newNote);
        await _context.SaveChangesAsync();

        return new ClinicalNoteDto
        {
            NoteId = newNote.ClinicalNoteId,
            NoteDate = newNote.NoteDate,
            NoteText = newNote.NoteText,
            CreatedBy = newNote.CreatedBy ?? "Unknown",
            NoteType = newNote.NoteType
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
        var tenantId = _tenantProvider.TenantId;
        var toothData = new Dictionary<string, List<ToothProcedureDto>>();

        // Get completed procedures from Procedures table grouped by tooth
        var completedByTooth = await _context.Procedures
            .Where(p => p.TenantId == tenantId &&
                        p.PatientId == patientId &&
                        !string.IsNullOrEmpty(p.ToothNumber))
            .GroupBy(p => p.ToothNumber!)
            .Select(g => new
            {
                ToothNumber = g.Key,
                Procedures = g.Select(p => new ToothProcedureDto
                {
                    CDTCode = p.CDTCode,
                    Description = p.Description,
                    Status = "Completed",
                    Color = "#00ff00",
                    ServiceDate = p.ServiceDate
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

    public async Task<Procedure> CreateProcedureAsync(Procedure procedure)
    {
        var tenantId = _tenantProvider.TenantId;
        procedure.TenantId = tenantId;
        procedure.CreatedDate = DateTime.UtcNow;
        procedure.ServiceDate = NormalizeToUtc(procedure.ServiceDate);

        _context.Procedures.Add(procedure);
        await _context.SaveChangesAsync();

        return procedure;
    }

    public async Task<Procedure?> GetProcedureByIdAsync(int procedureId)
    {
        var tenantId = _tenantProvider.TenantId;

        return await _context.Procedures
            .Include(p => p.Patient)
            .Include(p => p.Provider)
            .FirstOrDefaultAsync(p => p.TenantId == tenantId && p.ProcedureId == procedureId);
    }

    private static DateTime NormalizeToUtc(DateTime value)
    {
        if (value.Kind == DateTimeKind.Local)
            return value.ToUniversalTime();

        if (value.Kind == DateTimeKind.Unspecified)
            return DateTime.SpecifyKind(value, DateTimeKind.Local).ToUniversalTime();

        return value;
    }
}
