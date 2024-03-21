using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Implenents
{
    public class RoomRepostory : IRoomRepostory
    {
        private readonly NursingDbContext dbContext;

        public RoomRepostory(NursingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region 房间查询
        public async Task<List<RoomInfo>> GetRooms(RoomSearch searchParam)
        {
            IQueryable<RoomInfo> query = this.dbContext.roomInfos;

            if (!string.IsNullOrEmpty(searchParam.RoomNumber))
            {
                query = query.Where(a => a.RoomNumber.ToLower().Contains(searchParam.RoomNumber.ToLower()));
            }
            if (!string.IsNullOrEmpty(searchParam.State))
            {
                query = query.Where(a => a.State.ToLower().Contains(searchParam.State.ToLower()));
            }

            return await query.ToListAsync();
        }
        #endregion
    }
}
