using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;
using System;


namespace WebApplication2.Repostories.Implenents
{
    public class HospitalizationRecordRepostory : IHospitalizationRecordRepostory
    {
        private readonly NursingDbContext dbContext;

        public HospitalizationRecordRepostory(NursingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region 入住查询
        public async Task<List<HospitalizationRecordInfo>> GetHospitalizationRecordInfos(HospitalizationRecordSearch searchParam)
        {
            IQueryable<HospitalizationRecordInfo> query = this.dbContext.hospitalizationRecordInfos;

          
            if (searchParam.StartTime != null)
            {
                query = query.Where(a => a.EnterTime >= searchParam.StartTime);
            }
            if (searchParam.EndTime != null)
            {
                query = query.Where(a => a.EnterTime <= searchParam.EndTime);
            }
            if (!string.IsNullOrEmpty(searchParam.keyword))
            {
                query = query.Where(a => a.RoomInfo.RoomNumber.ToLower().Contains(searchParam.keyword.ToLower()) || a.CaregiverInfo.Name.ToLower().Contains(searchParam.keyword.ToLower())
                || a.SeniorInfo.Name.ToLower().Contains(searchParam.keyword.ToLower()) || a.GuardianInfo.Name.ToLower().Contains(searchParam.keyword.ToLower()));
            }
            return await query.Include(a => a.CaregiverInfo).Include(a=>a.RoomInfo).Include(a=>a.GuardianInfo).Include(a=>a.SeniorInfo).ToListAsync();
        }
        #endregion
    }
}
