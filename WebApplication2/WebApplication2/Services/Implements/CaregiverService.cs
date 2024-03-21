using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class CaregiverService : ICaregiverService
    {
        private readonly ICaregiverRepostory caregiverRepostory;

        public CaregiverService(ICaregiverRepostory caregiverRepostory)
        {
            this.caregiverRepostory = caregiverRepostory;
        }

        public Task<CaregiverInfo> CreateCaregiver(CaregiverInfo caregiverInfo)
        {
            return this.caregiverRepostory.CreateCaregiver(caregiverInfo);
        }

        public Task<CaregiverInfo> DeleteCaregiver(int id)
        {
            return this.caregiverRepostory.DeleteCaregiver(id);
        }

        public Task<CaregiverInfo> EditCaregiver(CaregiverInfo caregiverInfo)
        {
            return this.caregiverRepostory.EditCaregiver(caregiverInfo);
        }

        public Task<CaregiverInfo> GetCaregiverById(int id)
        {
            return this.caregiverRepostory.GetCaregiverById(id);
        }

        public Task<List<CaregiverInfo>> GetCaregivers(CaregiverSearch searchParam)
        {
            return this.caregiverRepostory.GetCaregivers(searchParam);
        }
    }
}
