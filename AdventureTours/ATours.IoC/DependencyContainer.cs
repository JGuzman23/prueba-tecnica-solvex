using ATours.Entities.Interfaces;
using ATours.Entities.Interfaces.User;
using ATours.Presenters;
using ATours.Presenters.Auth;
using ATours.Presenters.Cliente;
using ATours.Presenters.Hotel;
using ATours.Repositories.EFCore.DataContext;
using ATours.Repositories.EFCore.Repositories;
using ATours.Respositories.Dapper;
using ATours.Respositories.Dapper.Auth;
using ATours.Respositories.Dapper.Users;
using ATours.UseCases;
using ATours.UseCases.Auth;
using ATours.UseCases.Auth.PasswordService;
using ATours.UseCases.Clientes;
using ATours.UseCases.Common.Validators;
using ATours.UseCasesPorts.Auth;
using ATours.UseCasesPorts.Cliente.GetCliente;
using ATours.UseCasesPorts.CreateReserva;
using ATours.UseCasesPorts.Hotel.CreateHotel;
using ATours.UseCasesPorts.Hotel.GetAllHotel;
using ATours.UseCasesPorts.Hotel.UpdateHotel;
using ATours.UseCasesPorts.Users.CreateUsers;
using ATours.UsesCases.CreateReserva;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ATours.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAToursServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AToursContext>(option => option.UseSqlServer(configuration.GetConnectionString("AToursDb")));

            services.AddTransient<IConnection>(provider =>
            {
                return new BaseDapperConnection(configuration.GetConnectionString("AToursDb"));
            });


            services.AddAutoMapper(typeof(ClienteProfile).Assembly);
            services.AddValidatorsFromAssembly(typeof(CreateReservaValidator).Assembly);


            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            
           

            services.AddScoped<IReservaInputPort, ReservaInteractor>();
            services.AddScoped<IReservaOutputPort, ReservaPresenter>();

            services.AddScoped<ICreateClienteInputPort, CreateClienteInteractor>();
            services.AddScoped<ICreateClienteOutputPort, CreateClientePresenter>();

            services.AddScoped<IGetClienteInputPort, GetClienteInteractor>();
            services.AddScoped<IGetClienteOutputPort, GetClientePresenter>();

            services.AddScoped<ICreateHotelInputPort, CreateHotelInteractor>();
            services.AddScoped<ICreateHotelOutputPort, CreateHotelPresenter>();

            services.AddScoped<IUpdateHotelInputPort, UpdateHotelInteractor>();
            services.AddScoped<IUpdateHotelOutputPort, UpdateHotelPresenter>();




            services.AddScoped<IAuthInputPort, AuthInteractor>();
            services.AddScoped<IAuthOutputPort, AuthPresenter>();





            services.AddScoped<IGetHotelInputPort, GetHotel>();
            services.AddScoped<IGetHotelOutputPort, GetHotelPresenter>();


            services.AddScoped<IToken, Token>();

            services.AddScoped<IPasswordService, PasswordService>();





            return services;

        }

        
    }
}
