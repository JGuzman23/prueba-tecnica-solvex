using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Hotel.CreateHotel
{
    public interface ICreateHotelOutputPort
    {
        Task Handle(int hotelId);
    }
}
