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
}
