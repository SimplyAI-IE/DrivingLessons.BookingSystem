using System;
using Microsoft.AspNetCore.Mvc;
using DrivingLessons.BookingSystem.API.Services;

namespace DrivingLessons.BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly SlotService _slotService;

        public BookingController(SlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpGet("slots")]
        public IActionResult GetAvailableSlots()
        {
            var slots = _slotService.GetAvailableSlots(); // assumes this method exists
            return Ok(slots);
        }

        [HttpPost("hold")]
        public IActionResult HoldSlot(Guid userId, DateTime slotTime)
        {
            var success = _slotService.TryHoldSlot(userId, slotTime);
            return success ? Ok("Slot held") : Conflict("Slot unavailable");
        }

        [HttpPost("confirm")]
        public IActionResult ConfirmSlot(Guid userId, DateTime slotTime)
        {
            var success = _slotService.ConfirmSlot(userId, slotTime);
            return success ? Ok("Booking confirmed") : BadRequest("Invalid or expired hold");
        }

        [HttpPost("cleanup")]
        public IActionResult Cleanup()
        {
            var removed = _slotService.CleanupExpiredHolds();
            return Ok($"{removed} expired holds removed");
        }
    }
}
