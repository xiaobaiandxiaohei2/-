using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Implenents
{
    public class CaregiverRepostory : ICaregiverRepostory
    {
        private readonly NursingDbContext dbContext;
        public CaregiverRepostory(NursingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region 新建护工
        public async Task<CaregiverInfo> CreateCaregiver(CaregiverInfo caregiverInfo)
        {
            await dbContext.caregiverInfos.AddAsync(caregiverInfo);
            await dbContext.SaveChangesAsync();
            return caregiverInfo;
        }
        #endregion

        #region 查找护工
        public async Task<List<CaregiverInfo>> GetCaregivers(CaregiverSearch searchParam)
        {

            IQueryable<CaregiverInfo> query = this.dbContext.caregiverInfos;

            if (!string.IsNullOrEmpty(searchParam.keyword))
            {
                query = query.Where(a => a.Name .ToLower().Contains(searchParam.keyword .ToLower()) ||
                a.IdentificationCard.ToLower().Contains(searchParam.keyword.ToLower()));
            }
            if(searchParam.Grade!=null)
            {
                query = query.Where(a => a.Grade == searchParam.Grade);
            }
            if (!string.IsNullOrEmpty(searchParam.State))
            {
                query = query.Where(a => a.State .ToLower() == searchParam.State .ToLower());
            }
            if (!string.IsNullOrEmpty(searchParam.Sex))
            {
                query = query.Where(a => a.Sex.ToLower() == searchParam.Sex.ToLower());
            }

            return await query.ToListAsync();
        }
        #endregion

        #region 编辑护工
        public async Task<CaregiverInfo> EditCaregiver(CaregiverInfo caregiverInfo)
        {
            dbContext.Entry<CaregiverInfo>(caregiverInfo).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return caregiverInfo;
        }
        #endregion

        #region id查找
        public async Task<CaregiverInfo> GetCaregiverById(int id)
        {
            IQueryable<CaregiverInfo> query = this.dbContext.caregiverInfos;
            return await query.SingleAsync(a => a.Id == id);
        }
        #endregion

        #region 删除
        public async Task<CaregiverInfo> DeleteCaregiver(int id)
        {
            var caregiver = await GetCaregiverById(id);
            this.dbContext.caregiverInfos.Remove(caregiver);
            await this.dbContext.SaveChangesAsync();
            return caregiver;
        }
        #endregion
    }
}
