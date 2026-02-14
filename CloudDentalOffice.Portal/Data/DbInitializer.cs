using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudDentalOffice.Portal.Data;

public static class DbInitializer
{
    public static void Initialize(CloudDentalDbContext context)
    {
        context.Database.EnsureCreated();

        // Check if we have any tenants
        if (context.Tenants.IgnoreQueryFilters().Any())
        {
            return; // DB has been seeded
        }

        var demoTenantId = "demo";

        // 1. Create Demo Tenant
        var tenant = new TenantRegistry
        {
            TenantId = demoTenantId,
            Name = "Cloud Dental Demo Practice",
            Plan = "Enterprise",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
        context.Tenants.Add(tenant);

        // 2. Create Demo User
        var user = new User
        {
            TenantId = demoTenantId,
            Email = "demo@clouddentaloffice.com",
            // Password123! hashed
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123!"),
            FirstName = "Demo",
            LastName = "User",
            Role = "Admin"
        };
        context.Users.Add(user);

        // 3. Create Provider
        var provider = new Provider
        {
            TenantId = demoTenantId,
            FirstName = "Sarah",
            LastName = "Smile",
            NPI = "1234567890",
            Specialty = "General Dentist",
            Email = "dr.smile@demo.com",
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };
        context.Providers.Add(provider);

        // 4. Create Insurance Plan
        var insurance = new InsurancePlan
        {
            TenantId = demoTenantId,
            PayerId = "00001",
            PayerName = "Delta Dental",
            PlanName = "PPO Plus Premier",
            PlanType = "PPO",
            EdiEnabled = true,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };
        context.InsurancePlans.Add(insurance);
        
        context.SaveChanges(); // Save provider/insurance to get IDs if needed

        // 5. Create Patient
        var patient = new Patient
        {
            TenantId = demoTenantId,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1980, 1, 1),
            Gender = "M",
            Address1 = "123 Main St",
            City = "Tech City",
            State = "CA",
            ZipCode = "90210",
            Email = "john.doe@example.com",
            PrimaryPhone = "555-0100",
            Status = "Active",
            CreatedDate = DateTime.UtcNow
        };
        context.Patients.Add(patient);
        context.SaveChanges();

        // 6. Patient Insurance
        var patIns = new PatientInsurance
        {
            TenantId = demoTenantId,
            PatientId = patient.PatientId,
            InsurancePlanId = insurance.InsurancePlanId,
            MemberId = "DD123456789",
            SequenceNumber = 1, // Primary
            IsActive = true,
            RelationshipToSubscriber = "Self",
            EffectiveDate = DateTime.UtcNow.AddYears(-1),
            CreatedDate = DateTime.UtcNow
        };
        context.PatientInsurances.Add(patIns);

        // 7. Appointment
        var appointment = new Appointment
        {
            TenantId = demoTenantId,
            PatientId = patient.PatientId,
            ProviderId = provider.ProviderId,
            AppointmentDateTime = DateTime.UtcNow.AddDays(1).Date.AddHours(10), // Tomorrow 10am
            DurationMinutes = 60,
            AppointmentType = "Exam/Cleaning",
            Status = "Scheduled",
            ReasonForVisit = "Periodic Exam",
            CreatedDate = DateTime.UtcNow
        };
        context.Appointments.Add(appointment);

        // 8. Planned Procedure (Treatment Plan)
        var tp = new TreatmentPlan
        {
            TenantId = demoTenantId,
            PatientId = patient.PatientId,
            ProviderId = provider.ProviderId,
            Status = "Proposed", // Draft, Proposed, Accepted, InProgress, Completed, Cancelled
            Description = "Recall Treatment",
            CreatedDate = DateTime.UtcNow
        };
        context.TreatmentPlans.Add(tp);
        context.SaveChanges();

        var proc = new PlannedProcedure
        {
            TenantId = demoTenantId,
            TreatmentPlanId = tp.TreatmentPlanId,
            CDTCode = "D0120",
            Description = "Periodic Oral Evaluation",
            EstimatedFee = 50.00m,
            Status = "Planned",
            CreatedDate = DateTime.UtcNow
        };
        context.PlannedProcedures.Add(proc);

        context.SaveChanges();
    }

    public static void SeedClaims(CloudDentalDbContext context, string tenantId = "demo")
    {
        // Check if claims already exist for this tenant
        if (context.Claims.IgnoreQueryFilters().Any(c => c.TenantId == tenantId))
        {
            Console.WriteLine($"Claims already exist for tenant {tenantId}");
            return;
        }

        var provider = context.Providers.IgnoreQueryFilters()
            .FirstOrDefault(p => p.TenantId == tenantId);
        
        if (provider == null)
        {
            Console.WriteLine($"No provider found for tenant {tenantId}");
            return;
        }

        var patients = context.Patients.IgnoreQueryFilters()
            .Where(p => p.TenantId == tenantId)
            .Take(10)
            .ToList();

        if (!patients.Any())
        {
            Console.WriteLine($"No patients found for tenant {tenantId}");
            return;
        }

        int claimCounter = 0;
        foreach (var patient in patients)
        {
            claimCounter++;
            
            // Determine claim status
            string status = claimCounter <= 3 ? "Paid" : 
                           claimCounter <= 6 ? "Submitted" : "Draft";

            var claim = new Claim
            {
                TenantId = tenantId,
                PatientId = patient.PatientId,
                ProviderId = provider.ProviderId,
                ClaimNumber = $"CLM-{DateTime.UtcNow:yyyyMMdd}-{claimCounter:D4}",
                Status = status,
                ClaimType = "Primary",
                ServiceDateFrom = DateTime.UtcNow.AddDays(-30),
                TotalChargeAmount = 450.00m,
                CreatedDate = DateTime.UtcNow.AddDays(-28)
            };

            // Set additional fields for paid claims
            if (status == "Paid")
            {
                claim.SubmittedDate = DateTime.UtcNow.AddDays(-28);
                claim.ProcessedDate = DateTime.UtcNow.AddDays(-15);
                claim.PaidAmount = 360.00m;
                claim.PatientResponsibility = 90.00m;
            }
            else if (status == "Submitted")
            {
                claim.SubmittedDate = DateTime.UtcNow.AddDays(-10);
            }

            context.Claims.Add(claim);
            context.SaveChanges(); // Save to get ClaimId

            // Add procedures
            var procedures = new[]
            {
                new ClaimProcedure
                {
                    TenantId = tenantId,
                    ClaimId = claim.ClaimId,
                    CDTCode = "D0150",
                    Description = "Comprehensive oral evaluation",
                    ServiceDate = claim.ServiceDateFrom,
                    ChargeAmount = 85.00m,
                    AllowedAmount = status == "Paid" ? 68.00m : null,
                    PaidAmount = status == "Paid" ? 68.00m : null
                },
                new ClaimProcedure
                {
                    TenantId = tenantId,
                    ClaimId = claim.ClaimId,
                    CDTCode = "D1110",
                    Description = "Prophylaxis - adult",
                    ServiceDate = claim.ServiceDateFrom,
                    ChargeAmount = 125.00m,
                    AllowedAmount = status == "Paid" ? 100.00m : null,
                    PaidAmount = status == "Paid" ? 100.00m : null
                },
                new ClaimProcedure
                {
                    TenantId = tenantId,
                    ClaimId = claim.ClaimId,
                    CDTCode = "D0210",
                    Description = "Intraoral - complete series",
                    ServiceDate = claim.ServiceDateFrom,
                    ChargeAmount = 240.00m,
                    AllowedAmount = status == "Paid" ? 192.00m : null,
                    PaidAmount = status == "Paid" ? 192.00m : null
                }
            };

            context.ClaimProcedures.AddRange(procedures);
        }

        context.SaveChanges();
        Console.WriteLine($"Seeded {claimCounter} claims for tenant {tenantId}");
    }
}
