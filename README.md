# Cloud Dental Office

**Modern, SaaS-ready practice management system for dental providers**  
Built as a cloud-native evolution of OpenDental — now with Blazor Server, better architecture, and streamlined payer interoperability.

[![License: Apache 2.0](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![.NET](https://img.shields.io/badge/.NET-8.0+-purple.svg)](https://dotnet.microsoft.com)
![Blazor Server](https://img.shields.io/badge/Blazor%20Server-Powered-blue)

### The Problem

Most dental practices still run on aging desktop software (like OpenDental on-prem).  
Payer interoperability remains painful: slow eligibility checks, clunky claim submissions, delayed ERAs, and poor 835/837 handling.  
Upgrading or replacing legacy practice management systems takes months and huge cost — we want to change that.

### Cloud Dental Office

A modernized, cloud-first fork of OpenDental that brings:

- **SaaS-ready** deployment (Blazor Server)
- Clean, maintainable architecture
- Strong focus on **provider ↔ payer interoperability**
- Future support for real-time eligibility (270/271), electronic claims (837), ERA (835), and attachments (275)
- Designed to work beautifully together with **[Cloud Health Office](https://github.com/aurelianware/cloudhealthoffice)** for end-to-end provider-payer automation

Goal: Give dental practices a modern, secure, cloud-native PMS without losing OpenDental's battle-tested clinical & billing logic — while dramatically improving payer connectivity.

### Key Features (Current + Roadmap)

✅ Blazor Server UI — responsive, modern, runs in any modern browser  
✅ Forked from latest stable OpenDental — keeping core dental workflows intact  
✅ .NET 8+, clean architecture improvements  
✅ Multi-tenant SaaS foundation  
🚧 Improved cloud database & storage (Azure/AWS/GCP)  
🚧 Enhanced EDI & FHIR connectivity layer  
🚧 Integration path with Cloud Health Office payer platform  
🚧 Real-time eligibility, claim status, ERA auto-posting  
🚧 Mobile/responsive improvements  
🚧 Open-source under Apache 2.0

### Quick Links

- 🌐 Live product site (coming soon): https://clouddentaloffice.com (planned)  
- 🏠 Companion payer platform: https://github.com/aurelianware/cloudhealthoffice  
- 📖 Documentation: /docs folder (expanding soon)

### Getting Started

(Instructions coming in next few days — currently in active early development)

1. Clone the repo
2. Set up the database (migration scripts in /Database)
3. Run the Blazor Server project

Detailed quickstart guide → [QUICKSTART.md](QUICKSTART.md)

### Why Open Source?

We believe dental software deserves the same modernization and interoperability revolution that medical payer systems are starting to see.  
By open-sourcing this, we hope to accelerate innovation for dental practices and DSOs worldwide.

Star ⭐ the repo if you believe dental providers deserve better cloud software.

### License

Apache License 2.0 — see [LICENSE](LICENSE)

Built with ❤️ by [Aurelianware](https://github.com/aurelianware)
