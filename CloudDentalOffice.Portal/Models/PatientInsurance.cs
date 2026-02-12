using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Patient insurance information
/// </summary>
[Table("PatientInsurances")]
public class PatientInsurance : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PatientInsuranceId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    // Foreign keys
    [Required]
    public int PatientId { get; set; }

    [Required]
    public int InsurancePlanId { get; set; }

    // Insurance details
    [Required]
    [MaxLength(50)]
    public string MemberId { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? GroupNumber { get; set; }

    [Required]
    public int SequenceNumber { get; set; } // 1 = Primary, 2 = Secondary, etc.

    public DateTime EffectiveDate { get; set; }
    public DateTime? TerminationDate { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    // Relationship to subscriber (if different from patient)
    [MaxLength(20)]
    public string? RelationshipToSubscriber { get; set; } // Self, Spouse, Child, Other

    [MaxLength(100)]
    public string? SubscriberFirstName { get; set; }

    [MaxLength(100)]
    public string? SubscriberLastName { get; set; }

    [MaxLength(11)]
    public string? SubscriberSSN { get; set; }

    public DateTime? SubscriberDateOfBirth { get; set; }

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    // Navigation properties
    public virtual Patient Patient { get; set; } = null!;
    public virtual InsurancePlan InsurancePlan { get; set; } = null!;
}
