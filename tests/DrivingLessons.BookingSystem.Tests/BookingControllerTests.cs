using DrivingLessons.BookingSystem.API;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DrivingLessons.BookingSystem.Tests
{
    public class BookingControllerTests : IClassFixture<WebApplicationFactory<DrivingLessons.BookingSystem.API.Program>>
    {
        private readonly HttpClient _client;

        public BookingControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Hold_Then_Confirm_Booking_Succeeds()
        {
            var userId = Guid.NewGuid();
            var slotTime = DateTime.UtcNow.AddHours(2).ToString("o");

            // Hold the slot
            var holdResp = await _client.PostAsync($"/api/booking/hold?userId={userId}&slotTime={slotTime}", null);
            Assert.Equal(HttpStatusCode.OK, holdResp.StatusCode);

            // Confirm the slot
            var confirmResp = await _client.PostAsync($"/api/booking/confirm?userId={userId}&slotTime={slotTime}", null);
            Assert.Equal(HttpStatusCode.OK, confirmResp.StatusCode);
        }

        [Fact]
        public async Task Confirming_Unheld_Slot_Returns_BadRequest()
        {
            var userId = Guid.NewGuid();
            var slotTime = DateTime.UtcNow.AddHours(3).ToString("o");

            var resp = await _client.PostAsync($"/api/booking/confirm?userId={userId}&slotTime={slotTime}", null);
            Assert.Equal(HttpStatusCode.BadRequest, resp.StatusCode);
        }
    }
}
