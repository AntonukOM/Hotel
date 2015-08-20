using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Entity;
using System.Data.SqlClient;

namespace Hotel.Repository.Sql
{
    public class ClientRepository : IClientRepository
    {
        private const string SELECT_CLIENTS = "SELECT Id, FirstName, LastName, Email, Phone from Client";
        private readonly string _cs;

        public ClientRepository(string cs)
        {
            this._cs = cs;
        }

        public List<Client> GetClients()
        {
            using (var connection = new SqlConnection(this._cs))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = SELECT_CLIENTS;

                    using (var reader = command.ExecuteReader())
                    {
                        List<Client> sections = new List<Client>();
                        while (reader.Read())
                        {
                            Client client = new Client();
                            client.Id = (int)reader["Id"];
                            client.FirstName = (string)reader["FirstName"];
                            client.LastName = (string)reader["LastName"];
                            client.Email = (string)reader["Email"];
                            client.Phone = (string)reader["Phone"];
                            sections.Add(client);
                        }
                        return sections;
                    }
                }
            }
        }
    }
}
