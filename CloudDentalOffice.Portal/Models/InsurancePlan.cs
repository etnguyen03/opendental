using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudDentalOffice.Portal.Models;

/// <summary>
/// Insurance plan/payer information
/// </summary>
[Table("InsurancePlans")]
public class InsurancePlan : ITenantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InsurancePlanId { get; set; }

    [Required]
    [MaxLength(50)]
    public string TenantId { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string PayerId { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string PayerName { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? PlanName { get; set; }

    [MaxLength(50)]
    public string? PlanType { get; set; } // PPO, HMO, Indemnity, etc.

    // Contact information
    [Phone]
    [MaxLength(20)]
    public string? Phone { get; set; }

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

    // EDI Information
    [MaxLength(50)]
    public string? EdiPayerId { get; set; }

    // EDI Submission Configuration
    public bool EdiEnabled { get; set; } = false;
    
    [MaxLength(20)]
    public string? EdiSubmissionType { get; set; } // "SFTP", "API", or "Both"

    // SFTP Configuration (for traditional EDI file exchange)
    [MaxLength(255)]
    public string? SftpHost { get; set; }
    
    public int? SftpPort { get; set; }
    
    [MaxLength(100)]
    public string? SftpUsername { get; set; }
    
    [MaxLength(500)]
    public string? SftpPasswordEncrypted { get; set; } // Store encrypted
    
    [MaxLength(255)]
    public string? SftpRemotePath { get; set; } // Directory path on SFTP server
    
    public bool SftpUseSshKey { get; set; } = false;
    
    [MaxLength(2000)]
    public string? SftpSshKeyEncrypted { get; set; } // Store encrypted SSH private key

    // API Configuration (for CloudHealthOffice or payer-specific APIs)
    [MaxLength(500)]
    public string? ApiEndpoint { get; set; }
    
    [MaxLength(500)]
    public string? ApiKeyEncrypted { get; set; } // Store encrypted
    
    [MaxLength(50)]
    public string? ApiAuthType { get; set; } // "ApiKey", "OAuth", "Bearer", etc.

    [Required]
    public bool IsActive { get; set; } = true;

    // Audit
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    // Navigation properties
    public virtual ICollection<PatientInsurance> PatientInsurances { get; set; } = new List<PatientInsurance>();
}
