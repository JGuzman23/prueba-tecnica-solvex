using ATours.UseCasesDtos.Users.Params;
using ATours.UseCasesPorts.Cliente.GetCliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Presenters.Cliente
{
    public class GetClientePresenter : IGetClienteOutputPort
    {
        public ClienteParams Content { get; private set; }
        public List<ClienteParams> ListContent { get; private set; }

        public Task GetAllCLientesIdOP(List<ClienteParams> listmodel)
        {
            ListContent = listmodel;
            return Task.CompletedTask;
        }

        public Task GetClienteByIdOP(ClienteParams model)
        {
            Content = model;
            return Task.CompletedTask;
        }

       
    }
}
