using ATours.Entities.POCOEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Entities.Interfaces
{
    public interface IHotelRepository
    {
        void Create(Hotel hotel);
        Task<Hotel> GetHotelByname(string name);
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);
        void Update(Hotel hotel);
    }
}
