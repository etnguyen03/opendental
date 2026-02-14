# Cloud Dental Office

**Modern SaaS Practice Management for Dental Providers**  
A cloud-native evolution of OpenDental — rebuilt with Blazor Server, clean multi-tenant architecture, and deep X12 EDI payer interoperability.

[![License: GPL-2.0](https://img.shields.io/badge/License-GPL_2.0-blue.svg)](https://www.gnu.org/licenses/old-licenses/gpl-2.0.en.html)
[![.NET 8](https://img.shields.io/badge/.NET-8.0-purple)](https://dotnet.microsoft.com)
[![Blazor Server](https://img.shields.io/badge/Blazor_Server-Powered-blue)](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
[![CI](https://github.com/aurelianware/clouddentaloffice/actions/workflows/ci.yml/badge.svg)](https://github.com/aurelianware/clouddentaloffice/actions)

-----

## What Is This?

Dental practices deserve better than aging desktop software. Cloud Dental Office modernizes the proven [OpenDental](https://www.opendental.com/) engine into a secure, browser-based SaaS platform — keeping the battle-tested clinical, charting, and billing logic, and dramatically improving payer connectivity.

**The core idea:** Dental practices run the portal. Dental payers run [Cloud Health Office](https://github.com/aurelianware/cloudhealthoffice). Together, they automate the full provider ↔ payer EDI lifecycle — claims, eligibility, remittance, prior auth — without manual touchpoints.

-----

## Key Features

**Portal & UX**

- Responsive Blazor Server UI — works in any browser, no remote desktop required
- Modern dark theme with practice management dashboard (KPIs: patients, appointments, pending claims, revenue)
- “The Sentinel” side navigation with Practice Management and EDI sections
- Real-time feedback via toasts, status badges, and activity timeline

**Clinical & Billing (OpenDental Engine)**

- Full patient demographics, medical history, and treatment records
- Appointment scheduling and operatory management
- CDT procedure code management with tooth chart integration
- Insurance plan configuration and financial accounting

**EDI / Payer Interoperability**

- ✅ 837D Dental Claims — multi-step creation wizard, submission, and tracking
- 🔄 270/271 Real-time eligibility verification
- 📋 835 ERA auto-posting and reconciliation
- 📋 276/277 Claim status polling
- 📋 278 Prior authorization requests
- SFTP and clearinghouse connectivity (BCBS tested; see [SFTP-TESTING-GUIDE.md](./SFTP-TESTING-GUIDE.md))

**Infrastructure**

- Multi-tenant architecture — supports solo practices, group practices, and DSOs
- Docker and Kubernetes deployment (Azure AKS, multi-cloud)
- Azure Bicep infrastructure-as-code
- Application Insights monitoring with PHI-safe logging

-----

## Quick Start (Local Development)

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- MySQL 8.x (or use the included Docker Compose stack)

### 1. Clone the repository

```bash
git clone https://github.com/aurelianware/clouddentaloffice.git
cd clouddentaloffice
```

### 2. Start the local stack

```bash
docker-compose up -d
```

This starts the MySQL database, the Blazor portal, and an Adminer browser on `http://localhost:8080`.

### 3. Apply schema and seed demo data

```bash
# Apply schema
mysql -u root -p clouddentaloffice < db/create_tables.sql

# Seed procedure codes
mysql -u root -p clouddentaloffice < db/seed_procedure_codes.sql

# Seed demo tenant data (optional)
dotnet script SeedDemo.cs
```

### 4. Run the portal

```bash
cd CloudDentalOffice.Portal
dotnet run
```

Portal is available at `http://localhost:5000`.

### 5. Configure secrets (do not hardcode)

Copy the example config and populate your values:

```bash
cp CloudDentalOffice.Portal/appsettings.Example.json CloudDentalOffice.Portal/appsettings.Development.json
# Edit appsettings.Development.json with your local DB connection string
```

> **Never commit real connection strings or credentials.** See [Security Notes](#security-notes) below.

-----

## Repository Structure

```
clouddentaloffice/
├── CloudDentalOffice.Portal/          ← Blazor Server portal (primary development)
├── CloudDentalOffice.Portal.Tests/    ← Portal unit/integration tests
├── OpenDentBusiness/                  ← Clinical/billing engine (retained from OpenDental)
├── k8s/                               ← Kubernetes manifests
├── db/                                ← Schema migrations and seed scripts
├── .github/workflows/                 ← CI/CD pipeline
├── azure-resources.bicep              ← Azure infrastructure (Bicep IaC)
├── docker-compose.yml                 ← Local development environment
├── ARCHITECTURE.md                    ← System design and component overview
├── ROADMAP.md                         ← Feature roadmap and release milestones
├── DEPLOYMENT-README.md               ← Cloud and Kubernetes deployment guide
└── SFTP-TESTING-GUIDE.md             ← Payer SFTP connectivity testing
```

The remaining directories (`OpenDental/`, `OpenDentalWpf/`, etc.) are retained legacy OpenDental projects kept for reference. They are not part of the cloud deployment target. See [ARCHITECTURE.md](./ARCHITECTURE.md) for full details.

-----

## Cloud Health Office Integration

Cloud Dental Office is built to pair with **[Cloud Health Office](https://github.com/aurelianware/cloudhealthoffice)**, Aurelianware’s payer-side HIPAA-compliant EDI platform.

```
Cloud Dental Office          ←——— X12 EDI ———►     Cloud Health Office
(Dental Practice)                                    (Health Plan / Payer)

  Submits 837D claims          ─────────────►        Receives, adjudicates
  Checks eligibility           ─────────────►        Returns 271 response
  Receives remittance          ◄─────────────        Sends 835 ERA
  Polls claim status           ─────────────►        Returns 277 response
  Requests prior auth          ─────────────►        Returns 278 decision
```

This end-to-end automation eliminates manual claim follow-up and paper-based eligibility checks for practices and payers alike.

-----

## Deployment

### Azure (Recommended for Production)

```bash
az deployment group create \
  --resource-group my-rg \
  --template-file azure-resources.bicep \
  --parameters tenantName=mypractice environment=prod
```

See [DEPLOYMENT-README.md](./DEPLOYMENT-README.md) for full Azure setup including Key Vault configuration, App Service sizing, and database options.

### Kubernetes (Multi-Cloud)

```bash
helm install clouddentaloffice ./k8s/helm/clouddentaloffice \
  --namespace clouddentaloffice \
  --create-namespace \
  --values k8s/values.yaml
```

See [DEPLOYMENT-README.md](./DEPLOYMENT-README.md) for AKS, EKS, and GKE-specific configurations.

-----

## Security Notes

- **No credentials in source control.** Connection strings, API keys, and SFTP credentials belong in Azure Key Vault or Kubernetes Secrets — never in `.xml`, `.json`, or `.sql` files committed to the repo.
- **PHI logging is suppressed** in Application Insights by default. Review `appsettings.json` log filters before enabling verbose logging in production.
- **HIPAA compliance** requires operational controls beyond software. Ensure your deployment includes executed BAAs with all cloud service providers.
- **GPL-2.0 license** applies to this codebase as a fork of OpenDental. Review licensing obligations with counsel before commercial SaaS deployment.

-----

## Contributing

Contributions are welcome, particularly in these areas:

- `CloudDentalOffice.Portal` — Blazor UI features and bug fixes
- `CloudDentalOffice.Portal.Tests` — Test coverage expansion
- `k8s/` — Kubernetes deployment improvements
- `db/` — Schema migration tooling

Please open an issue before submitting large PRs. See [ARCHITECTURE.md](./ARCHITECTURE.md) for guidance on development boundaries within the codebase.

-----

## Roadmap

See [ROADMAP.md](./ROADMAP.md) for the full feature roadmap.

**Near-term priorities:**

- Complete 270/271 real-time eligibility
- 835 ERA auto-posting
- OpenID Connect / Azure AD B2C authentication
- Mobile-responsive improvements
- DSO multi-location support

-----

## License

This project is licensed under the [GNU General Public License v2.0](./LICENSE) as a derivative of [OpenDental](https://github.com/etnguyen03/opendental), which is GPL-2.0 licensed.

-----

## About Aurelianware

[Aurelianware, Inc.](https://github.com/aurelianware) builds open-source healthcare SaaS infrastructure. Our platforms include:

- **Cloud Dental Office** — SaaS practice management for dental providers (this repo)
- **[Cloud Health Office](https://github.com/aurelianware/cloudhealthoffice)** — HIPAA-compliant EDI integration platform for health plans and payers
