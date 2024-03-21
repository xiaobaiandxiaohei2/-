using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginModel">登录信息</param>
        /// <returns></returns>
        public Task<AdminInfo> Login(AdminLogin loginModel);
    }
}
