using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.AppStore.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid userId);

        Task<User> GetByEmailAndPasswordAsync(string email, string password);

        Task<User> CreateAsync(User user);

        Task<User> VerifyExistsByEmailAsync(string email);
    }
}
