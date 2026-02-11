using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Patient service implementation with EF Core
/// </summary>
public class PatientServiceImpl : IPatientService
{
    private readonly CloudDentalDbContext _context;
    private readonly ILogger<PatientServiceImpl> _logger;

    public PatientServiceImpl(CloudDentalDbContext context, ILogger<PatientServiceImpl> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Models.Patient>> GetPatientsAsync()
    {
        try
        {
            return await _context.Patients
                .Include(p => p.Insurances)
                    .ThenInclude(pi => pi.InsurancePlan)
                .Where(p => p.Status != "Archived")
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving patients");
            return new List<Models.Patient>();
        }
    }

    public async Task<Models.Patient?> GetPatientByIdAsync(string patientId)
    {
        if (!int.TryParse(patientId, out var id))
            return null;

        try
        {
            return await _context.Patients
                .Include(p => p.Insurances)
                    .ThenInclude(pi => pi.InsurancePlan)
                .FirstOrDefaultAsync(p => p.PatientId == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving patient {PatientId}", patientId);
            return null;
        }
    }

    public async Task<Models.Patient> CreatePatientAsync(Models.Patient patient)
    {
        try
        {
            patient.CreatedDate = DateTime.UtcNow;
            patient.Status = "Active";

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Created patient {PatientId}: {Name}", patient.PatientId, patient.FullName);
            return patient;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating patient: {Name}", $"{patient.FirstName} {patient.LastName}");
            throw;
        }
    }

    public async Task<Models.Patient> UpdatePatientAsync(Models.Patient patient)
    {
        try
        {
            patient.ModifiedDate = DateTime.UtcNow;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Updated patient {PatientId}: {Name}", patient.PatientId, patient.FullName);
            return patient;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating patient {PatientId}", patient.PatientId);
            throw;
        }
    }

    public async Task DeletePatientAsync(string patientId)
    {
        if (!int.TryParse(patientId, out var id))
            return;

        try
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                // Soft delete
                patient.Status = "Archived";
                patient.ModifiedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Archived patient {PatientId}: {Name}", patient.PatientId, patient.FullName);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting patient {PatientId}", patientId);
            throw;
        }
    }
}
