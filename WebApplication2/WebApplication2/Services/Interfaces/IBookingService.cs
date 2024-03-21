using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Interfaces
{
    public interface IBookingService
    {
        public Task<List<BookingInfo>> GetBookings(BookingSearch searchParam);
    }
}
