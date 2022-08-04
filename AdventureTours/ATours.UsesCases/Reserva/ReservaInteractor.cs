using ATours.Entities.Exceptions;
using ATours.Entities.Interfaces;
using ATours.Entities.POCOEntities;
using ATours.UseCases.Common.Validators;
using ATours.UseCasesDtos.CreateReserva;
using ATours.UseCasesPorts.CreateReserva;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.UsesCases.CreateReserva
{
    public class ReservaInteractor :IReservaInputPort
    {
        readonly IReservaRepository _reservaRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly IReservaOutputPort _outputPort;
        readonly IEnumerable<IValidator<CreateReservaParams>> _validators;

        public ReservaInteractor(IReservaRepository orderRepository
            ,IUnitOfWork unitOfWork
            ,IReservaOutputPort outputPort
            , IEnumerable<IValidator<CreateReservaParams>> validators)
        {
            _reservaRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
            _validators = validators;
        }

        public async Task Create(CreateReservaParams reserva)
        {
           await Validator<CreateReservaParams>.Validate(reserva, _validators);

            Reserva Reserva = new()
            {
                ClienteId = reserva.ClienteId,
                HotelId = reserva.HotelId,
                StartDay = reserva.StartDay,
                EndDay = reserva.EndDay

            };
            _reservaRepository.Create(Reserva);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al reservar", ex.Message);
            }
            await _outputPort.Handle(Reserva.Id);
        }

        public async Task GetByCliente(int id)
        {
            var result = await _reservaRepository.GetByClient(id);
            await _outputPort.GetByClient(result);

        }

    

        
    }
}
