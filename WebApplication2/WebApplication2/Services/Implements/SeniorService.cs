using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class SeniorService : ISeniorService
    {
        private readonly ISeniorRepostory seniorRepostory;
        public SeniorService(ISeniorRepostory seniorRepostory)
        {
            this.seniorRepostory = seniorRepostory;
        }

        public async Task<SeniorInfo> CreateSenior(SeniorInfo seniorInfo)
        {
            return await this.seniorRepostory.CreateSenior(seniorInfo);
        }

        public async Task<List<SeniorInfo>> GetSeniors(SeniorSearch searchParam)
        {
            return await this.seniorRepostory.GetSeniors(searchParam);
        }
    }
}
