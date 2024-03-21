using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Implenents
{
    public class HealthDataItemRepostory : IHealthDataItemRepostory
    {
        private readonly NursingDbContext dbContext;

        public HealthDataItemRepostory(NursingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region 健康项目查询
        public async Task<List<HealthDataItemInfo>> GetHealthDataItemInfos(HealthDataItemSearch searchParam)
        {
            IQueryable<HealthDataItemInfo> query = this.dbContext.healthDataItemInfos;

            if (!string.IsNullOrEmpty(searchParam.keyword))
            {
                query = query.Where(a => a.Name.ToLower().Contains(searchParam.keyword.ToLower()));
            }

            return await query.ToListAsync();
        }
        #endregion
    }
}
