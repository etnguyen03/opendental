using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace CloudDentalOffice.Portal.Services.Tenancy;

/// <summary>
/// Blazor Server-compatible tenant provider that retrieves tenant ID from authenticated user claims.
/// Unlike HttpContextTenantProvider, this works during SignalR reconnections.
/// </summary>
public class BlazorTenantProvider : ITenantProvider
{
    private readonly AuthenticationStateProvider _authStateProvider;
    private string? _tenantId;
    private ClaimsPrincipal? _user;
    private bool _initialized;

    public BlazorTenantProvider(AuthenticationStateProvider authStateProvider)
    {
        _authStateProvider = authStateProvider;
    }

    private void EnsureInitialized()
    {
        if (_initialized) return;

        // Get authentication state synchronously - this works because the state
        // is already loaded by the time components render
        var authStateTask = _authStateProvider.GetAuthenticationStateAsync();
        if (authStateTask.IsCompleted)
        {
            var authState = authStateTask.Result;
            _user = authState.User;
            
            if (_user?.Identity?.IsAuthenticated == true)
            {
                // Extract tenant from claims
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
            // During pre-rendering, default to dev tenant
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
