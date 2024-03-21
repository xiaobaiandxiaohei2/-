using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Interfaces
{
    /// <summary>
    /// 老人信息
    /// </summary>
    public interface ISeniorService
    {
        public Task<List<SeniorInfo>> GetSeniors(SeniorSearch searchParam);

        public Task<SeniorInfo> CreateSenior(SeniorInfo seniorInfo);
    }
}
