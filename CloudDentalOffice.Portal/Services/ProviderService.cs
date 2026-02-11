using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Provider service implementation with EF Core
/// </summary>
public class ProviderServiceImpl : IProviderService
{
    private readonly CloudDentalDbContext _context;
    private readonly ILogger<ProviderServiceImpl> _logger;

    public ProviderServiceImpl(CloudDentalDbContext context, ILogger<ProviderServiceImpl> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Provider>> GetProvidersAsync()
    {
        try
        {
            return await _context.Providers
                .Where(p => p.IsActive)
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving providers");
            return new List<Provider>();
        }
    }

    public async Task<Provider?> GetProviderByIdAsync(string providerId)
    {
        if (!int.TryParse(providerId, out var id))
            return null;

        try
        {
            return await _context.Providers
                .FirstOrDefaultAsync(p => p.ProviderId == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving provider {ProviderId}", providerId);
            return null;
        }
    }

    public async Task<Provider> CreateProviderAsync(Provider provider)
    {
        try
        {
            provider.CreatedDate = DateTime.UtcNow;
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Created provider {ProviderName}", provider.FullName);
            return provider;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating provider");
            throw;
        }
    }

    public async Task<Provider> UpdateProviderAsync(Provider provider)
    {
        try
        {
            _context.Providers.Update(provider);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Updated provider {ProviderName}", provider.FullName);
            return provider;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating provider {ProviderId}", provider.ProviderId);
            throw;
        }
    }
}
