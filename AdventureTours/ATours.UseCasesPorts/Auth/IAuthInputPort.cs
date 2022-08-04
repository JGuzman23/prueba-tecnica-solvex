using ATours.UseCasesDtos.Auth;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Auth
{
    public interface IAuthInputPort
    {
        Task Handler(AuthParams login);
    }
}
