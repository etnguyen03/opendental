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

        // Seed data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed data removed to prevent Npgsql migration issues
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
