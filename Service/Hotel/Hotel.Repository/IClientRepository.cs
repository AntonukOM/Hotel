using Hotel.Entity;
using System.Collections.Generic;

namespace Hotel.Repository
{
    public interface IClientRepository
    {
        List<Client> GetClients();
        int ClientId(string email);
        void Insert(Client client);
    }
}
