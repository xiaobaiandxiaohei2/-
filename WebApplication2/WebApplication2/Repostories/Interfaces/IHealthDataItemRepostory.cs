using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Interfaces
{
    public interface IHealthDataItemRepostory
    {
        public Task<List<HealthDataItemInfo>> GetHealthDataItemInfos(HealthDataItemSearch searchParam);
    }
}
