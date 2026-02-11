using Microsoft.EntityFrameworkCore;
using CloudDentalOffice.Portal.Models;

namespace CloudDentalOffice.Portal.Data;

/// <summary>
/// Main database context for Cloud Dental Office
/// </summary>
public class CloudDentalDbContext : DbContext
{
    public CloudDentalDbContext(DbContextOptions<CloudDentalDbContext> options)
        : base(options)
    {
    }

    // DbSets
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

        // Patient configuration
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasIndex(e => e.LastName);
            entity.HasIndex(e => e.Email);
            entity.HasIndex(e => new { e.LastName, e.FirstName });
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
        });

        // InsurancePlan configuration
        modelBuilder.Entity<InsurancePlan>(entity =>
        {
            entity.HasIndex(e => e.PayerId);
            entity.HasIndex(e => e.PayerName);
        });

        // Provider configuration
        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasIndex(e => e.NPI).IsUnique();
            entity.HasIndex(e => new { e.LastName, e.FirstName });
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
        });

        // ClaimProcedure configuration
        modelBuilder.Entity<ClaimProcedure>(entity =>
        {
            entity.HasOne(cp => cp.Claim)
                .WithMany(c => c.Procedures)
                .HasForeignKey(cp => cp.ClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.CDTCode);
        });

        // Seed data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Providers
        modelBuilder.Entity<Provider>().HasData(
            new Provider
            {
                ProviderId = 1,
                NPI = "1234567890",
                FirstName = "Sarah",
                LastName = "Johnson",
                Suffix = "DDS",
                Specialty = "General Dentistry",
                LicenseNumber = "DDS-12345",
                LicenseState = "CA",
                Email = "dr.johnson@clouddental.com",
                Phone = "555-123-4567",
                TaxId = "12-3456789",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Provider
            {
                ProviderId = 2,
                NPI = "0987654321",
                FirstName = "Michael",
                LastName = "Chen",
                Suffix = "DMD",
                Specialty = "Orthodontics",
                LicenseNumber = "DMD-54321",
                LicenseState = "CA",
                Email = "dr.chen@clouddental.com",
                Phone = "555-987-6543",
                TaxId = "98-7654321",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        // Seed Insurance Plans
        modelBuilder.Entity<InsurancePlan>().HasData(
            new InsurancePlan
            {
                InsurancePlanId = 1,
                PayerId = "BCBS",
                PayerName = "Blue Cross Blue Shield",
                PlanName = "PPO Standard",
                PlanType = "PPO",
                Phone = "1-800-123-4567",
                Address1 = "123 Insurance Way",
                City = "San Francisco",
                State = "CA",
                ZipCode = "94102",
                EdiPayerId = "BCBS001",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new InsurancePlan
            {
                InsurancePlanId = 2,
                PayerId = "DELTA",
                PayerName = "Delta Dental",
                PlanName = "Delta Premier",
                PlanType = "PPO",
                Phone = "1-800-765-4321",
                Address1 = "456 Dental Plaza",
                City = "Los Angeles",
                State = "CA",
                ZipCode = "90001",
                EdiPayerId = "DELTA001",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
