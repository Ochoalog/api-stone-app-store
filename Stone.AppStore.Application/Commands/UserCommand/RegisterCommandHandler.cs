using MediatR;
using Serilog;
using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.AppStore.Application.Commands.UserCommand
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, User>
    {
        private readonly IUserRepository _repository;

        public RegisterCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _repository.VerifyExistsByEmailAsync(request.Payload.Email);
                if (user != null)
                {
                    return null;
                }

                MapUser(user, request.Payload);

                await _repository.CreateAsync(user);

                return user;
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal($"{nameof(ex)}: {ex}");
                throw ex;
            }        
        }

        public void MapUser(User user, UserModel userModel)
        {
            user = new User
            {
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password,
                Active = true,
                BirthDate = userModel.BirthDate,
                Cpf = userModel.Cpf,
                Gender = userModel.Gender,
                Address = new Address
                {
                    City = userModel.Address.City,
                    Avenue = userModel.Address.Avenue,
                    Cep = userModel.Address.Cep,
                    Number = userModel.Address.Number,
                    Complement = userModel.Address.Complement,
                    Uf = userModel.Address.Uf,
                }
            };

        }
    }
}
