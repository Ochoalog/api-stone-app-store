using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Infraestructure.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.AppStore.Infraestructure.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppStoreDbContext _dbContext;

        public AuthenticateService(UserManager<User> userManager, SignInManager<User> signInManager, AppStoreDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email,
                 password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<string> GetUserIdByEmail(string email)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return result.Id;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterUser(User user)
        {
            var result = await _userManager.CreateAsync(user, user.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }
    }
}
