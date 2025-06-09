using System;
using System.Linq;
using DrivingLessons.BookingSystem.API.Data;
using DrivingLessons.BookingSystem.API.Models;

namespace DrivingLessons.BookingSystem.API.Services
{
    public class SlotService
    {
        private readonly AppDbContext _db;
        private readonly TimeSpan HoldDuration = TimeSpan.FromMinutes(10);

        public SlotService(AppDbContext db)
        {
            _db = db;
        }

        public bool TryHoldSlot(Guid userId, DateTime slotTime)
        {
            var now = DateTime.UtcNow;

            // Check for confirmed booking
            if (_db.LessonBookings.Any(b => b.SlotTime == slotTime))
                return false;

            // Check for active hold
            if (_db.SlotHolds.Any(h => h.SlotTime == slotTime && !h.Confirmed && now - h.HeldAt < HoldDuration))
                return false;

            // Create hold
            _db.SlotHolds.Add(new SlotHold
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                SlotTime = slotTime,
                HeldAt = now,
                Confirmed = false
            });

            _db.SaveChanges();
            return true;
        }

        public bool ConfirmSlot(Guid userId, DateTime slotTime)
        {
            var now = DateTime.UtcNow;

            var hold = _db.SlotHolds
                .FirstOrDefault(h => h.UserId == userId && h.SlotTime == slotTime && !h.Confirmed && now - h.HeldAt < HoldDuration);

            if (hold == null)
                return false;

            hold.Confirmed = true;

            _db.LessonBookings.Add(new LessonBooking
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                SlotTime = slotTime,
                BookedAt = now
            });

            _db.SaveChanges();
            return true;
        }

        public List<LessonBooking> GetAvailableSlots()
        {
            // Replace this with real DB logic if needed
            return new List<LessonBooking>
            {
                new LessonBooking
                {
                    Id = Guid.NewGuid(),
                    SlotTime = DateTime.UtcNow.AddHours(1),
                    IsConfirmed = false
                },
                new LessonBooking
                {
                    Id = Guid.NewGuid(),
                    SlotTime = DateTime.UtcNow.AddHours(2),
                    IsConfirmed = false
                }
            };
        }

        public int CleanupExpiredHolds()
        {
            var threshold = DateTime.UtcNow - HoldDuration;

            var expired = _db.SlotHolds
                .Where(h => !h.Confirmed && h.HeldAt < threshold)
                .ToList();

            if (expired.Any())
            {
                _db.SlotHolds.RemoveRange(expired);
                _db.SaveChanges();
            }

            return expired.Count;
        }
    }
}
