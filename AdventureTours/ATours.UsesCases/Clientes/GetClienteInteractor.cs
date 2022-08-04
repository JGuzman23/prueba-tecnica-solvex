using ATours.Entities.Exceptions;
using ATours.Entities.Interfaces.User;
using ATours.UseCasesDtos.Users.Params;
using ATours.UseCasesPorts.Cliente.GetCliente;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.UseCases.Clientes
{
    public class GetClienteInteractor : IGetClienteInputPort
    {

        readonly IClienteRepository _repository;
        readonly IGetClienteOutputPort _outputPort;
        readonly IMapper _mapper;

        public GetClienteInteractor(IClienteRepository repository, 
            IGetClienteOutputPort outputPort, 
            IMapper mapper)
        {
            _repository = repository;
            _outputPort = outputPort;
            _mapper = mapper;
        }

        public async Task GetAllClientes()
        {
            var result = await _repository.GetAllClientes();
            await _outputPort.GetAllCLientesIdOP(_mapper.Map<List<ClienteParams>>(result));

        }

        public async Task GetClienteById(ClienteParams model)
        {
            try
            {
                var result = await _repository.GetClienteById(model.Id);
                await _outputPort.GetClienteByIdOP(_mapper.Map<ClienteParams>( result));
            }
            catch (Exception Ex)
            {
                throw new GeneralException("Error al obtener el Usuario",
                   Ex.Message);
            }
           
        }
    }
}
