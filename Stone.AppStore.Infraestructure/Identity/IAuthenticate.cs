using Stone.AppStore.Domain.Entities;
using System.Threading.Tasks;

namespace Stone.AppStore.Infraestructure.Identity
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> RegisterUser(User user);

        Task Logout();
    }
}
