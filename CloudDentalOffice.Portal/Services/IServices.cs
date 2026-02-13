namespace CloudDentalOffice.Portal.Services;

using CloudDentalOffice.Portal.Models;

// Service Interfaces for dependency injection

public interface IPatientService
{
    Task<List<Patient>> GetPatientsAsync();
    Task<Patient?> GetPatientByIdAsync(string patientId);
    Task<Patient> CreatePatientAsync(Patient patient);
    Task<Patient> UpdatePatientAsync(Patient patient);
    Task DeletePatientAsync(string patientId);
}

public interface IAppointmentService
{
    Task<List<Appointment>> GetAppointmentsAsync(DateTime date);
    Task<Appointment?> GetAppointmentByIdAsync(string appointmentId);
    Task<Appointment> CreateAppointmentAsync(Appointment appointment);
    Task<Appointment> UpdateAppointmentAsync(Appointment appointment);
    Task DeleteAppointmentAsync(string appointmentId);
}

public interface ITreatmentPlanService
{
    Task<List<TreatmentPlan>> GetAllTreatmentPlansAsync();
    Task<List<TreatmentPlan>> GetTreatmentPlansAsync(string patientId);
    Task<TreatmentPlan?> GetTreatmentPlanByIdAsync(string treatmentPlanId);
    Task<TreatmentPlan> CreateTreatmentPlanAsync(TreatmentPlan plan);
    Task<TreatmentPlan> UpdateTreatmentPlanAsync(TreatmentPlan plan);
}

public interface IClaimService
{
    Task<List<Claim>> GetClaimsAsync();
    Task<Claim?> GetClaimByIdAsync(string claimId);
    Task<Claim> CreateClaimAsync(Claim claim);
    Task<Claim> UpdateClaimStatusAsync(string claimId, string status);
    Task<Claim> SubmitClaimAsync(string claimId);
}

public interface IProviderService
{
    Task<List<Provider>> GetProvidersAsync();
    Task<Provider?> GetProviderByIdAsync(string providerId);
    Task<Provider> CreateProviderAsync(Provider provider);
    Task<Provider> UpdateProviderAsync(Provider provider);
}

public interface IProcedureCodeService
{
    Task<List<ProcedureCode>> SearchProcedureCodesAsync(string searchTerm);
    Task<ProcedureCode?> GetProcedureCodeByCodeAsync(string code);
    Task<List<ProcedureCode>> GetAllProcedureCodesAsync();
    Task<ProcedureCode> CreateProcedureCodeAsync(ProcedureCode procedureCode);
}

public interface IBillingService
{
    Task<List<Invoice>> GetInvoicesAsync(DateTime startDate, DateTime endDate);
    Task<Invoice?> GetInvoiceByIdAsync(string invoiceId);
    Task<BillingStatement> GenerateStatementAsync(string patientId, DateTime date);
}

// Simple DTO classes for services that don't have full entity models yet

public class Invoice
{
    public string InvoiceId { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal Balance { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class BillingStatement
{
    public string StatementId { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public DateTime StatementDate { get; set; }
    public decimal TotalCharges { get; set; }
    public decimal TotalPayments { get; set; }
    public decimal Balance { get; set; }
}
