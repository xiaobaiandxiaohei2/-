using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        [Route("GetBookings")]
        public async Task<IActionResult> GetBookings([FromQuery] BookingSearch searchParam)
        {
            var result = await this.bookingService.GetBookings(searchParam);
            return Ok(result);
        }
    }
}
