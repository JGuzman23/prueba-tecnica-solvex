using ATours.Entities.POCOEntities;
using System.Collections.Generic;

namespace ATours.UseCasesDtos.Hotel
{
    public class HotelParams
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public int IdCliente { get; set; }

        public List<Photo> Photos { get; set; }

        public List<Video> Videos { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Place { get; set; }

        public string TitleDescription { get; set; }

        public string Description { get; set; }

        public int Point { get; set; }

        public int MinNight { get; set; }

        public int Capacity { get; set; }
    }
}
