using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthDataItemController : ControllerBase
    {
        private readonly IHealthDataItemService healthDataItemService;

        public HealthDataItemController(IHealthDataItemService healthDataItemService)
        {
            this.healthDataItemService = healthDataItemService;
        }

        [HttpGet]
        [Route("GetHealthDataItemInfos")]
        public async Task<IActionResult> GetHealthDataItemInfos([FromQuery] HealthDataItemSearch searchParam)
        {
            var result = await this.healthDataItemService.GetHealthDataItemInfos(searchParam);
            return Ok(result);
        }
    }
}
