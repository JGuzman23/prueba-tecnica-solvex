using System;

namespace ATours.UseCasesDtos.CreateReserva
{
    public class CreateReservaParams
    {
        public int HotelId { get; set; }

        public int ClienteId { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }

        public int CountNight { get; set; }

        public int CountRoon { get; set; }


    }
}
