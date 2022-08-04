using System.Collections.Generic;

namespace ATours.Entities.POCOEntities
{
    public class Hotel
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

        public double Point { get; set; }

        public int MinNight { get; set; }

        public int Capacity { get; set; }
    }   
}
