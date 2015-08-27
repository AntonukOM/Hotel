using System;
using System.Collections.Generic;
using Hotel.Entity;
using System.Data.SqlClient;

namespace Hotel.Repository.Sql
{
    public class ClientRepository : IClientRepository
    {
        private const string SELECT_CLIENTS = "SELECT Id, FirstName, LastName, Email, Phone from Client";
        private readonly string _connectionString;

        public ClientRepository(string cs)
        {
            this._connectionString = cs;
        }

        public int ClientId(string email)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id FROM Client WHERE Email = \'" + email + "\'";
                    using (var reader = command.ExecuteReader())
                    {
                        int id = 0;
                        while (reader.Read())
                        {
                            id = (int)reader["Id"];
                        }
                        return id;
                    }
                }
            }
        }

        public List<Client> GetClients()
        {
            using (var connection = new SqlConnection(this._connectionString))
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
                            client.Phone = Convert.ToString(reader["Phone"]);
                            sections.Add(client);
                        }
                        return sections;
                    }
                }
            }
        }

        public void Insert(Client client)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();
                string commandText =
                       "INSERT INTO Client(FirstName, LastName, Email, Phone) VALUES ('"
                       + client.FirstName + "', '" + client.LastName + "', '"
                       + client.Email + "', '" + client.Phone + "');";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }             
            }
        }
    }
}
