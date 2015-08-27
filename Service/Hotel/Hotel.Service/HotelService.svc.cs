using System.Collections.Generic;
using Hotel.Service.DTOs;
using System.Configuration;
using Hotel.Repository;
using Hotel.Repository.Sql;
using Hotel.Entity;
using System;

namespace Hotel.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelService.svc or HotelService.svc.cs at the Solution Explorer and start debugging.
    public class HotelService : IHotelService
    {
        public List<ClientDTO> GetClients()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelServiceDB"].ConnectionString;
            IClientRepository repository = new ClientRepository(connectionString);
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

        public List<RoomDTO> GetRooms(int hotelId)
        {
            string cs = ConfigurationManager.ConnectionStrings["HotelServiceDB"].ConnectionString;
            IRoomRepository repository = new RoomRepository(cs);
            var rooms = repository.GetRooms(hotelId);
            var roomDTO = new List<RoomDTO>();
            foreach (var room in rooms)
            {
                roomDTO.Add(new RoomDTO()
                {
                    Id = room.Id,
                    ClientId = room.ClientId,
                    HotelId = room.HotelId,
                    Name = room.Name,
                    Approved = room.Approved
                });
            }
            return roomDTO;
        }

        public int GetHotelId(string hotelName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelServiceDB"].ConnectionString;
            IHotelRepository repository = new HotelRepository(connectionString);
            int hotelId = repository.HotelId(hotelName);            
            return hotelId;
        }

        public int GetClientId(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelServiceDB"].ConnectionString;
            IClientRepository repository = new ClientRepository(connectionString);
            int clientId = repository.ClientId(email);
            return clientId;
        }

        public void InsertClient(ClientDTO clientDTO)
        {
            var client = new Client
            {
                FirstName = clientDTO.FirstName,
                LastName = clientDTO.LastName,
                Email = clientDTO.Email,
                Phone = clientDTO.Phone
            };
            string connectionString = ConfigurationManager.ConnectionStrings["HotelServiceDB"].ConnectionString;
            IClientRepository repository = new ClientRepository(connectionString);
            repository.Insert(client);
        }

        public void InsertRoom(RoomDTO roomDTO)
        {
            var room = new Room
            {
                ClientId = roomDTO.ClientId,
                HotelId = roomDTO.HotelId,
                Name = roomDTO.Name,
                Approved = roomDTO.Approved
            };
            string connectionString = ConfigurationManager.ConnectionStrings["HotelServiceDB"].ConnectionString;
            IRoomRepository repository = new RoomRepository(connectionString);
            repository.Insert(room);
        }
    }
}
