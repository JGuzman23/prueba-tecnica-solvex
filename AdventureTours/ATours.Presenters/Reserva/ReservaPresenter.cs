using ATours.Entities.POCOEntities;
using ATours.UseCasesPorts.CreateReserva;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Presenters
{
    public class ReservaPresenter : IReservaOutputPort, IPresenter< string>
    {
        public string Content { get; private set; }
        public List<Reserva> ListContent { get; set; }

        public Task GetByClient(List<Reserva> reservas)
        {
            ListContent = reservas;
            return Task.CompletedTask;
        }

        public Task Handle(int orderId)
        {
            Content = $"Reserva ID:{orderId}";
            return Task.CompletedTask;
        }
    }
}
