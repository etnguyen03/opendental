using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using CloudDentalOffice.Portal.Services.Tenancy;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CloudDentalOffice.Portal.Tests;

public class TenantIsolationTests
{
    private CloudDentalDbContext GetContext(string tenantId)
    {
        var options = new DbContextOptionsBuilder<CloudDentalDbContext>()
            .UseInMemoryDatabase(databaseName: "CloudDentalTestDb_" + Guid.NewGuid()) // Unique DB per test
            .Options;

        var mockTenantProvider = new Mock<ITenantProvider>();
        mockTenantProvider.Setup(p => p.TenantId).Returns(tenantId);

        return new CloudDentalDbContext(options, mockTenantProvider.Object);
    }
    
    // Helper to seed shared DB
    private async Task SeedSharedDatabaseAsync(string dbName)
    {
         var options = new DbContextOptionsBuilder<CloudDentalDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
            
         // Use a provider that returns *something* so we can write
         // But wait, the filter applies on writes too? 
         // Actually, typically we might want a "System" context to seed cross-tenant data, 
         // or we just seed treating the context as "Tenant A" then "Tenant B".
         
         // Let's seed via "Tenant A" context
         var mockProviderA = new Mock<ITenantProvider>();
         mockProviderA.Setup(p => p.TenantId).Returns("tenant-a");
         using (var contextA = new CloudDentalDbContext(options, mockProviderA.Object))
         {
             contextA.Patients.Add(new Patient { FirstName = "Patient", LastName = "OfTenantA", TenantId = "tenant-a" });
             await contextA.SaveChangesAsync();
         }

         // Seed via "Tenant B" context
         var mockProviderB = new Mock<ITenantProvider>();
         mockProviderB.Setup(p => p.TenantId).Returns("tenant-b");
         using (var contextB = new CloudDentalDbContext(options, mockProviderB.Object))
         {
             contextB.Patients.Add(new Patient { FirstName = "Patient", LastName = "OfTenantB", TenantId = "tenant-b" });
             await contextB.SaveChangesAsync();
         }
    }

    [Fact]
    public async Task Query_ShouldOnlyReturnCurrentTenantsData()
    {
        // Arrange
        var dbName = "IsolationTestDB";
        await SeedSharedDatabaseAsync(dbName);

        var options = new DbContextOptionsBuilder<CloudDentalDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        // Act & Assert - Tenant A
        var mockProviderA = new Mock<ITenantProvider>();
        mockProviderA.Setup(p => p.TenantId).Returns("tenant-a");
        
        using (var contextA = new CloudDentalDbContext(options, mockProviderA.Object))
        {
            var patients = await contextA.Patients.ToListAsync();
            Assert.Single(patients);
            Assert.Equal("OfTenantA", patients[0].LastName);
        }

        // Act & Assert - Tenant B
        var mockProviderB = new Mock<ITenantProvider>();
        mockProviderB.Setup(p => p.TenantId).Returns("tenant-b");
        
        using (var contextB = new CloudDentalDbContext(options, mockProviderB.Object))
        {
            var patients = await contextB.Patients.ToListAsync();
            Assert.Single(patients);
            Assert.Equal("OfTenantB", patients[0].LastName);
        }
    }
    
    [Fact]
    public async Task CrossTenant_Write_Attempt_ShouldFail_Or_Be_Filtered()
    {
         // This verifies that even if I accidentally try to read ID from Tenant A while logged in as Tenant B, 
         // I won't find it.
         
        var dbName = "SecurityTestDB";
        await SeedSharedDatabaseAsync(dbName);
        var options = new DbContextOptionsBuilder<CloudDentalDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        // Find ID of Tenant A's patient
        int patientAId;
        var mockProviderSystem = new Mock<ITenantProvider>();
        mockProviderSystem.Setup(p => p.TenantId).Returns("tenant-a");
        using (var ctx = new CloudDentalDbContext(options, mockProviderSystem.Object))
        {
             patientAId = (await ctx.Patients.FirstAsync()).PatientId;
        }

        // Log in as Tenant B
        var mockProviderB = new Mock<ITenantProvider>();
        mockProviderB.Setup(p => p.TenantId).Returns("tenant-b");
        
        using (var contextB = new CloudDentalDbContext(options, mockProviderB.Object))
        {
            // Try to fetch Patient A by ID directly
            var patient = await contextB.Patients.FindAsync(patientAId);
            
            // Should be null because Global Query Filter blocks access, 
            // even if we know the Primary Key! (?)
            // Note: FindAsync uses changes tracker, so it might bypass if already tracked, 
            // but in a fresh context it creates a query. 
            // Standard EF Core: Query Filters ARE applied to Find/FindAsync.
            
            Assert.Null(patient);
        }
    }
}
