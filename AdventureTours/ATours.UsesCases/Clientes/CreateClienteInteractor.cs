using ATours.Entities.Exceptions;
using ATours.Entities.Interfaces.User;
using ATours.Entities.POCOEntities;
using ATours.UseCases.Common.Validators;
using ATours.UseCasesDtos.Users.Params;
using ATours.UseCasesPorts.Auth;
using ATours.UseCasesPorts.Users.CreateUsers;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.UseCases.Clientes
{
    public class CreateClienteInteractor : ICreateClienteInputPort

    {
        readonly IMapper _mapper;
        readonly IClienteRepository _repository;
        readonly ICreateClienteOutputPort _outputPort;
        readonly IEnumerable<IValidator<ClienteParams>> _validators;
        readonly IPasswordService _passwordService;
        readonly IToken _token;

        public CreateClienteInteractor(IClienteRepository repository,
            ICreateClienteOutputPort outputPort,
            IEnumerable<IValidator<ClienteParams>> validators, IMapper mapper, IPasswordService passwordService, IToken token)
        {
            _repository = repository;
            _outputPort = outputPort;
            _validators = validators;
            _mapper = mapper;
            _passwordService = passwordService;
            _token = token;
        }

        public async Task Create(ClienteParams model)
        {
           await Validator<ClienteParams>.Validate(model, _validators);

            try
            {
                model.Password = _passwordService.Hash(model.Password);

                await _repository.CreateClienteAsyc(_mapper.Map<Cliente>(model));
               
                await _outputPort.Handle();
            }
            catch (Exception Ex)
            {
                throw new GeneralException("Error al crear el Usuario", Ex.Message);

            }
        }

        public async Task Update(ClienteParams model)
        {
            await _repository.UpdateCliente(_mapper.Map<Cliente>(model));

            await _outputPort.Handle();

        }
    }
}
