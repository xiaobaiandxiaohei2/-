using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model.Entity;
using WebApplication2.Services.Implements;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeniorController : ControllerBase
    {
        private readonly ISeniorService seniorService;
        private readonly IMapper mapper;

        public SeniorController(ISeniorService seniorService, IMapper mapper)
        {
            this.seniorService = seniorService;
            this.mapper = mapper;   
        }

        [HttpGet]
        [Route("GetSeniors")]
        public async Task<IActionResult> GetSeniors([FromQuery] SeniorSearch searchParam)
        {
            var result = await this.seniorService.GetSeniors(searchParam);
            return Ok(result);
        }


        [HttpPost]
        [Route("CreateSenior")]
        public async Task<IActionResult> CreateSenior([FromBody] SeniorCreate seniorCreate)
        {

            var senior = mapper.Map<SeniorInfo>(seniorCreate);
            senior = await seniorService.CreateSenior(senior);
            return Ok(senior);
        }
    }
}
