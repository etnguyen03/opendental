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

public class BillingService : IBillingService
{
    public Task<List<Invoice>> GetInvoicesAsync(DateTime startDate, DateTime endDate) => Task.FromResult(new List<Invoice>());
    public Task<Invoice?> GetInvoiceByIdAsync(string invoiceId) => Task.FromResult<Invoice?>(null);
    public Task<BillingStatement> GenerateStatementAsync(string patientId, DateTime date) => Task.FromResult(new BillingStatement());
}
