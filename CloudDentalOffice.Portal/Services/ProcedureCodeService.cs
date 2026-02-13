using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Procedure code service implementation with EF Core
/// </summary>
public class ProcedureCodeServiceImpl : IProcedureCodeService
{
    private readonly CloudDentalDbContext _context;
    private readonly ILogger<ProcedureCodeServiceImpl> _logger;

    public ProcedureCodeServiceImpl(CloudDentalDbContext context, ILogger<ProcedureCodeServiceImpl> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<ProcedureCode>> SearchProcedureCodesAsync(string searchTerm)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.ProcedureCodes
                    .Where(p => p.IsActive)
                    .OrderBy(p => p.Code)
                    .Take(50)
                    .ToListAsync();
            }

            searchTerm = searchTerm.ToLower();

            return await _context.ProcedureCodes
                .Where(p => p.IsActive && 
                    (p.Code.ToLower().Contains(searchTerm) || 
                     p.Description.ToLower().Contains(searchTerm) ||
                     (p.AbbrDesc != null && p.AbbrDesc.ToLower().Contains(searchTerm))))
                .OrderBy(p => p.Code)
                .Take(50)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching procedure codes with term: {SearchTerm}", searchTerm);
            return new List<ProcedureCode>();
        }
    }

    public async Task<ProcedureCode?> GetProcedureCodeByCodeAsync(string code)
    {
        try
        {
            return await _context.ProcedureCodes
                .FirstOrDefaultAsync(p => p.Code == code && p.IsActive);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving procedure code: {Code}", code);
            return null;
        }
    }

    public async Task<List<ProcedureCode>> GetAllProcedureCodesAsync()
    {
        try
        {
            return await _context.ProcedureCodes
                .Where(p => p.IsActive)
                .OrderBy(p => p.Code)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all procedure codes");
            return new List<ProcedureCode>();
        }
    }

    public async Task<ProcedureCode> CreateProcedureCodeAsync(ProcedureCode procedureCode)
    {
        try
        {
            procedureCode.CreatedDate = DateTime.UtcNow;
            _context.ProcedureCodes.Add(procedureCode);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Created procedure code {Code}", procedureCode.Code);
            return procedureCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating procedure code");
            throw;
        }
    }
}
