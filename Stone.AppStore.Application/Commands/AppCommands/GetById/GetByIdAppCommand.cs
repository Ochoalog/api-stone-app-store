using MediatR;
using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Commands.AppCommands.GetById
{
    public class GetByIdAppCommand : IRequest<App>
    {
        public Guid Id { get; set; }
    }
}
