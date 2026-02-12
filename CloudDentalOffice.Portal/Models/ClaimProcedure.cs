using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Individual procedure on a claim
/// </summary>
[Table("ClaimProcedures")]
public class ClaimProcedure : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaimProcedureId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    public int ClaimId { get; set; }

    [Required]
    [MaxLength(10)]
    public string CDTCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public DateTime ServiceDate { get; set; }

    [MaxLength(10)]
    public string? ToothNumber { get; set; }

    [MaxLength(10)]
    public string? Surface { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal ChargeAmount { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? AllowedAmount { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? PaidAmount { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? Deductible { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? Copay { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? Coinsurance { get; set; }

    public int? LineNumber { get; set; }

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual Claim Claim { get; set; } = null!;
}
