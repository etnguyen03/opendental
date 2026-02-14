# Cloud Dental Office — Architecture Overview

> **Version:** 1.0  
> **Last Updated:** February 2026  
> **Maintainer:** Aurelianware, Inc.

-----

## Table of Contents

1. [System Overview](#system-overview)
1. [Repository Structure](#repository-structure)
1. [Architectural Layers](#architectural-layers)
1. [Component Descriptions](#component-descriptions)
1. [Data Flow: EDI Transaction Lifecycle](#data-flow-edi-transaction-lifecycle)
1. [Multi-Tenant Architecture](#multi-tenant-architecture)
1. [Cloud Health Office Integration](#cloud-health-office-integration)
1. [Deployment Topology](#deployment-topology)
1. [Security & HIPAA Controls](#security--hipaa-controls)
1. [Technology Stack](#technology-stack)
1. [Development Boundaries](#development-boundaries)

-----

## System Overview

Cloud Dental Office is a cloud-native, SaaS-ready practice management platform for dental providers. It is built as a modernization fork of [OpenDental](https://www.opendental.com/) — retaining OpenDental’s proven clinical and billing engine while replacing the Windows Forms UI layer with a responsive Blazor Server portal and adding multi-tenant infrastructure and deep X12 EDI interoperability.

```
┌─────────────────────────────────────────────────────────────────────┐
│                     CLOUD DENTAL OFFICE                             │
│                                                                     │
│  ┌──────────────────────────┐    ┌──────────────────────────────┐  │
│  │  CloudDentalOffice.Portal│    │  OpenDentBusiness (Core)     │  │
│  │  (Blazor Server / .NET 8)│◄───│  Clinical & Billing Engine   │  │
│  │                          │    │  (Retained from OpenDental)  │  │
│  │  • Dashboard KPIs        │    │                              │  │
│  │  • Patient Management    │    │  • Treatment Plans           │  │
│  │  • Claim Wizard          │    │  • Scheduling Logic          │  │
│  │  • EDI Management UI     │    │  • Insurance & Claims        │  │
│  │  • Tooth Chart           │    │  • Procedure Codes (CDT)     │  │
│  └──────────┬───────────────┘    └──────────────────────────────┘  │
│             │                                                        │
│             ▼                                                        │
│  ┌──────────────────────────┐                                        │
│  │  EDI Integration Layer   │                                        │
│  │  • 837D Claims           │◄──────────────────────────────────────┼──► Cloud Health Office
│  │  • 270/271 Eligibility   │                                        │    (Payer-Side EDI)
│  │  • 835 ERA               │                                        │
│  │  • 276/277 Status        │                                        │
│  │  • 278 Prior Auth        │                                        │
│  └──────────┬───────────────┘                                        │
│             │                                                        │
│             ▼                                                        │
│  ┌──────────────────────────┐                                        │
│  │  MySQL / Azure SQL       │                                        │
│  │  (per-tenant schema)     │                                        │
│  └──────────────────────────┘                                        │
└─────────────────────────────────────────────────────────────────────┘
```

-----

## Repository Structure

```
clouddentaloffice/
│
├── CloudDentalOffice.Portal/          ← NEW: Blazor Server UI (primary development target)
├── CloudDentalOffice.Portal.Tests/    ← NEW: Unit/Integration tests for portal
│
├── OpenDentBusiness/                  ← RETAINED: Core clinical/billing business logic
├── OpenDentBusiness.Tests/            ← RETAINED: Upstream tests
├── CodeBase/                          ← RETAINED: Shared utility library
├── CodeBaseStandard/                  ← RETAINED: .NET Standard version of CodeBase
│
├── k8s/                               ← NEW: Kubernetes manifests (Helm charts)
├── db/                                ← NEW: Schema migrations and seed scripts
├── packaging/                         ← NEW: Build/release packaging
├── .github/workflows/                 ← NEW: CI/CD pipeline definitions
├── azure-resources.bicep              ← NEW: Azure IaC (Bicep)
├── docker-compose.yml                 ← NEW: Local development environment
│
├── OpenDental/                        ← LEGACY: WinForms desktop client (not cloud target)
├── OpenDentalWpf/                     ← LEGACY: WPF components (not cloud target)
├── WpfControlsOD/                     ← LEGACY: WPF controls (not cloud target)
├── Direct2dWrapper/                   ← LEGACY: Windows-native rendering (not cloud target)
├── [other OpenDental legacy dirs]     ← LEGACY: Upstream OpenDental projects
│
├── ARCHITECTURE.md                    ← This file
├── README.md                          ← Project overview and quick start
├── ROADMAP.md                         ← Feature roadmap
├── DEPLOYMENT-README.md               ← Deployment guide
└── SFTP-TESTING-GUIDE.md             ← Payer SFTP connectivity testing
```

> **For contributors:** Focus development effort on `CloudDentalOffice.Portal` and `OpenDentBusiness`. The legacy WinForms/WPF directories are retained for reference and are not part of the cloud deployment target.

-----

## Architectural Layers

### Layer 1: Presentation — Blazor Server Portal

`CloudDentalOffice.Portal` is the primary user interface. It runs as a Blazor Server application on .NET 8, delivering a responsive, browser-based experience via SignalR-backed server-side rendering. No JavaScript framework is required on the client.

Key design decisions:

- **Server-side state** means no token management on the client and reduced attack surface
- **SignalR** enables real-time UI updates (e.g., live claim status, appointment board)
- **Multi-tenant routing** resolves tenant context from subdomain or path prefix at the middleware layer
- **“The Sentinel”** side navigation provides the primary UX framework with Practice Management and EDI sections

### Layer 2: Business Logic — OpenDentBusiness

The retained OpenDental business layer provides the clinical and billing foundation. Key namespaces handle:

- Patient demographics and medical history
- Treatment planning and procedure code management (ADA CDT codes)
- Appointment scheduling and operatory management
- Insurance plan configuration and claim generation
- Financial accounting and payment posting

This layer is consumed by the Blazor portal via service interfaces. Direct database access from the portal layer is avoided; all data operations flow through `OpenDentBusiness` service classes.

### Layer 3: EDI Integration

The EDI layer handles X12 transaction processing between the dental practice and payers. It operates as a background service with a management UI surface in the Blazor portal.

|Transaction              |Direction                  |Status       |
|-------------------------|---------------------------|-------------|
|837D Dental Claims       |Outbound (Practice → Payer)|✅ Implemented|
|270 Eligibility Request  |Outbound                   |🔄 In Progress|
|271 Eligibility Response |Inbound                    |🔄 In Progress|
|835 ERA Remittance       |Inbound (Payer → Practice) |📋 Roadmap    |
|276 Claim Status Request |Outbound                   |📋 Roadmap    |
|277 Claim Status Response|Inbound                    |📋 Roadmap    |
|278 Prior Authorization  |Outbound                   |📋 Roadmap    |

### Layer 4: Data — MySQL / Azure SQL

The data layer supports both MySQL (for on-premise/self-hosted deployments compatible with OpenDental) and Azure SQL (for cloud-hosted tenants). Schema management uses versioned SQL scripts in the `db/` directory.

Per-tenant isolation is achieved via separate schemas or databases depending on deployment model (see [Multi-Tenant Architecture](#multi-tenant-architecture)).

-----

## Component Descriptions

### CloudDentalOffice.Portal

The Blazor Server application. Key components:

- **Dashboard** — KPI widgets for patient count, today’s appointments, pending claims, and revenue summary
- **Patient Module** — Demographics, insurance, medical history, treatment history
- **Claims Module** — Multi-step claim creation wizard with CDT code quick-select and tooth chart integration; claim queue management; status tracking
- **EDI Management** — Transaction log viewer, payer connection configuration, SFTP settings
- **Scheduling** — Appointment calendar (integration with OpenDentBusiness scheduler)
- **Reports** — RDL-based reporting using the retained RdlEngine/RdlViewer components

### CentralManager

Multi-tenant management service. Handles tenant provisioning, database connection routing, and per-tenant configuration resolution. In cloud deployments, this runs as a separate microservice.

### OpenDentHL7

HL7 message processing retained from upstream OpenDental. Supports lab result integration and referral workflows.

### MobileWeb

Lightweight mobile-responsive web interface for patient-facing features (appointment requests, forms). Separate from the main Blazor portal.

-----

## Data Flow: EDI Transaction Lifecycle

### Outbound: 837D Claim Submission

```
Clinician completes procedure
         │
         ▼
OpenDentBusiness generates claim record
         │
         ▼
Blazor Portal — Claim Wizard (review, code validation)
         │
         ▼
EDI Layer — 837D X12 segment assembly
         │
         ▼
Payer Gateway (SFTP / AS2 / Clearinghouse API)
         │
         ▼
Payer acknowledgment (999 / TA1)
         │
         ▼
Claim status updated in portal
```

### Inbound: 835 ERA Processing (Roadmap)

```
Payer transmits 835 ERA file
         │
         ▼
EDI Layer — 835 parse and validation
         │
         ▼
OpenDentBusiness — auto-post remittance
         │
         ▼
Discrepancy queue for manual review
         │
         ▼
A/R updated, claim closed
```

### Real-Time Eligibility: 270/271

```
Front desk initiates eligibility check
         │
         ▼
Blazor Portal sends eligibility request
         │
         ▼
EDI Layer assembles 270
         │
         ▼
Payer real-time API (or SFTP batch)
         │
         ▼
271 response parsed → coverage details displayed
```

-----

## Multi-Tenant Architecture

Cloud Dental Office supports three tenancy models to accommodate different customer segments:

|Model                |Use Case                        |Database Isolation              |Notes                             |
|---------------------|--------------------------------|--------------------------------|----------------------------------|
|**Shared Schema**    |Small single-location practices |Row-level (TenantId column)     |Lowest cost, fastest onboarding   |
|**Separate Schema**  |Mid-size groups (2–10 locations)|Schema per tenant, shared server|Balance of cost and isolation     |
|**Separate Database**|DSOs, enterprise groups         |Full database per tenant        |Maximum isolation, HIPAA preferred|

Tenant resolution at runtime:

1. HTTP request arrives at the portal
1. Middleware resolves tenant from subdomain (e.g., `3rdsetsmiles.clouddentaloffice.com`) or path prefix
1. `CentralManager` returns the appropriate connection string for that tenant
1. `OpenDentBusiness` initializes with the tenant-specific connection

-----

## Cloud Health Office Integration

Cloud Dental Office is designed as the provider-side complement to [Cloud Health Office](https://github.com/aurelianware/cloudhealthoffice), Aurelianware’s payer-side EDI integration platform.

Together, they form a full provider ↔ payer automation loop:

```
PROVIDER SIDE                              PAYER SIDE
(Cloud Dental Office)                      (Cloud Health Office)

Dental Practice                            Health Plan / Payer
      │                                          │
      │  ──── 837D Claim ────────────────────►  │
      │  ◄─── 271 Eligibility ──────────────── │
      │  ◄─── 835 ERA Remittance ───────────── │
      │  ──── 276 Status Request ───────────►  │
      │  ◄─── 277 Status Response ──────────── │
      │  ──── 278 Prior Auth Request ───────►  │
      │  ◄─── 278 Auth Response ────────────── │
```

Integration is achieved via:

- **Shared X12 schema definitions** — consistent segment parsing between both platforms
- **Webhook events** — Cloud Health Office can push claim acceptance/rejection events to the dental portal
- **FHIR R4 patient/coverage** — planned coverage lookup API from Cloud Health Office consumed by dental portal eligibility checks

-----

## Deployment Topology

### Local Development

```
docker-compose up
```

Starts:

- Blazor Server portal (port 5000)
- MySQL database (port 3306)
- Adminer DB browser (port 8080)

### Azure (Production)

Provisioned via `azure-resources.bicep`:

```
Azure Resource Group
├── Azure App Service (Blazor Server portal)
├── Azure SQL / MySQL Flexible Server
├── Azure Service Bus (EDI message queue)
├── Azure Blob Storage (document/image storage)
├── Azure Key Vault (secrets, connection strings)
└── Application Insights (monitoring/logging)
```

### Kubernetes (Multi-Cloud)

Manifests in `k8s/`:

```
Kubernetes Cluster
├── Namespace: clouddentaloffice
├── Deployment: portal (Blazor Server)
├── Deployment: centralmanager (tenant routing)
├── Service: portal-svc (LoadBalancer)
├── ConfigMap: app-config
├── Secret: db-credentials (mounted from Vault)
└── HorizontalPodAutoscaler: portal
```

-----

## Security & HIPAA Controls

|Control               |Implementation                                       |
|----------------------|-----------------------------------------------------|
|Authentication        |OpenID Connect / Azure AD B2C (roadmap: full OIDC)   |
|Authorization         |Role-based (Provider, Billing, Admin, Viewer)        |
|Data in transit       |TLS 1.2+ enforced at load balancer                   |
|Data at rest          |Azure SQL TDE / MySQL encryption at rest             |
|PHI logging           |Application Insights with PHI field suppression      |
|Secrets management    |Azure Key Vault; no secrets in source control        |
|Audit trail           |All PHI access events written to audit log table     |
|Multi-tenant isolation|Connection string per tenant; no cross-tenant queries|
|Vulnerability scanning|GitHub Advanced Security / Dependabot alerts         |


> **Note:** This platform is designed to support HIPAA compliance. Achieving and maintaining HIPAA compliance requires additional operational controls (BAAs, workforce training, physical safeguards) beyond what any software platform provides alone.

-----

## Technology Stack

|Category         |Technology                                          |
|-----------------|----------------------------------------------------|
|UI Framework     |Blazor Server (.NET 8)                              |
|Backend Language |C# 12                                               |
|Database         |MySQL 8.x (on-premise) / Azure SQL (cloud)          |
|ORM / Data Access|OpenDentBusiness data layer (ADO.NET based)         |
|EDI Processing   |Custom X12 parser (837D, 270/271, 835, 276/277, 278)|
|Reporting        |RDL Engine (retained from OpenDental)               |
|Cloud Platform   |Azure (primary); Kubernetes (multi-cloud)           |
|IaC              |Azure Bicep                                         |
|Containerization |Docker / Kubernetes (Helm)                          |
|CI/CD            |GitHub Actions                                      |
|Monitoring       |Azure Application Insights                          |
|Secret Management|Azure Key Vault                                     |
|Auth             |OpenID Connect / Azure AD B2C                       |

-----

## Development Boundaries

To keep contributions focused and avoid inadvertent regressions in the legacy layer:

**Active development directories** (PRs welcome):

- `CloudDentalOffice.Portal/`
- `CloudDentalOffice.Portal.Tests/`
- `k8s/`
- `db/`
- `.github/workflows/`
- `packaging/`

**Modify with caution** (changes affect clinical/billing correctness):

- `OpenDentBusiness/`
- `CodeBase/`
- `CodeBaseStandard/`

**Legacy — do not modify** (retained for reference only, not part of cloud deployment):

- `OpenDental/` (WinForms desktop)
- `OpenDentalWpf/`
- `WpfControlsOD/`
- `Direct2dWrapper/`
- `PasswordVaultWrapper/`

-----

*For deployment instructions, see [DEPLOYMENT-README.md](./DEPLOYMENT-README.md).*  
*For the feature roadmap, see [ROADMAP.md](./ROADMAP.md).*  
*For SFTP payer connectivity testing, see [SFTP-TESTING-GUIDE.md](./SFTP-TESTING-GUIDE.md).*
