using ATours.UseCasesDtos.Auth;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Auth
{
    public interface IAuthOutputPort
    {
        Task Handle(AuthDto token);
    }
}
