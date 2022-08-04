using ATours.Presenters.Cliente;
using ATours.UseCasesDtos.Users.Params;
using ATours.UseCasesPorts.Cliente.GetCliente;
using ATours.UseCasesPorts.Users.CreateUsers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClienteController
    {
        readonly ICreateClienteInputPort _inputPort;
        readonly ICreateClienteOutputPort _outputPort;

        readonly IGetClienteInputPort _GetInputPort;
        readonly IGetClienteOutputPort _GetOutputPort;

        public ClienteController(ICreateClienteInputPort inputPort,
            ICreateClienteOutputPort outputPort,
            IGetClienteInputPort getinputPort, 
            IGetClienteOutputPort getoutputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
            _GetInputPort = getinputPort;
            _GetOutputPort = getoutputPort;
        }



        [HttpGet]
        public async Task<List<ClienteParams>> GetAllClientes()
        {
            await _GetInputPort.GetAllClientes();
            var presenter = _GetOutputPort as GetClientePresenter;
            return presenter.ListContent;
        }
        [HttpGet("by/{id}")]
        public async Task<ClienteParams> GetClienteById( int id)
        {
            await _GetInputPort.GetClienteById(new ClienteParams { Id = id });
            var presenter = _GetOutputPort as GetClientePresenter;
            return presenter.Content;
        }


        [HttpPost]
        public async Task<string> CreateCliente(ClienteParams model)
        {
            await _inputPort.Create(model);
            var presenter = _outputPort as CreateClientePresenter;

            return presenter.Content;
        }

        [HttpPut]
        public async Task<string> UpdateCliente(ClienteParams model)
        {
            await _inputPort.Update(model);
            var presenter = _outputPort as CreateClientePresenter;

            return presenter.Content;
        }
    }
}
