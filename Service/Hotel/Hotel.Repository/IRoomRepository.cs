using Hotel.Entity;
using System.Collections.Generic;

namespace Hotel.Repository
{
    public interface IRoomRepository
    {
        List<Room> GetRooms();
        List<Room> GetRooms(int hotelId);
        void Insert(Room room);
    }
}
