using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepostory roomRepostory;

        public RoomService(IRoomRepostory roomRepostory)
        {
            this.roomRepostory = roomRepostory;
        }

        public async Task<List<RoomInfo>> GetRooms(RoomSearch searchParam)
        {
             return await this.roomRepostory.GetRooms(searchParam);
        }
    }
}
