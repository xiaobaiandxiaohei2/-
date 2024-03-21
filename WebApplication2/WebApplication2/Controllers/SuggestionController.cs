using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionService suggestionService;

        public SuggestionController(ISuggestionService suggestionService)
        {
            this.suggestionService = suggestionService;
        }

        [HttpGet]
        [Route("GetSuggestions")]
        public async Task<IActionResult> GetSuggestions([FromQuery] SuggestionSearch searchParam)
        {
            var result = await this.suggestionService.GetSuggestions(searchParam);
            return Ok(result);
        }
    }
}
