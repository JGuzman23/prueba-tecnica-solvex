using ATours.Presenters.Auth;
using ATours.UseCasesDtos.Auth;
using ATours.UseCasesPorts.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ATours.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController
    {
        readonly IAuthInputPort _inputPort;
        readonly IAuthOutputPort _outputPort;
        public AuthController(IAuthInputPort inputPort, IAuthOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpPost]
        public async Task<AuthDto> Login(AuthParams login)
        {
            await _inputPort.Handler(login);
            var presenter = _outputPort as AuthPresenter;

            return presenter.Content;
        }
    }
}
