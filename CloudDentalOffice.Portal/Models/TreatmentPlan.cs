using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Treatment plan entity
/// </summary>
[Table("TreatmentPlans")]
public class TreatmentPlan : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TreatmentPlanId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    public int PatientId { get; set; }

    [Required]
    public int ProviderId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft"; // Draft, Proposed, Accepted, InProgress, Completed, Cancelled

    [MaxLength(255)]
    public string? Title { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    public DateTime? PresentedDate { get; set; }
    public DateTime? AcceptedDate { get; set; }
    public DateTime? CompletedDate { get; set; }

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    // Navigation properties
    public virtual Patient Patient { get; set; } = null!;
    public virtual Provider Provider { get; set; } = null!;
    public virtual ICollection<PlannedProcedure> PlannedProcedures { get; set; } = new List<PlannedProcedure>();

    [NotMapped]
    public decimal TotalEstimatedCost => PlannedProcedures.Sum(p => p.EstimatedFee);
}
