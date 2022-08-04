using ATours.Entities.POCOEntities;
using ATours.UseCasesDtos.Auth;
using ATours.UseCasesDtos.Hotel;
using ATours.UseCasesDtos.Users.Params;
using AutoMapper;

namespace ATours.UseCases
{
    public class ClienteProfile :Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteParams, Cliente>().ReverseMap();
            CreateMap<AuthDto, Cliente>().ReverseMap();


            CreateMap<HotelParams, Hotel>().ReverseMap();



        }
    }
}
