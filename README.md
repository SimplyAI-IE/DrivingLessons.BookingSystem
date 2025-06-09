# DrivingLessons.BookingSystem

An ASP.NET Core backend for managing driving lesson scheduling, booking, and packages — built for a young audience (17–25). Supports real-time availability, credits, admin controls, and gifting.

---

## Features

- ✅ One-hour standard lessons at the Tralee test centre
- ✅ Real-time booking with 10-minute slot hold
- ✅ Admin-defined availability (1-hour blocks at HH:15)
- ✅ Multi-lesson packages with quantity tracking
- ✅ Gift system with code generation and redemption
- ✅ Google Auth for users; Google Pay/Stripe for payments
- ✅ Review system (1 per user)
- ✅ Full cancellation/reschedule rules
- ✅ API-first with Swagger UI and automated tests

---

## Booking Rules

- **Standard Lesson**: 1 hour @ €50
- **Start times**: `HH:15` only (e.g., 9:15, 10:15)
- **Credits**: Package purchases give stored lessons
- **Free Cancellation**: 48+ hours
- **Admin-Only Changes**: <48 hours
- **Gift Codes**: Sent via email; redeem after account creation
- **Lesson Credits**: Cannot expire (EU law)

---

## Developer Setup

```bash
dotnet restore
dotnet build
dotnet run --project src/DrivingLessons.BookingSystem.API
Visit: http://localhost:5006/swagger

Run tests:

bash
Copy
Edit
dotnet test
Project Structure
bash
Copy
Edit
src/
  └── DrivingLessons.BookingSystem.API/     # ASP.NET Core API
tests/
  └── DrivingLessons.BookingSystem.Tests/   # xUnit tests
Roadmap
 Admin UI for managing availability

 Package purchase/payment flow

 Mobile-friendly frontend

 SMS reminders (future)

yaml
Copy
Edit

---

Copy/paste this into `README.md`, commit with:

```bash
git add README.md
git commit -m "Add project specification to README"
git push