using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Patient entity - core demographic and insurance information
/// </summary>
[Table("Patients")]
public class Patient : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PatientId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [MaxLength(20)]
    public string? PreferredName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [MaxLength(1)]
    public string Gender { get; set; } = string.Empty; // M, F, O, U

    [MaxLength(11)]
    public string? SSN { get; set; }

    [EmailAddress]
    [MaxLength(255)]
    public string? Email { get; set; }

    [Phone]
    [MaxLength(20)]
    public string? PrimaryPhone { get; set; }

    [Phone]
    [MaxLength(20)]
    public string? SecondaryPhone { get; set; }

    // Address
    [MaxLength(255)]
    public string? Address1 { get; set; }

    [MaxLength(255)]
    public string? Address2 { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(2)]
    public string? State { get; set; }

    [MaxLength(10)]
    public string? ZipCode { get; set; }

    // Status
    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Active"; // Active, Inactive, Deceased, Archived

    // Audit fields
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }
    
    [MaxLength(100)]
    public string? CreatedBy { get; set; }
    
    [MaxLength(100)]
    public string? ModifiedBy { get; set; }

    // Navigation properties
    public virtual ICollection<PatientInsurance> Insurances { get; set; } = new List<PatientInsurance>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; } = new List<TreatmentPlan>();
    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();

    // Computed properties
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    [NotMapped]
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    [NotMapped]
    public PatientInsurance? PrimaryInsurance => 
        Insurances.FirstOrDefault(i => i.SequenceNumber == 1 && i.IsActive);

    [NotMapped]
    public PatientInsurance? SecondaryInsurance => 
        Insurances.FirstOrDefault(i => i.SequenceNumber == 2 && i.IsActive);
}
