using ATours.Presenters.Hotel;
using ATours.UseCasesDtos.Hotel;
using ATours.UseCasesPorts.Hotel.CreateHotel;
using ATours.UseCasesPorts.Hotel.GetAllHotel;
using ATours.UseCasesPorts.Hotel.UpdateHotel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController
    {
        readonly ICreateHotelInputPort _inputPort;
        readonly ICreateHotelOutputPort _outputPort;

        readonly IGetHotelInputPort _getHotelInputPort;
        readonly IGetHotelOutputPort _getHotelOutputPort;

        readonly IUpdateHotelInputPort _updateHotelInputPort;
        readonly IUpdateHotelOutputPort _updateHotelOutputPort;

        public HotelController(ICreateHotelInputPort inputPort
            , ICreateHotelOutputPort outputPort
            , IUpdateHotelInputPort updateHotelInputPort
            , IUpdateHotelOutputPort updateHotelOutputPort,
            IGetHotelInputPort getHotelInputPort, 
            IGetHotelOutputPort getHotelOutputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
            _updateHotelInputPort = updateHotelInputPort;
            _updateHotelOutputPort = updateHotelOutputPort;
            _getHotelInputPort = getHotelInputPort;
            _getHotelOutputPort = getHotelOutputPort;
        }

        //patron repository
        //regla de dependencia
        // inyeccion de dependencia
        // dto
        // Dapper

        [HttpGet]
        public async Task<List<HotelParams>> GetAllHotel()
        {

            await _getHotelInputPort.GetAllHotell();
            var Presenter = _getHotelOutputPort as GetHotelPresenter;
            return Presenter.ListContent;

        }

      
        [HttpGet("{name}")]
        public async Task<HotelParams> GetHotelByName(
            string name)
        {

            await _getHotelInputPort.GetHotelByName(new HotelParams { Name= name});
            var Presenter = _getHotelOutputPort as GetHotelPresenter;
            return Presenter.Content;

        }
        [HttpGet("por/id")]
        public async Task<HotelParams> GetHotelId(int id)
        {

            await _getHotelInputPort.GetHotelById( id );
            var Presenter = _getHotelOutputPort as GetHotelPresenter;
            return Presenter.Content;

        }

        [HttpPost("CreateHotel")]
        public async Task<string> CreateHotel(
          HotelParams model)
        {

            await _inputPort.Handle(model);
            var Presenter = _outputPort as CreateHotelPresenter;
            return Presenter.Content;

        }

        [HttpPut("Id")]
        public async Task<string> UpdateHotel(int id,
        HotelParams model)
        {

            await _updateHotelInputPort.Handle(model, id);
            var Presenter = _updateHotelOutputPort as UpdateHotelPresenter;
            return Presenter.Content;

        }
    }
}
