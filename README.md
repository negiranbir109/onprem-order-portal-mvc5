# LegacyOrderPortal

LegacyOrderPortal is a realistic legacy enterprise ASP.NET MVC 5 application built for Azure modernization assessment and agentic SDLC demonstrations.

## Overview

This internal on-prem portal is designed for operations teams to manage orders, customers, products, and reporting in a legacy environment. It demonstrates common patterns found in older .NET Framework applications, including direct repository construction, synchronous Entity Framework data access, and Web.config-driven settings.

## Technology Stack

- .NET Framework 4.8
- ASP.NET MVC 5
- Entity Framework 6 Code First
- SQL Server LocalDB
- Bootstrap and jQuery
- Traditional MVC folder structure
- Legacy logging to file

## Legacy Traits

- Tight coupling between controllers, services, and repositories
- Minimal dependency injection, with direct `new` instantiation
- Web.config-based application settings and connection strings
- Synchronous EF operations and repository patterns
- Old-style Razor views with classic Bootstrap layout
- Simple file-based logging in `App_Data/app.log`

## Intended Modernization Target

This repository is intended as a baseline for migrating an on-prem legacy .NET Framework application to Azure. Possible modernization targets include:

- Azure App Service / Azure Virtual Machines for web hosting
- Azure SQL Database for persistence
- Azure Monitor / Application Insights for logging and telemetry
- Azure DevOps or GitHub Actions for build and deployment automation

## Getting Started

1. Open `LegacyOrderPortal.sln` in Visual Studio 2019/2022.
2. Restore NuGet packages.
3. Build and run the project.

---

> Note: This app is intentionally built with legacy design patterns for assessment and modernization planning.
