using ATours.UseCasesDtos.Hotel;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Hotel.CreateHotel
{
    public  interface ICreateHotelInputPort
    {
        Task Handle(HotelParams model);
    }
}
