using ATours.UseCasesDtos.Auth;
using ATours.UseCasesPorts.Auth;
using System.Threading.Tasks;

namespace ATours.Presenters.Auth
{
    public  class AuthPresenter: IAuthOutputPort
    {
        public AuthDto Content { get; private set; }
        public Task Handle(AuthDto token)
        {
            Content = token;
            return Task.CompletedTask;
        }
    }
}
