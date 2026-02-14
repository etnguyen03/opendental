using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using CloudDentalOffice.Portal.Services.Tenancy;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Appointment service implementation with EF Core
/// </summary>
public class AppointmentServiceImpl : IAppointmentService
{
    private readonly CloudDentalDbContext _context;
    private readonly ITenantProvider _tenantProvider;
    private readonly ILogger<AppointmentServiceImpl> _logger;

    public AppointmentServiceImpl(CloudDentalDbContext context, ITenantProvider tenantProvider, ILogger<AppointmentServiceImpl> logger)
    {
        _context = context;
        _tenantProvider = tenantProvider;
        _logger = logger;
    }

    public async Task<List<Appointment>> GetAppointmentsAsync(DateTime date)
    {
        try
        {
            var tenantId = _tenantProvider.TenantId;
            if (string.IsNullOrEmpty(tenantId))
                throw new InvalidOperationException("Tenant ID is not available");

            // Get appointments for the specific date
            // Assuming appointments store full DateTime, we compare Date part
            var localStart = DateTime.SpecifyKind(date.Date, DateTimeKind.Local);
            var utcStart = localStart.ToUniversalTime();
            var utcEnd = localStart.AddDays(1).ToUniversalTime();

            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Provider)
                .Where(a => a.TenantId == tenantId && a.AppointmentDateTime >= utcStart && a.AppointmentDateTime < utcEnd)
                .OrderBy(a => a.AppointmentDateTime)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving appointments for date {Date}", date);
            return new List<Appointment>();
        }
    }

    public async Task<Appointment?> GetAppointmentByIdAsync(string appointmentId)
    {
        if (!int.TryParse(appointmentId, out var id))
            return null;

        try
        {
            var tenantId = _tenantProvider.TenantId;
            if (string.IsNullOrEmpty(tenantId))
                throw new InvalidOperationException("Tenant ID is not available");

            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Provider)
                .FirstOrDefaultAsync(a => a.TenantId == tenantId && a.AppointmentId == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving appointment {AppointmentId}", appointmentId);
            return null;
        }
    }

    public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
    {
        try
        {
            var tenantId = _tenantProvider.TenantId;
            _logger.LogInformation("Creating appointment for tenant: {TenantId}, Patient: {PatientId}, Provider: {ProviderId}", 
                tenantId, appointment.PatientId, appointment.ProviderId);
            
            if (string.IsNullOrEmpty(tenantId))
            {
                _logger.LogError("Tenant ID is not available when creating appointment");
                throw new InvalidOperationException("Tenant ID is not available");
            }

            appointment.TenantId = tenantId;
            appointment.CreatedDate = DateTime.UtcNow;
            
            appointment.AppointmentDateTime = NormalizeToUtc(appointment.AppointmentDateTime);

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Appointment created successfully with ID: {AppointmentId}", appointment.AppointmentId);

            // Reload with navigation properties
            var createdAppointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Provider)
                .FirstOrDefaultAsync(a => a.AppointmentId == appointment.AppointmentId && a.TenantId == tenantId);

            if (createdAppointment == null)
            {
                _logger.LogError("Failed to reload appointment {AppointmentId} after creation", appointment.AppointmentId);
                throw new InvalidOperationException("Failed to retrieve created appointment");
            }

            return createdAppointment;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating appointment for Patient {PatientId}, Provider {ProviderId}", 
                appointment.PatientId, appointment.ProviderId);
            throw;
        }
    }

    public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
    {
        try
        {
            var tenantId = _tenantProvider.TenantId;
            if (string.IsNullOrEmpty(tenantId))
                throw new InvalidOperationException("Tenant ID is not available");

            var existingAppointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.TenantId == tenantId && a.AppointmentId == appointment.AppointmentId);

            if (existingAppointment == null)
                throw new InvalidOperationException("Appointment not found or access denied");

            existingAppointment.PatientId = appointment.PatientId;
            existingAppointment.ProviderId = appointment.ProviderId;
            
            existingAppointment.AppointmentDateTime = NormalizeToUtc(appointment.AppointmentDateTime);
            
            existingAppointment.DurationMinutes = appointment.DurationMinutes;
            existingAppointment.AppointmentType = appointment.AppointmentType;
            existingAppointment.Status = appointment.Status;
            existingAppointment.Notes = appointment.Notes;
            existingAppointment.ReasonForVisit = appointment.ReasonForVisit;
            existingAppointment.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Reload with navigation properties
            return await GetAppointmentByIdAsync(appointment.AppointmentId.ToString()) 
                   ?? throw new InvalidOperationException("Failed to retrieve updated appointment");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating appointment {AppointmentId}", appointment.AppointmentId);
            throw;
        }
    }

    public async Task DeleteAppointmentAsync(string appointmentId)
    {
        if (!int.TryParse(appointmentId, out var id))
            return;

        try
        {
            var tenantId = _tenantProvider.TenantId;
            if (string.IsNullOrEmpty(tenantId))
                throw new InvalidOperationException("Tenant ID is not available");

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.TenantId == tenantId && a.AppointmentId == id);

            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting appointment {AppointmentId}", appointmentId);
            throw;
        }
    }

    private static DateTime NormalizeToUtc(DateTime value)
    {
        // UI inputs are local time with Kind=Unspecified, so treat as local then convert
        if (value.Kind == DateTimeKind.Local)
            return value.ToUniversalTime();

        if (value.Kind == DateTimeKind.Unspecified)
            return DateTime.SpecifyKind(value, DateTimeKind.Local).ToUniversalTime();

        return value;
    }
}
