using CloudDentalOffice.Portal.Models;

namespace CloudDentalOffice.Portal.Services;

// Temporary mock implementations for services not yet fully implemented
// These will be replaced with actual database implementations

public class AppointmentService : IAppointmentService
{
    public Task<List<Appointment>> GetAppointmentsAsync(DateTime date) => Task.FromResult(new List<Appointment>());
    public Task<Appointment?> GetAppointmentByIdAsync(string appointmentId) => Task.FromResult<Appointment?>(null);
    public Task<Appointment> CreateAppointmentAsync(Appointment appointment) => Task.FromResult(appointment);
    public Task<Appointment> UpdateAppointmentAsync(Appointment appointment) => Task.FromResult(appointment);
    public Task DeleteAppointmentAsync(string appointmentId) => Task.CompletedTask;
}

public class TreatmentPlanService : ITreatmentPlanService
{
    public Task<List<TreatmentPlan>> GetTreatmentPlansAsync(string patientId) => Task.FromResult(new List<TreatmentPlan>());
    public Task<TreatmentPlan?> GetTreatmentPlanByIdAsync(string treatmentPlanId) => Task.FromResult<TreatmentPlan?>(null);
    public Task<TreatmentPlan> CreateTreatmentPlanAsync(TreatmentPlan plan) => Task.FromResult(plan);
    public Task<TreatmentPlan> UpdateTreatmentPlanAsync(TreatmentPlan plan) => Task.FromResult(plan);
}

public class ProviderService : IProviderService
{
    public Task<List<Provider>> GetProvidersAsync() => Task.FromResult(new List<Provider>());
    public Task<Provider?> GetProviderByIdAsync(string providerId) => Task.FromResult<Provider?>(null);
    public Task<Provider> CreateProviderAsync(Provider provider) => Task.FromResult(provider);
    public Task<Provider> UpdateProviderAsync(Provider provider) => Task.FromResult(provider);
}

public class BillingService : IBillingService
{
    public Task<List<Invoice>> GetInvoicesAsync(DateTime startDate, DateTime endDate) => Task.FromResult(new List<Invoice>());
    public Task<Invoice?> GetInvoiceByIdAsync(string invoiceId) => Task.FromResult<Invoice?>(null);
    public Task<BillingStatement> GenerateStatementAsync(string patientId, DateTime date) => Task.FromResult(new BillingStatement());
}
