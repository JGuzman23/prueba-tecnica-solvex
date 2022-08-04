using ATours.UseCasesPorts.Hotel.UpdateHotel;
using System.Threading.Tasks;

namespace ATours.Presenters.Hotel
{
    public class UpdateHotelPresenter : IUpdateHotelOutputPort
    {
        public string Content { get; private set; }
        public Task Handle(int id)
        {
            Content = $"Id hotel{id}";

            return Task.CompletedTask;
        }
    }
}
