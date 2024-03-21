using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Implenents
{
    public class GuardianRepostory : IGuardianRepostory
    {
        private readonly NursingDbContext dbContext;
        public GuardianRepostory(NursingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region 添加监护人
        public async Task<GuardianInfo> CreateGuardian(GuardianInfo guardianInfo)
        {
            await dbContext.guardianInfos.AddAsync(guardianInfo);
            await dbContext.SaveChangesAsync();
            return guardianInfo;
        }
        #endregion


        #region 监护人查询
        public async Task<List<GuardianInfo>> GetGuardians(GuardianSearch searchParam)
        {
            IQueryable<GuardianInfo> query = this.dbContext.guardianInfos;

            if (!string.IsNullOrEmpty(searchParam.keyword ))
            {
                query = query.Where(a => a.Name.ToLower().Contains(searchParam.keyword.ToLower()) ||
                a.IdentificationCard.ToLower().Contains(searchParam.keyword.ToLower()));
            }
            return await query.ToListAsync();
        }
        #endregion
    }
}
