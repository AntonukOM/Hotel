using Hotel.Entity;
using System.Collections.Generic;

namespace Hotel.Repository
{
    public interface IRoomRepository
    {
        List<Room> GetRooms();
    }
}
