using Microsoft.EntityFrameworkCore;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Domain.Interfaces;
using Stone.AppStore.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.AppStore.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppStoreDbContext _dbContext;

        public UserRepository(AppStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u =>
            u.Active && u.Email.Equals(email) && u.Password.Equals(password));
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u =>
            u.Active && u.Id.Equals(userId));
        }

        public async Task<User> VerifyExistsByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u =>
            u.Active && u.Email.Equals(email));
        }
    }
}
