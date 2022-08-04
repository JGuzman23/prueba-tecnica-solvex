using ATours.UseCasesDtos.CreateReserva;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.CreateReserva
{
    public interface IReservaInputPort
    {
        Task GetByCliente(int id);
        Task Create(CreateReservaParams reserva);
    }
}
