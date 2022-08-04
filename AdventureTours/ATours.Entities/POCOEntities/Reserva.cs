using System;

namespace ATours.Entities.POCOEntities
{
    public class Reserva
    {
        public int Id { get; set; }

        public string ConfirmationNumber { get; set; }

        public int ClienteId { get; set; }

        public int HotelId { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }

        public int CountNight { get; set; }

        public int CountRoon { get; set; }

    }
}
