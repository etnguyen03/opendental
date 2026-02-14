using CloudDentalOffice.Portal.Services.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CloudDentalOffice.Portal.Services;
using CloudDentalOffice.Portal.Services.Tenancy;
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
    // Increase circuit timeout to prevent 1006 disconnections
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
    options.DisconnectedCircuitMaxRetained = 100;
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
    options.MaxBufferedUnacknowledgedRenderBatches = 10;
})
.AddCircuitOptions(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.DetailedErrors = true;
    }
});

// Configure SignalR Hub options
builder.Services.Configure<Microsoft.AspNetCore.SignalR.HubOptions>(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromMinutes(2);
    options.HandshakeTimeout = TimeSpan.FromSeconds(30);
    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
    options.MaximumReceiveMessageSize = 128 * 1024; // 128KB
});

builder.Services.AddMudServices();
builder.Services.AddHttpContextAccessor();

// Configure JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"] ?? "ThisIsASecretKeyForDevelopmentOnly_DoNotUseInProduction_MakeItLonger";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "CloudDentalOffice";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "CloudDentalOffice";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

// Add HttpClient for API calls
builder.Services.AddHttpClient();

// Tenant resolution (Blazor Server-compatible)
builder.Services.AddScoped<ITenantProvider, BlazorTenantProvider>();

// Configure database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? builder.Configuration["Database:ConnectionString"]
    ?? "Server=localhost,1433;Database=CloudDentalOffice;User Id=sa;Password=YourStrong@Password123;TrustServerCertificate=True";

builder.Services.AddDbContext<CloudDentalDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseSqlite(connectionString);
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
    else
    {
        // Production: Use PostgreSQL (DigitalOcean Managed DB)
        options.UseNpgsql(connectionString, pgOptions => 
        {
            pgOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
        });
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
builder.Services.AddScoped<IAppointmentService, AppointmentServiceImpl>();
builder.Services.AddScoped<ITreatmentPlanService, TreatmentPlanService>();
builder.Services.AddScoped<IEdiService, EdiService>();
builder.Services.AddScoped<IProviderService, ProviderServiceImpl>();
builder.Services.AddScoped<IProcedureCodeService, ProcedureCodeServiceImpl>();
builder.Services.AddScoped<IBillingService, BillingService>();
builder.Services.AddScoped<IInsurancePlanService, InsurancePlanService>();
builder.Services.AddScoped<IClinicalChartService, ClinicalChartService>();

// Add EDI submission services
builder.Services.AddScoped<IEdiX12Service, EdiX12Service>();
builder.Services.AddScoped<IEdiSftpService, EdiSftpService>();
builder.Services.AddScoped<ICloudHealthOfficeApiService, CloudHealthOfficeApiService>();
builder.Services.AddScoped<IEdiSubmissionService, EdiSubmissionService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IStripeService, StripeService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, PortalAuthStateProvider>();

var app = builder.Build();

// Ensure database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CloudDentalDbContext>();
    try
    {
        dbContext.Database.Migrate();
        
        // Seed initial data
        CloudDentalOffice.Portal.Data.DbInitializer.Initialize(dbContext);
        
        // Seed claims for demo tenant
        CloudDentalOffice.Portal.Data.DbInitializer.SeedClaims(dbContext, TenantConstants.DefaultTenantId);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
