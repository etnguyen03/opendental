using System.Security.Claims;

namespace CloudDentalOffice.Portal.Services.Tenancy;

public interface ITenantProvider
{
    string TenantId { get; }
    ClaimsPrincipal? User { get; }
}
