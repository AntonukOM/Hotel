using Hotel.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Hotel.Repository.Sql
{
    public class RoomRepository : IRoomRepository
    {
        private const string SELECT_ROOM =
            "SELECT Id, ClientId, HotelId, Name, ReservationStatus FROM Room";
        private readonly string _connectionString;

        public RoomRepository(string cs)
        {
            this._connectionString = cs;
        }

        public List<Room> GetRooms()
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = SELECT_ROOM;
                    using (var reader = command.ExecuteReader())
                    {
                        List<Room> sections = new List<Room>();
                        while (reader.Read())
                        {
                            Room room = new Room();
                            room.Id = (int)reader["Id"];
                            room.ClientId = (int)reader["ClientId"];
                            room.HotelId = (int)reader["HotelId"];
                            room.Name = (string)reader["Name"];
                            room.Approved = (bool)reader["ReservationStatus"];                            
                            sections.Add(room);
                        }
                        return sections;
                    }
                }
            }
        }

        public List<Room> GetRooms(int hotelId)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id, ClientId, HotelId, Name, ReservationStatus FROM Room"
                        + " WHERE HotelId = " + hotelId;
                    using (var reader = command.ExecuteReader())
                    {
                        List<Room> sections = new List<Room>();
                        while (reader.Read())
                        {
                            Room room = new Room();
                            room.Id = (int)reader["Id"];
                            room.ClientId = (int)reader["ClientId"];
                            room.HotelId = (int)reader["HotelId"];
                            room.Name = (string)reader["Name"];
                            room.Approved = (bool)reader["ReservationStatus"];
                            //room.Approved = reader.GetBoolean(reader.GetOrdinal("ReservationStatus")); //invalid cast exeption
                            sections.Add(room);
                        }
                        return sections;
                    }
                }
            }
        }

        public void Insert(Room room)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();
                string commandText =
                       "INSERT INTO Room(ClientId, HotelId, Name, ReservationStatus) VALUES ("
                       + room.ClientId + "," + room.HotelId + ", '" 
                       + room.Name + "', '" + room.Approved + "')";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}