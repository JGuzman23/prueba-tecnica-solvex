using ATours.UseCasesPorts.Users.CreateUsers;
using System.Threading.Tasks;

namespace ATours.Presenters.Cliente
{
    public class CreateClientePresenter : ICreateClienteOutputPort
    {
        public string Content { get; set; }
        public Task Handle()
        {

            return Task.CompletedTask;
        }
    }
}
