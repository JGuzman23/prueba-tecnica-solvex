using ATours.Entities.POCOEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Entities.Interfaces.User
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllClientes();
        
        Task<Cliente> GetClienteById(int id);
        Task CreateClienteAsyc(Cliente model);
        Task UpdateCliente(Cliente model);
    }
}
