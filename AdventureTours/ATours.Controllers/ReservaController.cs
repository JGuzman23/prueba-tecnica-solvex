using ATours.Entities.POCOEntities;
using ATours.Presenters;
using ATours.UseCasesDtos.CreateReserva;
using ATours.UseCasesPorts.CreateReserva;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController
    {
        readonly IReservaInputPort _inputPort;
        readonly IReservaOutputPort _outputPort;

        public ReservaController(IReservaInputPort inputPort, IReservaOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }


        [HttpGet("{id}")]
        public async Task<List<Reserva>> GetReserva(
            int id)
        {

            await _inputPort.GetByCliente(id);
            var Presenter = _outputPort as ReservaPresenter;
            return Presenter.ListContent;

        }

        [HttpPost("CreateReserva")]
        public async Task<string> CreateReserva(
            CreateReservaParams reservaParams)
        {

            await _inputPort.Create(reservaParams);
            var Presenter = _outputPort as ReservaPresenter;
            return Presenter.Content;
            
        }
    }
}
