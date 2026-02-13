using System.Security.Claims;
using CloudDentalOffice.Portal.Services;
using CloudDentalOffice.Portal.Services.Tenancy;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;

namespace CloudDentalOffice.Portal.Services.Auth;

public class PortalAuthStateProvider : AuthenticationStateProvider
{
    private readonly ProtectedLocalStorage _localStorage;
    private readonly ITenantProvider _tenantProvider;
    
    public PortalAuthStateProvider(ProtectedLocalStorage localStorage, ITenantProvider tenantProvider)
    {
        _localStorage = localStorage;
        _tenantProvider = tenantProvider;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var result = await _localStorage.GetAsync<string>("authToken");
            var token = result.Success ? result.Value : null;

            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                await _localStorage.DeleteAsync("authToken");
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var identity = new ClaimsIdentity(jwtToken.Claims, "JwtAuth");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        catch
        {
            // Fallback for pre-rendering or errors
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }

    public async Task LoginAsync(string token)
    {
        await _localStorage.SetAsync("authToken", token);
        
        // Clear tenant cache to force reload from new token
        if (_tenantProvider is BlazorTenantProvider blazorProvider)
        {
            blazorProvider.ClearCache();
        }
        
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await _localStorage.DeleteAsync("authToken");
        
        // Clear tenant cache on logout
        if (_tenantProvider is BlazorTenantProvider blazorProvider)
        {
            blazorProvider.ClearCache();
        }
        
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
