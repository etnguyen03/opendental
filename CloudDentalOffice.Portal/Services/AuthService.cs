using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;
using CloudDentalOffice.Portal.Services.Tenancy;

namespace CloudDentalOffice.Portal.Services;

public interface IAuthService
{
    Task<string?> LoginAsync(string email, string password);
    Task<bool> RegisterAsync(RegistrationRequest request);
}

public class RegistrationRequest
{
    public string TenantName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PlanId { get; set; } = "price_hobby";
}

public class AuthService : IAuthService
{
    private readonly CloudDentalDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IStripeService _stripeService;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        CloudDentalDbContext context,
        ITokenService tokenService,
        IStripeService stripeService,
        ILogger<AuthService> logger)
    {
        _context = context;
        _tokenService = tokenService;
        _stripeService = stripeService;
        _logger = logger;
    }

    public async Task<string?> LoginAsync(string email, string password)
    {
        // Must ignore query filters to find user regardless of current "default" context
        var user = await _context.Users
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return null;
        }

        // Generate token
        return _tokenService.GenerateToken(user.Id.ToString(), user.Email, user.TenantId);
    }

    public async Task<bool> RegisterAsync(RegistrationRequest request)
    {
        var exists = await _context.Users
            .IgnoreQueryFilters()
            .AnyAsync(u => u.Email == request.Email);

        if (exists)
        {
            _logger.LogWarning("Registration failed: Email {Email} already exists.", request.Email);
            return false;
        }

        var tenantId = Guid.NewGuid().ToString();

        // 1. Create Tenant
        var tenant = new TenantRegistry
        {
            TenantId = tenantId,
            Name = request.TenantName,
            Plan = request.PlanId,
            IsActive = true
        };

        // 2. Create User
        var user = new User
        {
            TenantId = tenantId, // Explicitly set tenant
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "Admin"
        };

        // 3. Create Stripe Customer (integration)
        try
        {
            var customerId = await _stripeService.CreateCustomerAsync(request.TenantName, request.Email, tenantId);
            tenant.StripeCustomerId = customerId;

            if (!string.IsNullOrEmpty(request.PlanId) && customerId != "dummy_stripe_customer_id")
            {
               var subId = await _stripeService.CreateSubscriptionAsync(customerId, request.PlanId);
               tenant.StripeSubscriptionId = subId;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Stripe creation failed during registration. Proceeding with DB creation.");
            // Continue - we can retry stripe later or require it
        }

        _context.Tenants.Add(tenant);
        _context.Users.Add(user);

        // 4. Seed default providers for new tenant
        var defaultProviders = new List<Provider>
        {
            new Provider 
            { 
                TenantId = tenantId,
                NPI = "1234567890",
                FirstName = "John", 
                LastName = "Smith", 
                Suffix = "DDS",
                Specialty = "General Dentistry",
                LicenseNumber = "D12345",
                LicenseState = "CA",
                Email = "jsmith@example.com",
                Phone = "555-0101",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            },
            new Provider 
            { 
                TenantId = tenantId,
                NPI = "2345678901",
                FirstName = "Sarah", 
                LastName = "Johnson", 
                Suffix = "DMD",
                Specialty = "Pediatric Dentistry",
                LicenseNumber = "D23456",
                LicenseState = "CA",
                Email = "sjohnson@example.com",
                Phone = "555-0102",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            },
            new Provider 
            { 
                TenantId = tenantId,
                NPI = "3456789012",
                FirstName = "Michael", 
                LastName = "Chen", 
                Suffix = "DDS",
                Specialty = "Oral Surgery",
                LicenseNumber = "D34567",
                LicenseState = "CA",
                Email = "mchen@example.com",
                Phone = "555-0103",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            },
            new Provider 
            { 
                TenantId = tenantId,
                NPI = "4567890123",
                FirstName = "Emily", 
                LastName = "Rodriguez", 
                Suffix = "DMD",
                Specialty = "Endodontics",
                LicenseNumber = "D45678",
                LicenseState = "CA",
                Email = "erodriguez@example.com",
                Phone = "555-0104",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            }
        };

        _context.Providers.AddRange(defaultProviders);

        await _context.SaveChangesAsync();
        
        _logger.LogInformation("Created new tenant {TenantId} with {ProviderCount} default providers", tenantId, defaultProviders.Count);
        
        return true;
    }
}
