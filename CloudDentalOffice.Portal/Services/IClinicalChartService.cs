using CloudDentalOffice.Portal.Models;

namespace CloudDentalOffice.Portal.Services;

public interface IClinicalChartService
{
    Task<List<CompletedProcedureDto>> GetCompletedProceduresAsync(int patientId);
    Task<List<PlannedProcedure>> GetPlannedProceduresAsync(int patientId);
    Task<List<ClinicalNoteDto>> GetClinicalNotesAsync(int patientId);
    Task<ClinicalNoteDto> AddClinicalNoteAsync(int patientId, string noteText);
    Task<PatientMedicalInfoDto> GetPatientMedicalInfoAsync(int patientId);
    Task<Dictionary<string, List<ToothProcedureDto>>> GetToothChartDataAsync(int patientId);
    Task<Procedure> CreateProcedureAsync(Procedure procedure);
    Task<Procedure?> GetProcedureByIdAsync(int procedureId);
}

public class CompletedProcedureDto
{
    public int ProcedureId { get; set; }
    public DateTime ServiceDate { get; set; }
    public string CDTCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ToothNumber { get; set; }
    public string? Surface { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public decimal ChargeAmount { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class ClinicalNoteDto
{
    public int NoteId { get; set; }
    public DateTime NoteDate { get; set; }
    public string NoteText { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public string NoteType { get; set; } = "Clinical"; // Clinical, Alert, Condition
}

public class PatientMedicalInfoDto
{
    public List<string> Allergies { get; set; } = new();
    public List<string> MedicalConditions { get; set; } = new();
    public List<string> Medications { get; set; } = new();
    public string BloodPressure { get; set; } = string.Empty;
    public int? HeartRate { get; set; }
    public decimal? Temperature { get; set; }
}

public class ToothProcedureDto
{
    public string CDTCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty; // Completed, Planned, Existing
    public string Color { get; set; } = "#00ffff"; // Color code for display
    public DateTime? ServiceDate { get; set; }
}
