using System.ComponentModel.DataAnnotations;

namespace CloudDentalOffice.Portal.Models;

public class TenantRegistry
{
    [Key]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Plan { get; set; }

    public bool IsActive { get; set; } = true;

    public string? StripeCustomerId { get; set; }

    public string? StripeSubscriptionId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
