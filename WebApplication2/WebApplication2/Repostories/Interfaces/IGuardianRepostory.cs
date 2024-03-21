using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Interfaces
{
    public interface IGuardianRepostory
    {
        public Task<List<GuardianInfo>> GetGuardians(GuardianSearch searchParam);
        public Task<GuardianInfo> CreateGuardian(GuardianInfo guardianInfo);
    }
}
