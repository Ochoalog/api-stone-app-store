using MediatR;
using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;

namespace Stone.AppStore.Application.Commands.AppCommands.Create
{
    public class CreateAppCommand : IRequest<App>
    {
        public AppModel Payload { get; set; }
    }
}
