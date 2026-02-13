using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Dental procedure codes (CDT codes) with descriptions and fees
/// </summary>
[Table("ProcedureCodes")]
public class ProcedureCode
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProcedureCodeId { get; set; }

    /// <summary>
    /// CDT Code (e.g., D0120, D1110)
    /// </summary>
    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Description of the procedure
    /// </summary>
    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Abbreviated description for display
    /// </summary>
    [MaxLength(100)]
    public string? AbbrDesc { get; set; }

    /// <summary>
    /// Default fee for this procedure
    /// </summary>
    [Column(TypeName = "decimal(10,2)")]
    public decimal DefaultFee { get; set; }

    /// <summary>
    /// Category of the procedure (Diagnostic, Preventive, Restorative, etc.)
    /// </summary>
    [MaxLength(50)]
    public string? Category { get; set; }

    /// <summary>
    /// Whether this code is active/in use
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    /// <summary>
    /// Display name combining code and description
    /// </summary>
    [NotMapped]
    public string DisplayName => $"{Code} - {(string.IsNullOrEmpty(AbbrDesc) ? Description : AbbrDesc)}";
}
