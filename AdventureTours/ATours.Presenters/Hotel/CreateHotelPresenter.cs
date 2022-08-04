using ATours.UseCasesPorts.Hotel.CreateHotel;
using System.Threading.Tasks;

namespace ATours.Presenters.Hotel
{
    public class CreateHotelPresenter : ICreateHotelOutputPort
    {
        public string Content { get; set; }
        public Task Handle(int hotelId)
        {
            Content = $"Hotel ID:{hotelId}";
            return Task.CompletedTask;
        }
    }
}
