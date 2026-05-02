🌍 BlockedCountry Management System

A Production-Ready Backend Solution for Geo-Blocking & IP Management.

This repository contains a robust implementation of a country-blocking system built with .NET 8, following the Clean Architecture pattern to ensure a clear separation of concerns, maintainability, and scalability.

🛠 Technical Architecture & Stack
Architecture: Clean Architecture (Domain, Application, Infrastructure, and API layers).

Storage: High-performance In-Memory storage using ConcurrentDictionary to ensure Thread-Safety in multi-threaded environments.

External Integration: Integrated with ipapi.co via IHttpClientFactory for reliable geolocation data fetching.

Background Tasks: Implemented a Worker Service (Hosted Service) to handle automatic unblocking logic for temporal blocks every 5 minutes.

Validation: Leveraged FluentValidation for strict input schema enforcement (IP formats, Country Codes, etc.).

🌟 Key Features
Dynamic Blocking: Ability to block/unblock countries and list them with full Pagination and Search support.

Temporal Blocking: Supports temporary bans with a maximum duration of 24 hours.

IP Lookup & Verification: Real-time checking if a caller's IP or a specific IP belongs to a blocked region.

Audit Logging: Comprehensive logging of all blocked access attempts, including IP, Timestamp, and User-Agent for security auditing.

API Documentation: Fully documented via Swagger UI for easy testing and integration.

🚀 How to Run
Clone the repository.

Update appsettings.json with your Geolocation API configurations.

Run dotnet build and dotnet run.

Navigate to /swagger to explore the endpoints.
