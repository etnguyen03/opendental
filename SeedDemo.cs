// Seed Demo User Script
// Run this inside a pod: kubectl exec -it deployment/clouddental-portal -- dotnet run SeedDemo.cs

using CloudDentalOffice.Portal.Data;
using CloudDentalOffice.Portal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var connString = configuration.GetConnectionString("DefaultConnection") 
    ?? configuration["Database__ConnectionString"]
    ?? throw new Exception("No connection string found");

var options = new DbContextOptionsBuilder<CloudDentalDbContext>()
    .UseNpgsql(connString)
    .Options;

using var context = new CloudDentalDbContext(options, null);

Console.WriteLine("Checking for demo tenant...");

// Check if demo tenant already exists
var demoExists = await context.Tenants
    .IgnoreQueryFilters()
    .AnyAsync(t => t.TenantId == "demo");

if (demoExists)
{
    Console.WriteLine("Demo tenant already exists. Checking for demo user...");
    
    var userExists = await context.Users
        .IgnoreQueryFilters()
        .AnyAsync(u => u.Email == "demo@clouddentaloffice.com");
    
    if (userExists)
    {
        Console.WriteLine("Demo user already exists. Nothing to do.");
        return;
    }
    
    // Add just the user
    var user = new User
    {
        TenantId = "demo",
        Email = "demo@clouddentaloffice.com",
        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123!"),
        FirstName = "Demo",
        LastName = "User",
        Role = "Admin"
    };
    context.Users.Add(user);
    await context.SaveChangesAsync();
    Console.WriteLine("✓ Demo user created successfully!");
    return;
}

Console.WriteLine("Creating demo tenant and seed data...");

// Run full initialization
DbInitializer.Initialize(context);

Console.WriteLine("✓ Demo data seeded successfully!");
Console.WriteLine("");
Console.WriteLine("Demo login credentials:");
Console.WriteLine("  Email: demo@clouddentaloffice.com");
Console.WriteLine("  Password: Password123!");
