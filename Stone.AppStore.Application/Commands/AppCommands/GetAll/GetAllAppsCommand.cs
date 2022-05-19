using MediatR;
using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Commands.AppCommands
{
    public class GetAllAppsCommand : IRequest<IEnumerable<App>>
    { }
}
