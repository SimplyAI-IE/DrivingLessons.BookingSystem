![Build](https://github.com/SimplyAI-IE/DrivingLessons.BookingSystem/actions/workflows/dotnet.yml/badge.svg)

# DrivingLessons.BookingSystem

An ASP.NET Core backend and React frontend for managing driving lesson scheduling, booking, packages, and gifting — built for a young audience (17–25). Supports real-time availability, lesson credits, admin controls, reviews, and gifting.

**Live API:**  
🌐 https://drivinglessons-bookingsystem.onrender.com/swagger

**Live Frontend:**  
🌐 _[Add Vercel/Render link when deployed]_

---

## ✅ Features

- One-hour lessons at Tralee test centre (€50)
- Lessons start on the :15 (e.g., 9:15, 10:15)
- Admin-defined daily availability
- Real-time booking with 10-minute hold window
- Multi-lesson packages with stored credit
- Gift codes via email (redeemable in account)
- Admin override for late changes
- Review system (1 review per user)
- CI via GitHub Actions
- Live Dockerized deployment to Render
- Frontend built with React + Vite

---

## 📦 Booking & Package Rules

- **Lesson Length**: 1 hour @ €50
- **Start Time**: HH:15
- **Credit System**: Non-expiring lesson credits
- **Gift Flow**: Email-based redemption codes
- **Cancellations**:
  - Free ≥ 48 hours
  - Admin override < 48 hours
- **Reviews**: One per user, business-wide

---

## 🔧 Developer Setup

### Backend (ASP.NET Core)

```bash
git clone https://github.com/SimplyAI-IE/DrivingLessons.BookingSystem.git
cd DrivingLessons.BookingSystem
dotnet restore
dotnet build
dotnet run --project src/DrivingLessons.BookingSystem.API
Then open:

bash
Copy
Edit
http://localhost:5000/swagger
Frontend (React + Vite)
bash
Copy
Edit
cd frontend
npm install
npm run dev
Open:

bash
Copy
Edit
http://localhost:5173/book
http://localhost:5173/admin
✅ Run Tests
bash
Copy
Edit
dotnet test
Tests include:

Slot hold + expiration logic

Confirmations

Controller coverage via WebApplicationFactory

🐳 Docker (Optional)
For running the backend via Docker:

bash
Copy
Edit
cd src/DrivingLessons.BookingSystem.API
docker build -t drivinglessons-api .
docker run -d -p 8080:80 drivinglessons-api
Visit:

bash
Copy
Edit
http://localhost:8080/swagger
🚀 Deployment (Render)
Backend (API)
Dockerized

Auto-deploy from main

Hosted at:
https://drivinglessons-bookingsystem.onrender.com

Frontend (Static Site)
Built with Vite

Deployed via Render Static Site

Root Directory: frontend

Build Command:

arduino
Copy
Edit
npm install && npm run build
Publish Directory:

nginx
Copy
Edit
dist
📁 Project Structure
bash
Copy
Edit
frontend/                              # React + Vite frontend
  ├── pages/                           # React pages: /book, /admin, /add-slot
  └── ...

src/
  └── DrivingLessons.BookingSystem.API/  # ASP.NET Core API

tests/
  └── DrivingLessons.BookingSystem.Tests/ # xUnit integration tests
🛣️ Roadmap
✅ Booking and admin UI

🔜 Stripe & Google Pay for payments

🔜 Custom domain support

🔜 SMS reminders (Twilio)

🔜 Mobile-first redesign (React or Blazor)

📄 License
MIT License (see LICENSE)