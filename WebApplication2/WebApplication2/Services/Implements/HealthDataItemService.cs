using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class HealthDataItemService : IHealthDataItemService
    {
        private readonly IHealthDataItemRepostory healthDataItemRepostory;

        public HealthDataItemService(IHealthDataItemRepostory healthDataItemRepostory)
        {
            this.healthDataItemRepostory = healthDataItemRepostory;
        }

        public async Task<List<HealthDataItemInfo>> GetHealthDataItemInfos(HealthDataItemSearch searchParam)
        {
            return await this.healthDataItemRepostory.GetHealthDataItemInfos(searchParam);
        }
    }
}
