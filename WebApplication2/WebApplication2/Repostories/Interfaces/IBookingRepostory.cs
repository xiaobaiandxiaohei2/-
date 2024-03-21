using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Interfaces
{
    public interface IBookingRepostory
    {
        public Task<List<BookingInfo>> GetBookings(BookingSearch searchParam);
    }
}
