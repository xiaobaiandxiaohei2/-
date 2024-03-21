using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Interfaces
{
    public interface IRoomService
    {
        public Task<List<RoomInfo>> GetRooms(RoomSearch searchParam);
    }
}
