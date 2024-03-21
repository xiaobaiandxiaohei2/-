using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Implenents
{
    public class AdminRepostory : IAdminRepostory
    {
        private readonly NursingDbContext dbcontext;

        public AdminRepostory(NursingDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        #region 管理员登录
        public async Task<AdminInfo> Login(AdminLogin loginModel)
        {
            var admin = await this.dbcontext.adminInfos.SingleOrDefaultAsync(a => a.Phone == loginModel.Phone && a.Password == loginModel.Password);
            return admin;
        }
        #endregion
    }
}
