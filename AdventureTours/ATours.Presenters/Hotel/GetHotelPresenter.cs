using ATours.UseCasesDtos.Hotel;
using ATours.UseCasesPorts.Hotel.GetAllHotel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Presenters.Hotel
{
    public class GetHotelPresenter : IGetHotelOutputPort
    {
        public List<HotelParams> ListContent { get; private set; }

        public HotelParams Content { get; set; }

        public Task GetAllHotellOP(List<HotelParams> model)
        {
            ListContent = model;

            return Task.CompletedTask;
        }

        public Task GetHotelByIdOP(HotelParams model)
        {
            Content = model;

            return Task.CompletedTask;
        }

        public Task GetHotelByNameOP(HotelParams model)
        {
            Content = model;

            return Task.CompletedTask;
        }
    }
}
