using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CloudDentalOffice.Portal.Services.Tenancy;

public class HttpContextTenantProvider : ITenantProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextTenantProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    public string TenantId
    {
        get
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
            {
                return TenantConstants.DefaultTenantId;
            }

            var headerTenant = context.Request.Headers["X-Tenant"].FirstOrDefault()
                ?? context.Request.Headers["X-Tenant-Id"].FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(headerTenant))
            {
                return headerTenant.Trim();
            }

            var user = context.User;
            var claimTenant = user?.FindFirst("tenant_id")?.Value
                ?? user?.FindFirst("tenantId")?.Value
                ?? user?.FindFirst("tid")?.Value
                ?? user?.FindFirst("tenant")?.Value;

            if (!string.IsNullOrWhiteSpace(claimTenant))
            {
                return claimTenant.Trim();
            }

            return TenantConstants.DefaultTenantId;
        }
    }
}
