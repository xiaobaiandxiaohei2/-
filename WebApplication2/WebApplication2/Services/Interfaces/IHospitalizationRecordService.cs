using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Interfaces
{
    public interface IHospitalizationRecordService
    {
        public Task<List<HospitalizationRecordInfo>> GetHospitalizationRecordInfos(HospitalizationRecordSearch searchParam);
    }
}
