using ATours.Entities.Exceptions;
using ATours.Entities.Interfaces;
using ATours.UseCasesDtos.Hotel;
using ATours.UseCasesPorts.Hotel.GetAllHotel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.UseCases
{
    public class GetHotel : IGetHotelInputPort


    {
        readonly IHotelRepository _repository;
        readonly IGetHotelOutputPort _outputPort;
        readonly IMapper _mapp;

        public GetHotel(IHotelRepository hotelRepository
            ,IGetHotelOutputPort outputPort
            ,IMapper mapp)
        {
            _repository = hotelRepository;
            _outputPort = outputPort;
            _mapp = mapp;
        }

        public async Task GetAllHotell()
        {
            try
            {
                var result = await _repository.GetAllHotels();
                await _outputPort.GetAllHotellOP(_mapp.Map<List<HotelParams>>(result));

            }
            catch (Exception e)
            {
                throw new GeneralException("Error al obtener el Hotel", e.Message);
            }
        }

        public async Task GetHotelById(int id)
        {
            try
            {
                var result = await _repository.GetHotelById(id);
                await _outputPort.GetHotelByIdOP(_mapp.Map<HotelParams>(result));

            }
            catch (Exception e)
            {
                throw new GeneralException("Error al obtener el Hotel", e.Message);
            }

        }

        public async Task GetHotelByName(HotelParams model)
        {
            try
            {
                var result = await _repository.GetHotelByname(model.Name);
                await _outputPort.GetHotelByNameOP(_mapp.Map<HotelParams>(result));

            }
            catch (Exception e)
            {
                throw new GeneralException("Error al obtener el Hotel", e.Message);
            }

        }
    }
}
