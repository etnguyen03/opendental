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
    private ClaimsPrincipal? _cachedUser;
    private string? _cachedTenantId;

    public BlazorTenantProvider(AuthenticationStateProvider authStateProvider)
    {
        _authStateProvider = authStateProvider;
    }

    public ClaimsPrincipal? User
    {
        get
        {
            if (_cachedUser == null)
            {
                // Synchronously get the user from the current async context
                var task = _authStateProvider.GetAuthenticationStateAsync();
                if (task.IsCompleted)
                {
                    _cachedUser = task.Result.User;
                }
                else
                {
                    // If not completed, this is likely during pre-rendering
                    _cachedUser = new ClaimsPrincipal(new ClaimsIdentity());
                }
            }
            return _cachedUser;
        }
    }

    public string TenantId
    {
        get
        {
            if (_cachedTenantId != null)
            {
                return _cachedTenantId;
            }

            var user = User;
            if (user == null || !user.Identity?.IsAuthenticated == true)
            {
                _cachedTenantId = TenantConstants.DefaultTenantId;
                return _cachedTenantId;
            }

            // Look for tenant claim in order of preference
            var claimTenant = user.FindFirst("tenant_id")?.Value
                ?? user.FindFirst("tenantId")?.Value
                ?? user.FindFirst("tid")?.Value
                ?? user.FindFirst("tenant")?.Value;

            _cachedTenantId = !string.IsNullOrWhiteSpace(claimTenant) 
                ? claimTenant.Trim() 
                : TenantConstants.DefaultTenantId;

            return _cachedTenantId;
        }
    }

    /// <summary>
    /// Clear cached values when authentication state changes (login/logout)
    /// </summary>
    public void ClearCache()
    {
        _cachedUser = null;
        _cachedTenantId = null;
    }
}
