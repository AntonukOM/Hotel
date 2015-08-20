using Hotel.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel.Repository.Sql
{
    public class RoomRepository : IRoomRepository
    {
        private const string SELECT_ROOM =
            "SELECT Id, ClientId, HotelId, ReservationBegin, ReservationEnd, ReservationStatus from Room;";
        private readonly string _cs;

        public RoomRepository(string cs)
        {
            this._cs = cs;
        }

        public List<Room> GetRooms()
        {
            using (var connection = new SqlConnection(this._cs))
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
                            room.HotelId = (int)reader["HotelId"];
                            room.ClientId = (int)reader["ClientId"];
                            room.ReservationBegin = (DateTime)reader["ReservationBegin"];
                            room.ReservationEnd = (DateTime)reader["ReservationEnd"];
                            room.Approved = (bool)reader["Status"];
                            sections.Add(room);
                        }
                        return sections;
                    }
                }
            }
        }
    }

}