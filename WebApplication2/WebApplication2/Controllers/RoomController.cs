using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services.Implements;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        [Route("GetRooms")]
        public async Task<IActionResult> GetRooms([FromQuery] RoomSearch searchParam)
        {
            var result = await this.roomService.GetRooms(searchParam);
            return Ok(result);
        }
    }
}
