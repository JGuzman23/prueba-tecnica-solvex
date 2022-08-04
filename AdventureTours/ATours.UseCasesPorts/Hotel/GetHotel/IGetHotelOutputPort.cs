using ATours.UseCasesDtos.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Hotel.GetAllHotel
{
    public interface IGetHotelOutputPort
    {
        Task GetAllHotellOP(List<HotelParams> model);
        Task GetHotelByNameOP(HotelParams model);

        Task GetHotelByIdOP(HotelParams model);

    }
}
