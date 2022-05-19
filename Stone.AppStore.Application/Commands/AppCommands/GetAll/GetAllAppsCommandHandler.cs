using MediatR;
using Serilog;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.AppStore.Application.Commands.AppCommands
{
    public class GetAllAppsCommandHandler : IRequestHandler<GetAllAppsCommand, IEnumerable<App>>
    {
        private readonly IAppRepository _appRepository;

        public async Task<IEnumerable<App>> Handle(GetAllAppsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _appRepository.GetAppsAsync();

            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex.ToString());
                throw ex;
            }
        }
    }
}
