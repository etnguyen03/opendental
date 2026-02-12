using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Planned procedure within a treatment plan
/// </summary>
[Table("PlannedProcedures")]
public class PlannedProcedure : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlannedProcedureId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    public int TreatmentPlanId { get; set; }

    [Required]
    [MaxLength(10)]
    public string CDTCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(10)]
    public string? ToothNumber { get; set; }

    [MaxLength(10)]
    public string? Surface { get; set; } // MOD, B, etc.

    [Column(TypeName = "decimal(10,2)")]
    public decimal EstimatedFee { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Planned"; // Planned, Scheduled, Completed, Cancelled

    public int? SequenceNumber { get; set; }

    public DateTime? CompletedDate { get; set; }

    // Link to actual claim procedure if completed
    public int? ClaimProcedureId { get; set; }

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    // Navigation properties
    public virtual TreatmentPlan TreatmentPlan { get; set; } = null!;
    public virtual ClaimProcedure? ClaimProcedure { get; set; }
}
