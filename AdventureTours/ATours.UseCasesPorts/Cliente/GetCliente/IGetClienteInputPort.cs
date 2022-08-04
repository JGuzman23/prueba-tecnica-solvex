using ATours.UseCasesDtos.Users.Params;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Cliente.GetCliente
{
    public interface IGetClienteInputPort
    {
        Task GetAllClientes();
        Task GetClienteById(ClienteParams model);
    }
}
