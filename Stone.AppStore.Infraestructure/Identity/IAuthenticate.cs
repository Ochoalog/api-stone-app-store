using Microsoft.AspNetCore.Identity;
using Stone.AppStore.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Stone.AppStore.Infraestructure.Identity
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);

        Task<string> GetUserIdByEmail(string email);

        Task<IdentityResult> RegisterUser(User user);

        Task Logout();
    }
}
