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
    public class CaregiverController : ControllerBase
    {
        private readonly ICaregiverService caregiverService;
        private readonly IMapper mapper;

        public CaregiverController(ICaregiverService caregiverService, IMapper mapper)
        {
            this.caregiverService = caregiverService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetCaregivers")]
        public async Task<IActionResult> GetCaregivers([FromQuery] CaregiverSearch searchParam)
        {
            var result = await this.caregiverService.GetCaregivers(searchParam);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateCaregiver")]
        public async Task<IActionResult> CreateCaregiver([FromBody] CaregiverCreate caregiverCreate)
        {

            var caregiver = mapper.Map<CaregiverInfo>(caregiverCreate);
            caregiver = await caregiverService.CreateCaregiver(caregiver);
            return Ok(caregiver);
        }

        [HttpPut]
        [Route("EditCaregiver/{id}")]
        public async Task<IActionResult> EditCaregiver([FromRoute] int id, [FromBody] CaregiverCreate caregiverCreate)
        {
                var editCaregiver = await this.caregiverService.GetCaregiverById(id);
                if (editCaregiver == null)
                {
                    return NotFound(); // 如果找不到对应id的护工，则返回404 Not Found
                }
                editCaregiver.Name = caregiverCreate.Name;
                editCaregiver.Sex = caregiverCreate.Sex;
                editCaregiver.IdentificationCard = caregiverCreate.IdentificationCard;
                editCaregiver.WorkYears = caregiverCreate.WorkYears;
                editCaregiver.Grade = caregiverCreate.Grade;
                editCaregiver.AvatarPath = caregiverCreate.AvatarPath;
                editCaregiver.Remark = caregiverCreate.Remark;
                editCaregiver.State = caregiverCreate.State;

                await this.caregiverService.EditCaregiver(editCaregiver);
                return Ok(editCaregiver);         
        }

        [HttpDelete]
        [Route("DeleteCaregiver/{id}")]
        public async Task<IActionResult> DeleteCaregiver([FromRoute] int id)
        {
            if (await caregiverService.GetCaregiverById(id) == null)
            {
                return BadRequest("信息不存在");
            }

            try
            {
                return Ok(await caregiverService.DeleteCaregiver(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("删除时出错");
            }
        }
    }
}
