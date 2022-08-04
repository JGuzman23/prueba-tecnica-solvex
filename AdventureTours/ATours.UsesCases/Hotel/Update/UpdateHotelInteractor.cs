using ATours.Entities.Exceptions;
using ATours.Entities.Interfaces;
using ATours.Entities.POCOEntities;
using ATours.UseCases.Common.Validators;
using ATours.UseCasesDtos.Hotel;
using ATours.UseCasesPorts.Hotel.UpdateHotel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.UseCases
{
    public class UpdateHotelInteractor: IUpdateHotelInputPort
    {
        readonly IHotelRepository _hotelRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly IUpdateHotelOutputPort _outputPort;
        readonly IEnumerable<IValidator<HotelParams>> _validators;

        public UpdateHotelInteractor(IHotelRepository HotelRepository
            , IUnitOfWork unitOfWork
            , IUpdateHotelOutputPort outputPort
            , IEnumerable<IValidator<HotelParams>> validators)
        {
            _hotelRepository = HotelRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
            _validators = validators;
        }

        public async Task Handle(HotelParams model, int id)
        {
            await Validator<HotelParams>.Validate(model, _validators);

            Hotel hotel = new Hotel
            {
                Id= model.Id,
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
                _hotelRepository.Update(hotel);
                await _unitOfWork.SaveChangesAsync();
                await _outputPort.Handle(hotel.Id);

            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al Actualizar el Hotel", ex.Message);
            }
        }
    }
}
