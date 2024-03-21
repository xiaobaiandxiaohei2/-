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
    public class HospitalizationRecordController : ControllerBase
    {
        private readonly IHospitalizationRecordService hospitalizationRecordService;

        public HospitalizationRecordController(IHospitalizationRecordService hospitalizationRecordService)
        {
            this.hospitalizationRecordService = hospitalizationRecordService;
        }

        [HttpGet]
        [Route("GetHospitalizationRecords")]
        public async Task<IActionResult> GetHospitalizationRecords([FromQuery] HospitalizationRecordSearch searchParam)
        {
            var result = await this.hospitalizationRecordService.GetHospitalizationRecordInfos(searchParam);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateHospitalizationRecord")]
        public async Task<IActionResult> CreateHospitalizationRecord([FromBody] CaregiverCreate caregiverCreate)
        {

            //var caregiver = mapper.Map<CaregiverInfo>(caregiverCreate);
            //caregiver = await caregiverService.CreateCaregiver(caregiver);
            //return Ok(caregiver);
            return Ok();
        }
    }
}
