using System.Security.Claims;

namespace CloudDentalOffice.Portal.Services.Tenancy;

public class DefaultTenantProvider : ITenantProvider
{
    public string TenantId => TenantConstants.DefaultTenantId;
    public ClaimsPrincipal? User => null;
}
