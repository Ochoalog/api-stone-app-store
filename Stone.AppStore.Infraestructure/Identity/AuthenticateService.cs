using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Stone.AppStore.Infraestructure.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticateService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email,
                 password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(User user)
        {
            var result = await _userManager.CreateAsync(user, user.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result.Succeeded;
        }
    }
}
