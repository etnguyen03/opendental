using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Clinical notes and observations for patients
/// </summary>
[Table("ClinicalNotes")]
public class ClinicalNote : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClinicalNoteId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    // Patient reference
    [Required]
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; } = null!;

    // Provider who created the note (optional)
    public int? ProviderId { get; set; }
    public virtual Provider? Provider { get; set; }

    // Note details
    [Required]
    public DateTime NoteDate { get; set; }

    [Required]
    [MaxLength(50)]
    public string NoteType { get; set; } = "Clinical"; // Clinical, Exam, Treatment, Administrative, etc.

    [Required]
    [MaxLength(5000)]
    public string NoteText { get; set; } = string.Empty;

    // Metadata
    [MaxLength(100)]
    public string? CreatedBy { get; set; }

    public bool IsConfidential { get; set; } = false;

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }
}
