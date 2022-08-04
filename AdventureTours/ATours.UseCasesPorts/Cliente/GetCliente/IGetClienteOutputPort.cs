using ATours.UseCasesDtos.Users.Params;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Cliente.GetCliente
{
    public interface IGetClienteOutputPort
    {
        Task GetClienteByIdOP(ClienteParams model);

        Task GetAllCLientesIdOP(List<ClienteParams> model);
    }
}
