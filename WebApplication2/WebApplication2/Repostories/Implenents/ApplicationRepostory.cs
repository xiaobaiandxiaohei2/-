using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Implenents
{
    public class ApplicationRepostory : IApplicationRepostory
    {
        private readonly NursingDbContext dbContext;

        public ApplicationRepostory(NursingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region 申请查询
        public async Task<List<ApplicationInfo>> GetApplicationInfos()
        {
            IQueryable<ApplicationInfo> query = this.dbContext.applicationInfos;

            //if (!string.IsNullOrEmpty(searchParam.State))
            //{
            //    query = query.Where(a => a.State.ToLower() == searchParam.State.ToLower());
            //}
            return await query.Include(a=>a.GuardianInfo).Include(a=>a.SeniorInfo).Include(a=>a.AdminInfo).ToListAsync();
        }
        #endregion
    }
}
