using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Implenents
{
    public class SeniorRepostory : ISeniorRepostory
    {
        private readonly NursingDbContext dbContext;

        public SeniorRepostory(NursingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SeniorInfo> CreateSenior(SeniorInfo seniorInfo)
        {
            await dbContext.seniorInfos.AddAsync(seniorInfo);
            await dbContext.SaveChangesAsync();
            return seniorInfo;
        }

        #region 老人查询
        public async Task<List<SeniorInfo>> GetSeniors(SeniorSearch searchParam)
        {
            IQueryable<SeniorInfo> query = this.dbContext.seniorInfos;

            if (!string.IsNullOrEmpty(searchParam.keyword))
            {
                query = query.Where(a => a.Name.ToLower().Contains(searchParam.keyword.ToLower()) ||
                a.IdentityCard.ToLower().Contains(searchParam.keyword.ToLower()));
            }
            return await query.ToListAsync();
        }
        #endregion
    }
}
