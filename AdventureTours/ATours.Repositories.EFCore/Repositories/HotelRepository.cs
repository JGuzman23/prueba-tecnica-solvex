using ATours.Entities.Interfaces;
using ATours.Entities.POCOEntities;
using ATours.Repositories.EFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Repositories.EFCore.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        readonly AToursContext _context;

        public HotelRepository(AToursContext context) => _context = context;


        //solo debe buscar un foto y sera la principal
        public async Task<Hotel> GetHotelByname(string name)
        {
            var result = await _context.Hotel.Include(p => p.Photos)
                .FirstOrDefaultAsync(x => x.Name == name && x.IsActive == true);


            return result;
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            var result = await _context.Hotel.Include(p => p.Photos)
                .Include(v => v.Videos)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);

            return result;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
           var result= await _context.Hotel.Include(p=> p.Photos).Include(v=>v.Videos).ToListAsync();
            return result;
        }

        public void Create(Hotel hotel)
        {
            _context.Add(hotel);

        }

        public void Update(Hotel model)
        {
           
            _context.Update(model);
        }

       
        




    }
}
