using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using CloudDentalOffice.Portal.Services.Tenancy;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Services;

/// <summary>
/// Provider service implementation with EF Core
/// </summary>
public class ProviderServiceImpl : IProviderService
{
    private readonly CloudDentalDbContext _context;
    private readonly ITenantProvider _tenantProvider;
    private readonly ILogger<ProviderServiceImpl> _logger;

    public ProviderServiceImpl(CloudDentalDbContext context, ITenantProvider tenantProvider, ILogger<ProviderServiceImpl> logger)
    {
        _context = context;
        _tenantProvider = tenantProvider;
        _logger = logger;
    }

    public async Task<List<Provider>> GetProvidersAsync()
    {
        try
        {
            var tenantId = _tenantProvider.TenantId;
            _logger.LogInformation("Loading providers for tenant: {TenantId}", tenantId);
            
            if (string.IsNullOrEmpty(tenantId))
            {
                _logger.LogWarning("Tenant ID is not available when loading providers");
                throw new InvalidOperationException("Tenant ID is not available");
            }

            var providers = await _context.Providers
                .Where(p => p.TenantId == tenantId && p.IsActive)
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToListAsync();
            
            _logger.LogInformation("Found {Count} active providers for tenant {TenantId}", providers.Count, tenantId);
            return providers;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving providers for tenant {TenantId}", _tenantProvider.TenantId);
            return new List<Provider>();
        }
    }

    public async Task<Provider?> GetProviderByIdAsync(string providerId)
    {
        if (!int.TryParse(providerId, out var id))
            return null;

        try
        {
            var tenantId = _tenantProvider.TenantId;
            if (string.IsNullOrEmpty(tenantId))
                throw new InvalidOperationException("Tenant ID is not available");

            return await _context.Providers
                .FirstOrDefaultAsync(p => p.TenantId == tenantId && p.ProviderId == id);
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
            var tenantId = _tenantProvider.TenantId;
            if (string.IsNullOrEmpty(tenantId))
                throw new InvalidOperationException("Tenant ID is not available");

            provider.TenantId = tenantId;
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
            var tenantId = _tenantProvider.TenantId;
            if (string.IsNullOrEmpty(tenantId))
                throw new InvalidOperationException("Tenant ID is not available");

            var existingProvider = await _context.Providers
                .FirstOrDefaultAsync(p => p.TenantId == tenantId && p.ProviderId == provider.ProviderId);

            if (existingProvider == null)
                throw new InvalidOperationException("Provider not found or access denied");

            existingProvider.FirstName = provider.FirstName;
            existingProvider.MiddleName = provider.MiddleName;
            existingProvider.LastName = provider.LastName;
            existingProvider.Suffix = provider.Suffix;
            existingProvider.Specialty = provider.Specialty;
            existingProvider.NPI = provider.NPI;
            existingProvider.LicenseNumber = provider.LicenseNumber;
            existingProvider.LicenseState = provider.LicenseState;
            existingProvider.Phone = provider.Phone;
            existingProvider.Email = provider.Email;
            existingProvider.TaxId = provider.TaxId;
            existingProvider.IsActive = provider.IsActive;
            existingProvider.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Updated provider {ProviderName}", provider.FullName);
            return existingProvider;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating provider {ProviderId}", provider.ProviderId);
            throw;
        }
    }
}
