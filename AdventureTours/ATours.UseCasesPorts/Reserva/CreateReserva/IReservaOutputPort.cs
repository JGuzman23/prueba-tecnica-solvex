using ATours.Entities.POCOEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.CreateReserva
{
    public interface IReservaOutputPort
    {
        Task Handle(int orderId);
        Task GetByClient(List<Reserva>reservas );
    }
}
