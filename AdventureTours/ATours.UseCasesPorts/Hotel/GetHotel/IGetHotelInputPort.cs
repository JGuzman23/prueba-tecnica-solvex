using ATours.UseCasesDtos.Hotel;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Hotel.GetAllHotel
{
    public interface IGetHotelInputPort
    {
        Task GetAllHotell();
        Task GetHotelById(int id);
        Task GetHotelByName(HotelParams model);

    }
}
