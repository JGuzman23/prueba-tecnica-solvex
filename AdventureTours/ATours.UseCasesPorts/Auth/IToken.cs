using ATours.UseCasesDtos.Auth;
using System.Threading.Tasks;

namespace ATours.UseCasesPorts.Auth
{
    public interface IToken
    {
        Task GenerateToken(AuthDto dto);
    }
}
