# 🌍 BlockedCountry Management System

This repository implements a production-ready solution for managing country-level access based on IP addresses. Developed as a technical assignment for **Sortech**, the project emphasizes clean code, scalability, and efficiency.

## 🛠️ Technical Highlights

*   **Architecture:** Implemented using **Clean Architecture** (API, Application, Domain, and Infrastructure layers) to ensure strict separation of concerns.
*   **Geocoding Integration:** Seamlessly integrated with **ipapi.co** using `IHttpClientFactory` for reliable IP-to-country mapping[cite: 2].
*   **Thread-Safety:** Utilized `ConcurrentDictionary` for high-performance, thread-safe in-memory storage of blocked countries[cite: 1].
*   **Temporal Blocking:** Developed a **Background Worker Service** that automatically manages and expires temporary blocks every 5 minutes.
*   **Validation:** Robust input validation across all controllers using **FluentValidation**[cite: 1, 2].
*   **Logging:** Automated auditing of all blocked access attempts, including IP, Timestamp, and User-Agent[cite: 2].

## 🚦 Features

*   **Country Management:** Add/Remove countries from the blacklist with search and pagination support[cite: 1].
*   **Temporal Blocking:** Block countries for a specific duration (up to 24 hours)[cite: 1].
*   **IP Intelligence:** Real-time IP lookup and automatic block status verification based on caller's location[cite: 2].
*   **API Documentation:** Fully documented and testable via **Swagger UI**.

## 🚀 How to Run
1. Clone the repository.
2. Ensure you have the .NET SDK installed.
3. Run `dotnet run --project BlockedCountry.API`.
4. Open Swagger at `http://localhost:{port}/swagger`.
