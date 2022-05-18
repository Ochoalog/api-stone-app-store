using MediatR;
using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Commands.UserCommand
{
    public class RegisterCommand : IRequest<User>
    {
        public UserModel Payload { get; set; }

        public RegisterCommand(UserModel payload)
        {
            Payload = payload;
        }
    }
}
