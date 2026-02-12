using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Provider/dentist information
/// </summary>
[Table("Providers")]
public class Provider : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProviderId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string NPI { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [MaxLength(10)]
    public string? Suffix { get; set; } // DDS, DMD, etc.

    [MaxLength(100)]
    public string? Specialty { get; set; }

    [MaxLength(50)]
    public string? LicenseNumber { get; set; }

    [MaxLength(2)]
    public string? LicenseState { get; set; }

    // Contact
    [EmailAddress]
    [MaxLength(255)]
    public string? Email { get; set; }

    [Phone]
    [MaxLength(20)]
    public string? Phone { get; set; }

    // Tax ID for billing
    [MaxLength(20)]
    public string? TaxId { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    // Navigation properties
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; } = new List<TreatmentPlan>();
    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}{(string.IsNullOrEmpty(Suffix) ? "" : ", " + Suffix)}";
}
