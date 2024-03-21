using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Interfaces
{
    public interface ICaregiverRepostory
    {
        public Task<List<CaregiverInfo>> GetCaregivers(CaregiverSearch searchParam);
        public Task<CaregiverInfo> CreateCaregiver(CaregiverInfo caregiverInfo);
        public Task<CaregiverInfo> EditCaregiver(CaregiverInfo caregiverInfo);
        public Task<CaregiverInfo> GetCaregiverById(int id);
        public Task<CaregiverInfo> DeleteCaregiver(int id);
    }
}
