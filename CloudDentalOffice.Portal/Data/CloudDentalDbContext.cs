using Microsoft.EntityFrameworkCore;
using CloudDentalOffice.Portal.Models;
using CloudDentalOffice.Portal.Services.Tenancy;

namespace CloudDentalOffice.Portal.Data;

/// <summary>
/// Main database context for Cloud Dental Office
/// </summary>
public class CloudDentalDbContext : DbContext
{
    private readonly ITenantProvider _tenantProvider;

    public CloudDentalDbContext(DbContextOptions<CloudDentalDbContext> options)
        : this(options, null)
    {
    }

    public CloudDentalDbContext(
        DbContextOptions<CloudDentalDbContext> options,
        ITenantProvider? tenantProvider)
        : base(options)
    {
        _tenantProvider = tenantProvider ?? new DefaultTenantProvider();
    }

    // DbSets
    public DbSet<TenantRegistry> Tenants => Set<TenantRegistry>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<PatientInsurance> PatientInsurances => Set<PatientInsurance>();
    public DbSet<InsurancePlan> InsurancePlans => Set<InsurancePlan>();
    public DbSet<Provider> Providers => Set<Provider>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<TreatmentPlan> TreatmentPlans => Set<TreatmentPlan>();
    public DbSet<PlannedProcedure> PlannedProcedures => Set<PlannedProcedure>();
    public DbSet<Claim> Claims => Set<Claim>();
    public DbSet<ClaimProcedure> ClaimProcedures => Set<ClaimProcedure>();
    public DbSet<ProcedureCode> ProcedureCodes => Set<ProcedureCode>();
    public DbSet<Procedure> Procedures => Set<Procedure>();
    public DbSet<ClinicalNote> ClinicalNotes => Set<ClinicalNote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureTenantEntity<Patient>(modelBuilder);
        ConfigureTenantEntity<PatientInsurance>(modelBuilder);
        ConfigureTenantEntity<InsurancePlan>(modelBuilder);
        ConfigureTenantEntity<Provider>(modelBuilder);
        ConfigureTenantEntity<Appointment>(modelBuilder);
        ConfigureTenantEntity<TreatmentPlan>(modelBuilder);
        ConfigureTenantEntity<PlannedProcedure>(modelBuilder);
        ConfigureTenantEntity<Claim>(modelBuilder);
        ConfigureTenantEntity<ClaimProcedure>(modelBuilder);

        // Patient configuration
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasIndex(e => e.LastName);
            entity.HasIndex(e => e.Email);
            entity.HasIndex(e => new { e.LastName, e.FirstName });
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // PatientInsurance configuration
        modelBuilder.Entity<PatientInsurance>(entity =>
        {
            entity.HasOne(pi => pi.Patient)
                .WithMany(p => p.Insurances)
                .HasForeignKey(pi => pi.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(pi => pi.InsurancePlan)
                .WithMany(ip => ip.PatientInsurances)
                .HasForeignKey(pi => pi.InsurancePlanId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.MemberId);
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // InsurancePlan configuration
        modelBuilder.Entity<InsurancePlan>(entity =>
        {
            entity.HasIndex(e => e.PayerId);
            entity.HasIndex(e => e.PayerName);
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // User configuration
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // Provider configuration
        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasIndex(e => e.NPI).IsUnique();
            entity.HasIndex(e => new { e.LastName, e.FirstName });
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // Appointment configuration
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(a => a.Provider)
                .WithMany(pr => pr.Appointments)
                .HasForeignKey(a => a.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.AppointmentDateTime);
            entity.HasIndex(e => new { e.AppointmentDateTime, e.ProviderId });
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // TreatmentPlan configuration
        modelBuilder.Entity<TreatmentPlan>(entity =>
        {
            entity.HasOne(tp => tp.Patient)
                .WithMany(p => p.TreatmentPlans)
                .HasForeignKey(tp => tp.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(tp => tp.Provider)
                .WithMany(pr => pr.TreatmentPlans)
                .HasForeignKey(tp => tp.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // PlannedProcedure configuration
        modelBuilder.Entity<PlannedProcedure>(entity =>
        {
            entity.HasOne(pp => pp.TreatmentPlan)
                .WithMany(tp => tp.PlannedProcedures)
                .HasForeignKey(pp => pp.TreatmentPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(pp => pp.ClaimProcedure)
                .WithMany()
                .HasForeignKey(pp => pp.ClaimProcedureId)
                .OnDelete(DeleteBehavior.SetNull);
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // Claim configuration
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasOne(c => c.Patient)
                .WithMany(p => p.Claims)
                .HasForeignKey(c => c.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Provider)
                .WithMany(pr => pr.Claims)
                .HasForeignKey(c => c.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.PatientInsurance)
                .WithMany()
                .HasForeignKey(c => c.PatientInsuranceId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.ClaimNumber).IsUnique();
            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => e.SubmittedDate);
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // ClaimProcedure configuration
        modelBuilder.Entity<ClaimProcedure>(entity =>
        {
            entity.HasOne(cp => cp.Claim)
                .WithMany(c => c.Procedures)
                .HasForeignKey(cp => cp.ClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.CDTCode);
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        // ProcedureCode configuration
        modelBuilder.Entity<ProcedureCode>(entity =>
        {
            entity.HasIndex(e => e.Code).IsUnique();
            entity.HasIndex(e => e.Category);
            entity.HasIndex(e => e.IsActive);
        });

        // Procedure configuration
        modelBuilder.Entity<Procedure>(entity =>
        {
            entity.HasOne(p => p.Patient)
                .WithMany()
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Provider)
                .WithMany()
                .HasForeignKey(p => p.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Appointment)
                .WithMany()
                .HasForeignKey(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(e => e.ServiceDate);
            entity.HasIndex(e => e.CDTCode);
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });
        
        ConfigureTenantEntity<Procedure>(modelBuilder);

        // ClinicalNote configuration
        modelBuilder.Entity<ClinicalNote>(entity =>
        {
            entity.HasOne(cn => cn.Patient)
                .WithMany()
                .HasForeignKey(cn => cn.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(cn => cn.Provider)
                .WithMany()
                .HasForeignKey(cn => cn.ProviderId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(e => e.NoteDate);
            entity.HasIndex(e => e.NoteType);
            entity.HasIndex(e => e.TenantId);
            entity.HasQueryFilter(e => e.TenantId == _tenantProvider.TenantId);
        });

        ConfigureTenantEntity<ClinicalNote>(modelBuilder);

        // Seed data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed common dental procedure codes
        modelBuilder.Entity<ProcedureCode>().HasData(
            // Diagnostic
            new ProcedureCode { ProcedureCodeId = 1, Code = "D0120", Description = "Periodic oral evaluation - established patient", AbbrDesc = "Periodic Exam", DefaultFee = 75.00m, Category = "Diagnostic", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 2, Code = "D0140", Description = "Limited oral evaluation - problem focused", AbbrDesc = "Limited Exam", DefaultFee = 65.00m, Category = "Diagnostic", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 3, Code = "D0150", Description = "Comprehensive oral evaluation - new or established patient", AbbrDesc = "Comp Exam", DefaultFee = 95.00m, Category = "Diagnostic", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 4, Code = "D0210", Description = "Intraoral - complete series of radiographic images", AbbrDesc = "FMX", DefaultFee = 125.00m, Category = "Diagnostic", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 5, Code = "D0220", Description = "Intraoral - periapical first radiographic image", AbbrDesc = "PA", DefaultFee = 35.00m, Category = "Diagnostic", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 6, Code = "D0230", Description = "Intraoral - periapical each additional radiographic image", AbbrDesc = "PA Add'l", DefaultFee = 25.00m, Category = "Diagnostic", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 7, Code = "D0270", Description = "Bitewing - single radiographic image", AbbrDesc = "BW Single", DefaultFee = 30.00m, Category = "Diagnostic", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 8, Code = "D0274", Description = "Bitewings - four radiographic images", AbbrDesc = "4 BWs", DefaultFee = 65.00m, Category = "Diagnostic", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 9, Code = "D0330", Description = "Panoramic radiographic image", AbbrDesc = "Pano", DefaultFee = 95.00m, Category = "Diagnostic", IsActive = true, CreatedDate = DateTime.UtcNow },
            
            // Preventive
            new ProcedureCode { ProcedureCodeId = 10, Code = "D1110", Description = "Prophylaxis - adult", AbbrDesc = "Adult Prophy", DefaultFee = 95.00m, Category = "Preventive", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 11, Code = "D1120", Description = "Prophylaxis - child", AbbrDesc = "Child Prophy", DefaultFee = 75.00m, Category = "Preventive", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 12, Code = "D1206", Description = "Topical application of fluoride varnish", AbbrDesc = "Fluoride Varnish", DefaultFee = 35.00m, Category = "Preventive", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 13, Code = "D1208", Description = "Topical application of fluoride - excluding varnish", AbbrDesc = "Fluoride Treatment", DefaultFee = 30.00m, Category = "Preventive", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 14, Code = "D1351", Description = "Sealant - per tooth", AbbrDesc = "Sealant", DefaultFee = 55.00m, Category = "Preventive", IsActive = true, CreatedDate = DateTime.UtcNow },
            
            // Restorative
            new ProcedureCode { ProcedureCodeId = 15, Code = "D2140", Description = "Amalgam - one surface, primary or permanent", AbbrDesc = "Amalgam 1 Surf", DefaultFee = 140.00m, Category = "Restorative", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 16, Code = "D2150", Description = "Amalgam - two surfaces, primary or permanent", AbbrDesc = "Amalgam 2 Surf", DefaultFee = 175.00m, Category = "Restorative", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 17, Code = "D2160", Description = "Amalgam - three surfaces, primary or permanent", AbbrDesc = "Amalgam 3 Surf", DefaultFee = 210.00m, Category = "Restorative", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 18, Code = "D2330", Description = "Resin-based composite - one surface, anterior", AbbrDesc = "Comp 1 Surf Ant", DefaultFee = 155.00m, Category = "Restorative", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 19, Code = "D2331", Description = "Resin-based composite - two surfaces, anterior", AbbrDesc = "Comp 2 Surf Ant", DefaultFee = 185.00m, Category = "Restorative", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 20, Code = "D2332", Description = "Resin-based composite - three surfaces, anterior", AbbrDesc = "Comp 3 Surf Ant", DefaultFee = 220.00m, Category = "Restorative", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 21, Code = "D2391", Description = "Resin-based composite - one surface, posterior", AbbrDesc = "Comp 1 Surf Post", DefaultFee = 165.00m, Category = "Restorative", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 22, Code = "D2392", Description = "Resin-based composite - two surfaces, posterior", AbbrDesc = "Comp 2 Surf Post", DefaultFee = 195.00m, Category = "Restorative", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 23, Code = "D2393", Description = "Resin-based composite - three surfaces, posterior", AbbrDesc = "Comp 3 Surf Post", DefaultFee = 235.00m, Category = "Restorative", IsActive = true, CreatedDate = DateTime.UtcNow },
            
            // Endodontics
            new ProcedureCode { ProcedureCodeId = 24, Code = "D3310", Description = "Endodontic therapy, anterior tooth", AbbrDesc = "RCT Anterior", DefaultFee = 750.00m, Category = "Endodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 25, Code = "D3320", Description = "Endodontic therapy, premolar tooth", AbbrDesc = "RCT Premolar", DefaultFee = 900.00m, Category = "Endodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 26, Code = "D3330", Description = "Endodontic therapy, molar tooth", AbbrDesc = "RCT Molar", DefaultFee = 1150.00m, Category = "Endodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            
            // Periodontics
            new ProcedureCode { ProcedureCodeId = 27, Code = "D4341", Description = "Periodontal scaling and root planing - four or more teeth per quadrant", AbbrDesc = "SRP per Quad", DefaultFee = 240.00m, Category = "Periodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 28, Code = "D4342", Description = "Periodontal scaling and root planing - one to three teeth per quadrant", AbbrDesc = "SRP 1-3 Teeth", DefaultFee = 140.00m, Category = "Periodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            
            // Prosthodontics - Removable
            new ProcedureCode { ProcedureCodeId = 29, Code = "D5110", Description = "Complete denture - maxillary", AbbrDesc = "Upper Denture", DefaultFee = 1500.00m, Category = "Prosthodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 30, Code = "D5120", Description = "Complete denture - mandibular", AbbrDesc = "Lower Denture", DefaultFee = 1500.00m, Category = "Prosthodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 31, Code = "D5213", Description = "Partial denture - maxillary, resin base", AbbrDesc = "Upper Partial", DefaultFee = 1200.00m, Category = "Prosthodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 32, Code = "D5214", Description = "Partial denture - mandibular, resin base", AbbrDesc = "Lower Partial", DefaultFee = 1200.00m, Category = "Prosthodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            
            // Prosthodontics - Fixed
            new ProcedureCode { ProcedureCodeId = 33, Code = "D6240", Description = "Pontic - porcelain fused to high noble metal", AbbrDesc = "PFM Pontic", DefaultFee = 950.00m, Category = "Prosthodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 34, Code = "D6750", Description = "Crown - porcelain fused to high noble metal", AbbrDesc = "PFM Crown", DefaultFee = 1100.00m, Category = "Prosthodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 35, Code = "D6010", Description = "Surgical placement of endosteal implant", AbbrDesc = "Implant Placement", DefaultFee = 2000.00m, Category = "Prosthodontics", IsActive = true, CreatedDate = DateTime.UtcNow },
            
            // Oral Surgery
            new ProcedureCode { ProcedureCodeId = 36, Code = "D7140", Description = "Extraction, erupted tooth or exposed root", AbbrDesc = "Simple Extraction", DefaultFee = 150.00m, Category = "Oral Surgery", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 37, Code = "D7210", Description = "Extraction, erupted tooth requiring removal of bone and/or sectioning of tooth", AbbrDesc = "Surgical Extraction", DefaultFee = 250.00m, Category = "Oral Surgery", IsActive = true, CreatedDate = DateTime.UtcNow },
            new ProcedureCode { ProcedureCodeId = 38, Code = "D7240", Description = "Removal of impacted tooth - completely bony", AbbrDesc = "Impacted Tooth", DefaultFee = 400.00m, Category = "Oral Surgery", IsActive = true, CreatedDate = DateTime.UtcNow }
        );

        // Seed sample providers
        modelBuilder.Entity<Provider>().HasData(
            new Provider 
            { 
                ProviderId = 1, 
                TenantId = TenantConstants.DefaultTenantId,
                NPI = "1234567890",
                FirstName = "John", 
                LastName = "Smith", 
                Suffix = "DDS",
                Specialty = "General Dentistry",
                LicenseNumber = "D12345",
                LicenseState = "CA",
                Email = "jsmith@clouddentaloffice.com",
                Phone = "555-0101",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            },
            new Provider 
            { 
                ProviderId = 2, 
                TenantId = TenantConstants.DefaultTenantId,
                NPI = "2345678901",
                FirstName = "Sarah", 
                LastName = "Johnson", 
                Suffix = "DMD",
                Specialty = "Pediatric Dentistry",
                LicenseNumber = "D23456",
                LicenseState = "CA",
                Email = "sjohnson@clouddentaloffice.com",
                Phone = "555-0102",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            },
            new Provider 
            { 
                ProviderId = 3, 
                TenantId = TenantConstants.DefaultTenantId,
                NPI = "3456789012",
                FirstName = "Michael", 
                LastName = "Chen", 
                Suffix = "DDS",
                Specialty = "Oral Surgery",
                LicenseNumber = "D34567",
                LicenseState = "CA",
                Email = "mchen@clouddentaloffice.com",
                Phone = "555-0103",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            },
            new Provider 
            { 
                ProviderId = 4, 
                TenantId = TenantConstants.DefaultTenantId,
                NPI = "4567890123",
                FirstName = "Emily", 
                LastName = "Rodriguez", 
                Suffix = "DMD",
                Specialty = "Endodontics",
                LicenseNumber = "D45678",
                LicenseState = "CA",
                Email = "erodriguez@clouddentaloffice.com",
                Phone = "555-0104",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            }
        );
    }

    public override int SaveChanges()
    {
        ApplyTenantId();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyTenantId();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyTenantId()
    {
        var tenantId = _tenantProvider.TenantId;
        if (string.IsNullOrWhiteSpace(tenantId))
        {
            tenantId = TenantConstants.DefaultTenantId;
        }

        foreach (var entry in ChangeTracker.Entries<ITenantEntity>())
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                if (string.IsNullOrWhiteSpace(entry.Entity.TenantId))
                {
                    entry.Entity.TenantId = tenantId;
                }
            }
        }
    }

    private void ConfigureTenantEntity<TEntity>(ModelBuilder modelBuilder)
        where TEntity : class, ITenantEntity
    {
        modelBuilder.Entity<TEntity>()
            .Property(e => e.TenantId)
            .HasMaxLength(64)
            .IsRequired()
            .HasDefaultValue(TenantConstants.DefaultTenantId);

        modelBuilder.Entity<TEntity>()
            .HasIndex(e => e.TenantId);
    }
}
