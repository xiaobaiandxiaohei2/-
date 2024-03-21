using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepostory adminRepostory;

        public AdminService(IAdminRepostory adminRepostory)
        {
            this.adminRepostory = adminRepostory;
        }

        public async Task<AdminInfo> Login(AdminLogin loginModel)
        {
            return await this.adminRepostory.Login(loginModel);
        }
    }
}
