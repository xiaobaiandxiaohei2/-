using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepostory bookingRepostory;

        public BookingService(IBookingRepostory bookingRepostory)
        {
            this.bookingRepostory = bookingRepostory;
        }

        public Task<List<BookingInfo>> GetBookings(BookingSearch searchParam)
        {
            return this.bookingRepostory.GetBookings(searchParam);
        }
    }
}
