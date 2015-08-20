using System.Collections.Generic;
using Hotel.Service.DTOs;
using System.Configuration;
using Hotel.Repository;
using Hotel.Repository.Sql;
using System;

namespace Hotel.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelService.svc or HotelService.svc.cs at the Solution Explorer and start debugging.
    public class HotelService : IHotelService
    {
        public List<ClientDTO> GetClients()
        {
            string cs = ConfigurationManager.ConnectionStrings["HotelServiceDB"].ConnectionString;
            IClientRepository repository = new ClientRepository(cs);
            var clients = repository.GetClients();
            var clientsDTO = new List<ClientDTO>();
            foreach (var client in clients)
            {
                clientsDTO.Add(new ClientDTO()
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    Phone = client.Phone
                });
            }
            return clientsDTO;
        }

        public List<HotelDTO> GetHotels()
        {
            string cs = ConfigurationManager.ConnectionStrings["HotelServiceDB"].ConnectionString;
            IHotelRepository repository = new HotelRepository(cs);
            var hotels = repository.GetHotels();
            var hotelDTO = new List<HotelDTO>();
            foreach (var hotel in hotels)
            {
                hotelDTO.Add(new HotelDTO()
                {
                    Id = hotel.Id,
                    Name = hotel.Name
                });
            }
            return hotelDTO;
        }

        public List<RoomDTO> GetRooms()
        {
            string cs = ConfigurationManager.ConnectionStrings["HotelServiceDB"].ConnectionString;
            IRoomRepository repository = new RoomRepository(cs);
            var rooms = repository.GetRooms();
            var roomDTO = new List<RoomDTO>();
            foreach (var room in rooms)
            {
                roomDTO.Add(new RoomDTO()
                {
                    Id = room.Id,
                    ClientId = room.ClientId,
                    HotelId = room.HotelId,
                    ReservationBegin = room.ReservationBegin,
                    ReservationEnd = room.ReservationEnd,
                    Approved = room.Approved
                });
            }           
            return roomDTO;
        }

        public void ReservRoom(ClientDTO client, HotelDTO hotel, RoomDTO room)
        {
            List<ClientDTO> clientsList = GetClients();
            List<HotelDTO> hotelList = GetHotels();
            List<RoomDTO> roomList = GetRooms();

            clientsList.Add(client);

            //search room in a hotel
            RoomDTO r = roomList.Find(x => room.HotelId == hotel.Id);

            //set clientId into free room
            r.ClientId = client.Id;
            r.Approved = true;

            //save changes
            room = r;
        }
    }
}
