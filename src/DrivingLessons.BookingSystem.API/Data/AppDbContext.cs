using Microsoft.EntityFrameworkCore;
using DrivingLessons.BookingSystem.API.Models;

namespace DrivingLessons.BookingSystem.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SlotHold> SlotHolds { get; set; }
        public DbSet<LessonBooking> LessonBookings { get; set; }
    }
}
