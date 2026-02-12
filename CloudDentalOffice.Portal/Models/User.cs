using System.ComponentModel.DataAnnotations;

namespace CloudDentalOffice.Portal.Models;

public class User : ITenantEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
    public string Role { get; set; } = "Admin"; // Admin, Dentist, Staff
}
