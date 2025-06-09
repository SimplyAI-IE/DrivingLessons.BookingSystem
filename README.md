![Build](https://github.com/SimplyAI-IE/DrivingLessons.BookingSystem/actions/workflows/dotnet.yml/badge.svg)

# DrivingLessons.BookingSystem

An ASP.NET Core backend for managing driving lesson scheduling, booking, packages, and gifts — built for a young audience (17–25). Supports real-time availability, lesson credits, admin controls, reviews, and gifting.

Live Deployment:  
🌐 [https://drivinglessons-bookingsystem.onrender.com/swagger](https://drivinglessons-bookingsystem.onrender.com/swagger)

---

## ✅ Features

- Standard one-hour lessons at Tralee test centre (€50)
- Lessons always start at HH:15 (e.g., 9:15, 10:15)
- Admin-defined daily availability (1-hour blocks)
- Real-time booking with 10-minute slot hold
- Fully automated slot hold → confirm logic
- Multi-lesson packages with tracked quantity
- Gift codes with email delivery + redemption
- Lesson credits stored in account (no expiry)
- Manual admin override for late changes
- Review system (one per user, for business)
- Swagger API documentation
- CI-tested with GitHub Actions
- Deployed live via Docker → Render

---

## 📦 Booking & Package Rules

- **Lesson Length**: 1 hour @ €50
- **Start Time**: `HH:15` only
- **Credit System**: Purchased lessons stored in account
- **Gift Flow**: Generates email + redemption code
- **Credits**: Cannot expire (EU compliance)
- **Cancellations**:
  - Free ≥ 48 hours
  - Admin only < 48 hours
- **Reviews**: 1 per user, business-wide

---

## 🔧 Developer Setup

```bash
git clone https://github.com/SimplyAI-IE/DrivingLessons.BookingSystem.git
cd DrivingLessons.BookingSystem

# Run locally (no Docker needed)
dotnet restore
dotnet build
dotnet run --project src/DrivingLessons.BookingSystem.API

# Visit local Swagger UI
http://localhost:5006/swagger
Run Tests
bash
Copy
Edit
dotnet test
Covers:

Slot hold logic

Booking confirmation

Expired hold handling

Controller endpoints via WebApplicationFactory

🐳 Docker (Optional)
For local container builds (WSL2 required):

bash
Copy
Edit
cd src/DrivingLessons.BookingSystem.API
docker build -t drivinglessons-api .
docker run -d -p 8080:80 drivinglessons-api
Then visit:
http://localhost:8080/swagger

🚀 Deployment (Render)
Dockerized and hosted at:
https://drivinglessons-bookingsystem.onrender.com/swagger

Free tier

Auto-builds from main branch via GitHub

📁 Project Structure
graphql
Copy
Edit
src/
  └── DrivingLessons.BookingSystem.API/     # Main ASP.NET Core API
tests/
  └── DrivingLessons.BookingSystem.Tests/   # xUnit tests with EF in-memory + controller coverage
🛣️ Roadmap
 Admin UI for managing availability

 Package purchase and payment flow (Stripe, Google Pay)

 Custom domain support

 SMS reminders (optional Twilio)

 Mobile-first frontend (Blazor or JS)

📄 License
MIT License (see LICENSE file)