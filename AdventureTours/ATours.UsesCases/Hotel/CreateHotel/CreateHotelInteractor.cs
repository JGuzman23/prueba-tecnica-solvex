using ATours.Entities.Exceptions;
using ATours.Entities.Interfaces;
using ATours.Entities.POCOEntities;
using ATours.UseCases.Common.Validators;
using ATours.UseCasesDtos.Hotel;
using ATours.UseCasesPorts.Hotel.CreateHotel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.UseCases
{
    public class CreateHotelInteractor : ICreateHotelInputPort
    {

        readonly IHotelRepository _hotelRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly ICreateHotelOutputPort _outputPort;
        readonly IEnumerable<IValidator<HotelParams>> _validators;

        public CreateHotelInteractor(IHotelRepository HotelRepository
            , IUnitOfWork unitOfWork
            , ICreateHotelOutputPort outputPort
            , IEnumerable<IValidator<HotelParams>> validators)
        {
            _hotelRepository = HotelRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
            _validators = validators;
        }

        public async Task Handle(HotelParams model)
        {
            await Validator<HotelParams>.Validate(model, _validators);

            Hotel hotel = new Hotel
            {
                IsActive = model.IsActive,
                IdCliente = model.IdCliente,
                Photos = model.Photos,
                Videos = model.Videos,
                Name = model.Name,
                Price = model.Price,
                Category = model.Category,
                Place = model.Place,
                TitleDescription = model.TitleDescription,
                Description = model.Description,
                Point = model.Point,
                MinNight = model.MinNight,
                Capacity = model.Capacity
            };
           
            try
            {
                _hotelRepository.Create(hotel);
                await _unitOfWork.SaveChangesAsync();
                await _outputPort.Handle(hotel.Id);
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al Crear el Hotel", ex.Message);
            }
           
        }
    }
}

