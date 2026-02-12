using Stripe;

namespace CloudDentalOffice.Portal.Services;

public interface IStripeService
{
    Task<string> CreateCustomerAsync(string name, string email, string tenantId);
    Task<string> CreateSubscriptionAsync(string customerId, string priceId);
}

public class StripeService : IStripeService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<StripeService> _logger;

    public StripeService(IConfiguration configuration, ILogger<StripeService> logger)
    {
        _configuration = configuration;
        _logger = logger;
        
        // Initialize Stripe
        var apiKey = _configuration["Stripe:SecretKey"];
        if (!string.IsNullOrEmpty(apiKey))
        {
            StripeConfiguration.ApiKey = apiKey;
        }
    }

    public async Task<string> CreateCustomerAsync(string name, string email, string tenantId)
    {
        if (string.IsNullOrEmpty(StripeConfiguration.ApiKey))
        {
            _logger.LogWarning("Stripe API Key is missing. Skipping customer creation.");
            return "dummy_stripe_customer_id"; // For dev/testing
        }

        var options = new CustomerCreateOptions
        {
            Name = name,
            Email = email,
            Metadata = new Dictionary<string, string>
            {
                { "TenantId", tenantId }
            }
        };

        var service = new CustomerService();
        var customer = await service.CreateAsync(options);
        return customer.Id;
    }

    public async Task<string> CreateSubscriptionAsync(string customerId, string priceId)
    {
        if (string.IsNullOrEmpty(StripeConfiguration.ApiKey))
        {
            _logger.LogWarning("Stripe API Key is missing. Skipping subscription creation.");
            return "dummy_stripe_subscription_id"; // For dev/testing
        }

        var options = new SubscriptionCreateOptions
        {
            Customer = customerId,
            Items = new List<SubscriptionItemOptions>
            {
                new SubscriptionItemOptions { Price = priceId }
            },
            PaymentBehavior = "default_incomplete", // Allows creating sub without immediate payment method
        };

        var service = new SubscriptionService();
        var subscription = await service.CreateAsync(options);
        return subscription.Id;
    }
}
