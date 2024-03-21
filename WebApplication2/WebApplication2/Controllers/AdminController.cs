using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService adminService;
        private readonly IMapper mapper;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AdminLogin loginModel)
        {
            var result = await this.adminService.Login(loginModel);
            return (Ok(result));
        }
    }
}
