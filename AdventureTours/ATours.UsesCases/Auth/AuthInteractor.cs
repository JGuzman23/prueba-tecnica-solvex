using ATours.Entities.Interfaces;
using ATours.UseCasesDtos.Auth;
using ATours.UseCasesPorts.Auth;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace ATours.UseCases.Auth
{
    public class AuthInteractor: IAuthInputPort
    {
        readonly IAuthOutputPort _outputPort;
        readonly IAuthRepository _repository;
        readonly IMapper _mapper;
        readonly IToken _token;
        
        private readonly IPasswordService _passwordService;

        public AuthInteractor(IAuthOutputPort outputPort, IMapper mapper, IToken token, IAuthRepository repository, IPasswordService passwordService)
        {
            _outputPort = outputPort;
            _mapper = mapper;
            _token = token;
            _repository = repository;
            _passwordService = passwordService;
        }

        public async Task Handler(AuthParams login)
        {
            try
            {
                var validateUser = await _repository.ValidateUser(login.Email);
                if (validateUser != null)
                {
                    var isValid = _passwordService.Check(validateUser, login.Password);
                    if (isValid)
                    {
                        var result = await _repository.Login(login.Email);
                        var dto = _mapper.Map<AuthDto>(result);
                        if (result == null)
                        {
                            throw new Exception("Usuario o contrasena incorrecta");
                        }
                        else
                        {
                            await _token.GenerateToken(dto);
                        }
                        await _outputPort.Handle(dto);
                    }
                    else
                    {
                        throw new Exception("Password was wrong.");
                    }
                }
                else
                {
                    throw new Exception("Username, email or telephone were wrong.");
                }



            }
            catch (Exception ex)
            {
                throw new Exception("Error al ingresar" + ex.Message);
            }
        }
    }
}
