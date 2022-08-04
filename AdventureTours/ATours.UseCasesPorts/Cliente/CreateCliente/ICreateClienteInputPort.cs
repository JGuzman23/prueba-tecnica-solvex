using ATours.UseCasesDtos.Users.Params;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Users.CreateUsers
{
    public interface ICreateClienteInputPort
    {
        Task Create(ClienteParams model);
        Task Update(ClienteParams model);
    }
}
