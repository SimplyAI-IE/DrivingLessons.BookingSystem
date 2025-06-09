using System;

namespace DrivingLessons.BookingSystem.API.Models
{
    public class LessonBooking
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime SlotTime { get; set; }
        public DateTime BookedAt { get; set; }
        public bool IsConfirmed { get; set; }

    }
}
