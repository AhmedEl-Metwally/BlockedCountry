# BlockedCountry Management System

This project is a technical assessment developed using **.NET 8** and **Clean Architecture** principles.

## 🚀 Features Implemented:
- **IP Lookup & Check-Block:** Integration with external Geolocation API (ipapi.co) using `IHttpClientFactory`.
- **Memory Storage:** Efficient country blocking management using `ConcurrentDictionary` for thread-safety.
- **Temporal Blocking:** Automatic unblocking system using a **Background Service** that runs every 1 minutes.
- **Comprehensive Logging:** Tracks all blocked attempts with details like IP, Timestamp, and User-Agent.
- **Validation:** Robust input validation using **FluentValidation**.

## 🛠️ How to Test:
1. Run the project (Swagger will open automatically).
2. Use the `/api/Ips/lookup` endpoint to fetch details for IP `156.202.155.101`.
3. Block a country (e.g., "EG") using `/api/Countries/block`.
4. Verify the block status using `/api/Ips/check-block`.
