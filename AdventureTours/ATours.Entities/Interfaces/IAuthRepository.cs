using ATours.Entities.POCOEntities;
using System.Threading.Tasks;

namespace ATours.Entities.Interfaces
{
    public interface IAuthRepository
    {
        Task<Cliente> Login(string email);
        Task<string> ValidateUser(string key);
    }
}
