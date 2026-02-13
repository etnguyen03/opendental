using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Dental claim (837D) entity
/// </summary>
[Table("Claims")]
public class Claim : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaimId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string ClaimNumber { get; set; } = string.Empty;

    [Required]
    public int PatientId { get; set; }

    [Required]
    public int ProviderId { get; set; }

    public int? PatientInsuranceId { get; set; }

    // Claim details
    [Required]
    public DateTime ServiceDateFrom { get; set; }

    public DateTime? ServiceDateTo { get; set; }

    [Required]
    [MaxLength(20)]
    public string ClaimType { get; set; } = "Primary"; // Primary, Secondary, Tertiary

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = "Draft"; // Draft, Ready, Submitted, Accepted, Rejected, Paid, Denied

    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalChargeAmount { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? PaidAmount { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? PatientResponsibility { get; set; }

    // EDI tracking
    [MaxLength(100)]
    public string? EdiControlNumber { get; set; }

    public DateTime? SubmittedDate { get; set; }
    
    [MaxLength(100)]
    public string? SubmittedBy { get; set; }

    public DateTime? ProcessedDate { get; set; }

    [MaxLength(2000)]
    public string? ResponseNotes { get; set; }

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    [MaxLength(100)]
    public string? CreatedBy { get; set; }

    [MaxLength(100)]
    public string? ModifiedBy { get; set; }

    // Navigation properties
    public virtual Patient Patient { get; set; } = null!;
    public virtual Provider Provider { get; set; } = null!;
    public virtual PatientInsurance PatientInsurance { get; set; } = null!;
    public virtual ICollection<ClaimProcedure> Procedures { get; set; } = new List<ClaimProcedure>();
}
