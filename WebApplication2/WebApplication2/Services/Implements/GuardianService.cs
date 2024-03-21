using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class GuardianService : IGuardianService
    {
        private readonly IGuardianRepostory guardianRepostory;

        public GuardianService(IGuardianRepostory guardianRepostory)
        {
            this.guardianRepostory = guardianRepostory;
        }

        public async Task<GuardianInfo> CreateGuardian(GuardianInfo guardianInfo)
        {
            return await this.guardianRepostory.CreateGuardian(guardianInfo);
        }

        public async Task<List<GuardianInfo>> GetGuardians(GuardianSearch searchParam)
        {
            return await this.guardianRepostory.GetGuardians(searchParam);
        }
    }
}
