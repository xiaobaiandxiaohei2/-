using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class HospitalizationService : IHospitalizationRecordService
    {
        private readonly IHospitalizationRecordRepostory hospitalizationRecordRepostory;

        public HospitalizationService(IHospitalizationRecordRepostory hospitalizationRecordRepostory)
        {
            this.hospitalizationRecordRepostory = hospitalizationRecordRepostory;
        }

        public Task<List<HospitalizationRecordInfo>> GetHospitalizationRecordInfos(HospitalizationRecordSearch searchParam)
        {
            return this.hospitalizationRecordRepostory.GetHospitalizationRecordInfos(searchParam);
        }
    }
}
