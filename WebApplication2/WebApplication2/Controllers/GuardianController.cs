using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianService guardianService;
        private readonly IMapper mapper;

        public GuardianController(IGuardianService guardianService,IMapper mapper)
        {
            this.guardianService = guardianService;
            this.mapper = mapper;
        }

    
        [HttpGet]
        [Route("GetGuardians")]
        public async Task<IActionResult> GetGuardians([FromQuery] GuardianSearch searchParam)
        {
            var result = await this.guardianService.GetGuardians(searchParam);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateGuardian")]
        public async Task<IActionResult> CreateGuardian([FromBody] CreateGuardian createGuardian)
        {

            var guardian = mapper.Map<GuardianInfo>(createGuardian);
            guardian = await guardianService.CreateGuardian(guardian);

            return Ok(guardian);
        }
    }
}