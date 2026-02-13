using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Completed dental procedure (actual work performed)
/// </summary>
[Table("Procedures")]
public class Procedure : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProcedureId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    // Patient reference
    [Required]
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; } = null!;

    // Provider who performed the procedure
    [Required]
    public int ProviderId { get; set; }
    public virtual Provider Provider { get; set; } = null!;

    // Appointment reference (optional)
    public int? AppointmentId { get; set; }
    public virtual Appointment? Appointment { get; set; }

    // Procedure details
    [Required]
    [MaxLength(10)]
    public string CDTCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(3)]
    public string? ToothNumber { get; set; }

    [MaxLength(10)]
    public string? Surface { get; set; }

    // Dates
    [Required]
    public DateTime ServiceDate { get; set; }

    // Financial
    [Column(TypeName = "decimal(10,2)")]
    public decimal ChargeAmount { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? InsuranceEstimate { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? PatientPortion { get; set; }

    // Status
    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Completed"; // Completed, Billed, Paid

    // Clinical notes for this specific procedure
    [MaxLength(2000)]
    public string? Notes { get; set; }

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }
}
