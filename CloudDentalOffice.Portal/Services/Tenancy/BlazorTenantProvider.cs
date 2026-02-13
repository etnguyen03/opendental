using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace CloudDentalOffice.Portal.Services.Tenancy;

/// <summary>
/// Scoped tenant provider service that caches tenant ID per request/circuit.
/// Initializes from AuthenticationState on first access and caches for the lifetime of the scope.
/// </summary>
public class BlazorTenantProvider : ITenantProvider
{
    private readonly IServiceProvider _serviceProvider;
    private string? _tenantId;
    private ClaimsPrincipal? _user;
    private bool _initialized;

    public BlazorTenantProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private void EnsureInitialized()
    {
        if (_initialized) return;

        try
        {
            // Get AuthenticationStateProvider from service provider to avoid circular dependency
            var authStateProvider = _serviceProvider.GetService<AuthenticationStateProvider>();
            if (authStateProvider != null)
            {
                var authStateTask = authStateProvider.GetAuthenticationStateAsync();
                if (authStateTask.IsCompleted || authStateTask.Wait(100))
                {
                    var authState = authStateTask.Result;
                    _user = authState.User;

                    if (_user?.Identity?.IsAuthenticated == true)
                    {
                        var claimTenant = _user.FindFirst("tenant_id")?.Value
                            ?? _user.FindFirst("tenantId")?.Value
                            ?? _user.FindFirst("tid")?.Value
                            ?? _user.FindFirst("tenant")?.Value;

                        _tenantId = !string.IsNullOrWhiteSpace(claimTenant)
                            ? claimTenant.Trim()
                            : TenantConstants.DefaultTenantId;
                    }
                    else
                    {
                        _tenantId = TenantConstants.DefaultTenantId;
                    }
                }
                else
                {
                    _tenantId = TenantConstants.DefaultTenantId;
                    _user = new ClaimsPrincipal(new ClaimsIdentity());
                }
            }
            else
            {
                _tenantId = TenantConstants.DefaultTenantId;
                _user = new ClaimsPrincipal(new ClaimsIdentity());
            }
        }
        catch
        {
            _tenantId = TenantConstants.DefaultTenantId;
            _user = new ClaimsPrincipal(new ClaimsIdentity());
        }

        _initialized = true;
    }

    public ClaimsPrincipal? User
    {
        get
        {
            EnsureInitialized();
            return _user;
        }
    }

    public string TenantId
    {
        get
        {
            EnsureInitialized();
            return _tenantId ?? TenantConstants.DefaultTenantId;
        }
    }
}
