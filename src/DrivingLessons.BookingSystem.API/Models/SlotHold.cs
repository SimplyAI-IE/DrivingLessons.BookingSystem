using System;

namespace DrivingLessons.BookingSystem.API.Models
{
    public class SlotHold
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime SlotTime { get; set; }
        public DateTime HeldAt { get; set; }
        public bool Confirmed { get; set; }
    }
}
