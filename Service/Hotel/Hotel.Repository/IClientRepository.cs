using Hotel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository
{
    public interface IClientRepository
    {
        List<Client> GetClients();
    }
}
