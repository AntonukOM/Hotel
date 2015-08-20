using Hotel.Service.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace Hotel.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelService" in both code and config file together.
    [ServiceContract]
    public interface IHotelService
    {
        [OperationContract]
        void ReservRoom(ClientDTO client, HotelDTO hotel, RoomDTO room);

        [OperationContract]
        List<ClientDTO> GetClients();

        [OperationContract]
        List<HotelDTO> GetHotels();

        [OperationContract]
        List<RoomDTO> GetRooms();
    }
}
