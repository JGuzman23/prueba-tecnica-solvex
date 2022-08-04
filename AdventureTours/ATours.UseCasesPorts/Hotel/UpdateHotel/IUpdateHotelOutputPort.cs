using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Hotel.UpdateHotel
{
    public interface IUpdateHotelOutputPort
    {
        Task Handle(int id);
    }
}
