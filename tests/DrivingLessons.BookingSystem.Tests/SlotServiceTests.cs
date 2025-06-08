using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using DrivingLessons.BookingSystem.API.Data;
using DrivingLessons.BookingSystem.API.Services;

namespace DrivingLessons.BookingSystem.Tests
{
    public class SlotServiceTests
    {
        private AppDbContext GetInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public void CanHoldSlot_WhenSlotIsAvailable()
        {
            var db = GetInMemoryDb();
            var service = new SlotService(db);
            var result = service.TryHoldSlot(Guid.NewGuid(), DateTime.UtcNow.AddHours(1));
            Assert.True(result);
        }

        [Fact]
        public void CannotHoldSlot_WhenSlotAlreadyBooked()
        {
            var db = GetInMemoryDb();
            var service = new SlotService(db);
            var userId = Guid.NewGuid();
            var slotTime = DateTime.UtcNow.AddHours(1);

            // Book it
            service.TryHoldSlot(userId, slotTime);
            service.ConfirmSlot(userId, slotTime);

            // Try holding again
            var result = service.TryHoldSlot(Guid.NewGuid(), slotTime);
            Assert.False(result);
        }

        [Fact]
        public void ConfirmSlot_ReturnsFalse_IfHoldExpired()
        {
            var db = GetInMemoryDb();
            var service = new SlotService(db);
            var userId = Guid.NewGuid();
            var slotTime = DateTime.UtcNow.AddHours(1);

            service.TryHoldSlot(userId, slotTime);

            // Simulate expiration
            var hold = db.SlotHolds.First();
            hold.HeldAt = DateTime.UtcNow.AddMinutes(-11);
            db.SaveChanges();

            var result = service.ConfirmSlot(userId, slotTime);
            Assert.False(result);
        }
    }
}
