<div align="center">
  <picture>
    <img alt="Cloud Dental Office - The Sentinel" 
         src="https://raw.githubusercontent.com/aurelianware/cloudhealthoffice/main/docs/images/logo-cloudhealthoffice-sentinel-primary.svg" 
         width="600">
  </picture>
  
  <p><em>Just emerged from the void</em></p>
  
  <h1>Cloud Dental Office</h1>
  <h3>Modern Dental Practice Management System</h3>
  
  <p>
    <strong>Modernized fork of OpenDental with cloud-native architecture, integrated EDI, and Sentinel branding.</strong>
  </p>
</div>

---

## 🦷 Overview

Cloud Dental Office is a comprehensive modernization of the OpenDental practice management system, rebuilt with:

- **Blazor Server** - Modern web UI with real-time updates
- **Sentinel Branding** - Cyberpunk aesthetic inspired by [CloudHealthOffice](https://github.com/aurelianware/cloudhealthoffice)
- **Integrated EDI** - Native support for all major X12 transactions
- **Cloud-Native** - Azure-ready deployment with containerization
- **HIPAA Compliant** - Enterprise-grade security and data protection

## ✨ Features

### Practice Management
- **Patient Management** - Complete patient demographics and insurance information
- **Appointment Scheduling** - Real-time calendar with provider availability
- **Treatment Planning** - Comprehensive treatment plans with cost estimates
- **Clinical Charting** - Digital tooth charting and clinical notes
- **Billing & Collections** - Patient statements, payment processing

### EDI Integration (CloudHealthOffice Platform)

| Transaction | Type | Description | Status |
|------------|------|-------------|--------|
| **837D** | Claims | Dental claims submission | ✅ Active |
| **270/271** | Eligibility | Real-time eligibility verification | ✅ Active |
| **276/277** | Claim Status | Claim status inquiries and responses | ✅ Active |
| **278** | Prior Auth | Prior authorization requests | ✅ Active |
| **834** | Enrollment | Benefit enrollment & maintenance | ✅ Active |
| **835** | Remittance | Electronic remittance advice | ✅ Active |

### Cloud-Ready Architecture
- **Multi-Database Support** - SQL Server, PostgreSQL, MySQL, Cosmos DB
- **Azure Integration** - Key Vault, Blob Storage, Application Insights
- **Docker Containers** - Production-ready containerization
- **Infrastructure as Code** - Bicep templates for Azure deployment

## 🚀 Quick Start

### Prerequisites
- .NET 8.0 SDK or later
- SQL Server 2019+ (or Docker)
- Visual Studio 2022 / VS Code / Rider

### Local Development

```bash
# Clone the repository
git clone https://github.com/aurelianware/clouddentaloffice.git
cd clouddentaloffice

# Navigate to portal directory
cd CloudDentalOffice.Portal

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

Visit `https://localhost:5001` to access the application.

### Docker Development

```bash
# Start all services
docker-compose up -d

# View logs
docker-compose logs -f clouddental-portal

# Stop services
docker-compose down
```

## 🔧 Configuration

### appsettings.json

```json
{
  "EdiApi": {
    "BaseUrl": "https://edi.cloudhealthoffice.com/api",
    "ApiKey": "your-api-key",
    "TenantId": "your-tenant-id"
  },
  "Database": {
    "Provider": "SqlServer",
    "ConnectionString": "Server=localhost;Database=CloudDentalOffice;..."
  },
  "Practice": {
    "Name": "Your Dental Practice",
    "TaxId": "XX-XXXXXXX",
    "NPI": "XXXXXXXXXX"
  }
}
```

### Environment Variables

For production deployments, use Azure Key Vault or environment variables:

```bash
export EdiApi__ApiKey="your-secret-api-key"
export Database__ConnectionString="your-connection-string"
```

## ☁️ Azure Deployment

### Using Bicep

```bash
# Login to Azure
az login

# Create resource group
az group create --name rg-clouddental-prod --location eastus

# Deploy infrastructure
az deployment group create \
  --resource-group rg-clouddental-prod \
  --template-file azure-resources.bicep \
  --parameters environment=prod

# Deploy application
az webapp deployment source config-zip \
  --resource-group rg-clouddental-prod \
  --name app-clouddental-prod \
  --src publish.zip
```

### Using GitHub Actions

See `.github/workflows/azure-deploy.yml` for CI/CD pipeline configuration.

## 🎨 Sentinel Branding

The application uses the **Sentinel** theme from CloudHealthOffice:

- **Colors**: Absolute black (#000000), Neon cyan (#00ffff), Neon green (#00ff88)
- **Typography**: Segoe UI Bold headings, clean sans-serif body
- **Aesthetic**: Cyberpunk, minimalist, high-contrast
- **Philosophy**: "Just emerged from the void" - Kubrickian inevitability

## 📊 EDI Integration

Cloud Dental Office integrates with the [CloudHealthOffice EDI platform](https://github.com/aurelianware/cloudhealthoffice) for all X12 transactions:

### Real-Time Eligibility (270/271)
```csharp
var eligibility = await _ediService.VerifyEligibility270(new EligibilityRequest
{
    MemberId = "123456789",
    PayerId = "BCBS",
    ServiceDate = DateTime.Today
});
```

### Claim Submission (837D)
```csharp
var claim = await _ediService.SubmitDentalClaim837D(new DentalClaimRequest
{
    ClaimNumber = "CLM-2024-001",
    PatientId = "PT-12345",
    Procedures = procedures
});
```

## 🗄️ Database Migration

### From Legacy OpenDental

```bash
# Export data from OpenDental MySQL database
mysqldump -u root -p opendental > opendental_backup.sql

# Run migration tool (TODO: implement)
dotnet run --project DataMigration migrate \
  --source mysql://localhost/opendental \
  --target "Server=localhost;Database=CloudDentalOffice"
```

### Cosmos DB Support (Future)

For global distribution and massive scale, Cosmos DB migration is planned:

```json
{
  "Database": {
    "Provider": "CosmosDb",
    "ConnectionString": "AccountEndpoint=https://...",
    "DatabaseName": "CloudDentalOffice",
    "ContainerName": "Patients"
  }
}
```

## 🔐 Security

- **HIPAA Compliance** - PHI encryption at rest and in transit
- **Azure Key Vault** - Secrets management
- **Managed Identity** - Password-less authentication
- **TLS 1.2+** - Encrypted connections only
- **Audit Logging** - Complete audit trail with Application Insights

## 📝 License

This project is a modernization fork of OpenDental, which is licensed under GPL v2.

Original OpenDental: Copyright 2003-2024, Jordan S. Sparks, DMD  
Cloud Dental Office: Copyright 2025, Ethan Nguyen and contributors

This program is free software; you can redistribute it and/or modify it under the terms of version 2 of the GNU General Public License as published by the Free Software Foundation.

## 🤝 Contributing

Contributions are welcome! Please read [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## 🔗 Related Projects

- [CloudHealthOffice](https://github.com/aurelianware/cloudhealthoffice) - Multi-payer EDI integration platform
- [OpenDental](https://github.com/OpenDental/opendental) - Original practice management software

## 📞 Support

- **Issues**: [GitHub Issues](https://github.com/aurelianware/clouddentaloffice/issues)
- **Discussions**: [GitHub Discussions](https://github.com/aurelianware/clouddentaloffice/discussions)
- **Email**: support@aurelianware.com

---

<div align="center">
  <p><strong>The Sentinel</strong></p>
  <p><em>Configuration-driven. Backend-agnostic. Unstoppable.</em></p>
</div>
