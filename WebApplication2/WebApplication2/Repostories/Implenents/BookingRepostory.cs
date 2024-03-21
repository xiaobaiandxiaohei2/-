using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Implenents
{
    public class BookingRepostory : IBookingRepostory
    {
        private readonly NursingDbContext dbContext;

        public BookingRepostory(NursingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region 预约查询
        public async Task<List<BookingInfo>> GetBookings(BookingSearch searchParam)
        {
            IQueryable<BookingInfo> query = this.dbContext.bookingInfos;

            //if (!string.IsNullOrEmpty(searchParam.State))
            //{
            //    query = query.Where(a => a.State .ToLower() == searchParam.State.ToLower());
            //}
            if (!string.IsNullOrEmpty(searchParam.keyword))
            {
                query = query.Where(a => a.Phone.ToLower().Contains(searchParam.keyword.ToLower()));
            }
            //if(searchParam.StartTime != null)
            //{
            //    query = query.Where(a => a.BookingTime >= searchParam.StartTime);
            //}
            //if(searchParam.EndTime != null)
            //{
            //    query = query.Where(a => a.BookingTime <= searchParam.EndTime);
            //}
            return await query.Include(a=>a.GuardianInfo).Include(a=>a.RoomInfo).Include(a=>a.AdminInfo).ToListAsync();
        }
        #endregion
    }
}
