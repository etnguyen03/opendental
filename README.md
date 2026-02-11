# Cloud Dental Office

**Modern SaaS Practice Management System for Dental Providers**  
A cloud-native evolution of OpenDental — rebuilt with Blazor Server, clean architecture, real-time UI, and deep payer interoperability.

[![License: Apache 2.0](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![.NET](https://img.shields.io/badge/.NET-8.0+-purple)](https://dotnet.microsoft.com)
![Blazor Server](https://img.shields.io/badge/Blazor_Server-Powered-blue)

### The Vision

Dental practices deserve better than aging desktop software.  
Cloud Dental Office modernizes the proven OpenDental engine into a secure, browser-based SaaS platform with:

- Responsive Blazor Server UI (no more remote desktop pain)
- Multi-tenant architecture ready for DSOs and group practices
- Native payer interoperability — electronic claims (837D), eligibility (270/271), ERA (835), status (276/277), prior auth (278), and more
- Designed to pair perfectly with **[Cloud Health Office](https://github.com/aurelianware/cloudhealthoffice)** for true end-to-end provider ↔ payer automation

Goal: Bring dental practices into the cloud era while preserving OpenDental's battle-tested clinical, charting, and billing logic — and dramatically improve payer connectivity.

### What You Get (Current + Near-Term)

- Blazor Server → fast, responsive, secure server-side rendering
- Modern dark UI theme with teal accents
- Full claim lifecycle: create (multi-step wizard), review, submit, track
- CDT code quick-select + tooth charting integration
- Dashboard with KPIs (patients, appointments, pending claims, revenue)
- EDI integration foundation (837D claims already working)
- Side navigation ("The Sentinel") with Practice Management + EDI sections
- Real-time feedback (toasts, status badges, activity timeline)

**Roadmap highlights**  
- Full 270/271 real-time eligibility checks  
- 835 ERA auto-posting & reconciliation  
- 276/277 claim status polling  
- 278 prior authorization requests  
- Multi-location / DSO support  
- Mobile-responsive improvements  
- Azure / multi-cloud deployment templates  
- OpenID Connect / Azure AD B2C auth

### Quick Start (Local Development)

1. Clone the repo  
   ```bash
   git clone https://github.com/aurelianware/clouddentaloffice.git
