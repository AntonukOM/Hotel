using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Entity;
using System.Data.SqlClient;

namespace Hotel.Repository.Sql
{
    public class HotelRepository : IHotelRepository
    {
        private const string SELECT_HOTELS = "SELECT Id, Name FROM Hotel";
        private readonly string _cs;

        public HotelRepository(string cs)
        {
            this._cs = cs;
        }

        public List<Hotels> GetHotels()
        {
            using (var connection = new SqlConnection(this._cs))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = SELECT_HOTELS;

                    using (var reader = command.ExecuteReader())
                    {
                        List<Hotels> sections = new List<Hotels>();
                        while (reader.Read())
                        {
                            Hotels hotel = new Hotels();
                            hotel.Id = (int)reader["Id"];
                            hotel.Name = (string)reader["Name"];                       
                            sections.Add(hotel);
                        }
                        return sections;
                    }
                }
            }
        }
    }
}
