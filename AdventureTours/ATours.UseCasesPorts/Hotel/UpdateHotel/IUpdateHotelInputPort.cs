using ATours.UseCasesDtos.Hotel;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Hotel.UpdateHotel
{
    public interface IUpdateHotelInputPort
    {
        Task Handle(HotelParams hotel, int id);
    }
}
