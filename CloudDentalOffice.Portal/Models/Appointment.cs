using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Appointment entity
/// </summary>
[Table("Appointments")]
public class Appointment : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AppointmentId { get; set; }

    [Required]
    [MaxLength(64)]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    public int PatientId { get; set; }

    [Required]
    public int ProviderId { get; set; }

    [Required]
    public DateTime AppointmentDateTime { get; set; }

    [Required]
    public int DurationMinutes { get; set; } = 60;

    [Required]
    [MaxLength(50)]
    public string AppointmentType { get; set; } = string.Empty; // Exam, Cleaning, Filling, Crown, etc.

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Scheduled"; // Scheduled, Confirmed, Checked-In, InProgress, Completed, Cancelled, NoShow

    [MaxLength(1000)]
    public string? Notes { get; set; }

    [MaxLength(100)]
    public string? ReasonForVisit { get; set; }

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    // Navigation properties
    public virtual Patient Patient { get; set; } = null!;
    public virtual Provider Provider { get; set; } = null!;
}
