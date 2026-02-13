using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Appointment service implementation with EF Core
/// </summary>
public class AppointmentServiceImpl : IAppointmentService
{
    private readonly CloudDentalDbContext _context;
    private readonly ILogger<AppointmentServiceImpl> _logger;

    public AppointmentServiceImpl(CloudDentalDbContext context, ILogger<AppointmentServiceImpl> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Appointment>> GetAppointmentsAsync(DateTime date)
    {
        try
        {
            // Get appointments for the specific date
            // Assuming appointments store full DateTime, we compare Date part
            var targetDate = date.Date;
            var nextDate = targetDate.AddDays(1);

            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Provider)
                .Where(a => a.AppointmentDateTime >= targetDate && a.AppointmentDateTime < nextDate)
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
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Provider)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
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
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating appointment");
            throw;
        }
    }

    public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
    {
        try
        {
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return appointment;
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
            var appointment = await _context.Appointments.FindAsync(id);
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
}
