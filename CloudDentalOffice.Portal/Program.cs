using CloudDentalOffice.Portal.Services;
using CloudDentalOffice.Portal.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = builder.Environment.IsDevelopment();
});
builder.Services.AddMudServices();

// Add HttpClient for API calls
builder.Services.AddHttpClient();

// Configure database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? builder.Configuration["Database:ConnectionString"]
    ?? "Server=localhost,1433;Database=CloudDentalOffice;User Id=sa;Password=YourStrong@Password123;TrustServerCertificate=True";

builder.Services.AddDbContext<CloudDentalDbContext>(options =>
{
    options.UseSqlite(connectionString);
    
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});

// Configure Azure Key Vault for secrets management (cloud-ready)
if (!builder.Environment.IsDevelopment())
{
    var keyVaultUrl = builder.Configuration["KeyVault:VaultUri"];
    if (!string.IsNullOrEmpty(keyVaultUrl))
    {
        builder.Configuration.AddAzureKeyVault(
            new Uri(keyVaultUrl),
            new Azure.Identity.DefaultAzureCredential());
    }
}

// Add application services
builder.Services.AddScoped<IPatientService, PatientServiceImpl>();
builder.Services.AddScoped<IClaimService, ClaimServiceImpl>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<ITreatmentPlanService, TreatmentPlanService>();
builder.Services.AddScoped<IEdiService, EdiService>();
builder.Services.AddScoped<IProviderService, ProviderServiceImpl>();
builder.Services.AddScoped<IBillingService, BillingService>();
builder.Services.AddScoped<IInsurancePlanService, InsurancePlanService>();

// Add EDI submission services
builder.Services.AddScoped<IEdiX12Service, EdiX12Service>();
builder.Services.AddScoped<IEdiSftpService, EdiSftpService>();
builder.Services.AddScoped<ICloudHealthOfficeApiService, CloudHealthOfficeApiService>();
builder.Services.AddScoped<IEdiSubmissionService, EdiSubmissionService>();

var app = builder.Build();

// Ensure database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CloudDentalDbContext>();
    try
    {
        dbContext.Database.Migrate();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Database migrations applied successfully");
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error applying database migrations");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
