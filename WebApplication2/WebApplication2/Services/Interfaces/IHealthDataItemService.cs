using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Interfaces
{
    public interface IHealthDataItemService
    {
        public Task<List<HealthDataItemInfo>> GetHealthDataItemInfos(HealthDataItemSearch searchParam);
    }
}
