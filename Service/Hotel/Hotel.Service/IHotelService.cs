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
        List<ClientDTO> GetClients();

        [OperationContract]
        List<HotelDTO> GetHotels();

        [OperationContract]
        List<RoomDTO> GetRooms(int hotelId);

        [OperationContract]
        int GetHotelId(string hotelName);

        [OperationContract]
        int GetClientId(string email);

        [OperationContract]
        void InsertClient(ClientDTO client);

        [OperationContract]
        void InsertRoom(RoomDTO room);
    }
}
