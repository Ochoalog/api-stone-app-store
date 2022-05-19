using MediatR;
using Serilog;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.AppStore.Application.Commands.AppCommands.GetById
{
    public class GetByIdCommandHandler : IRequestHandler<GetByIdAppCommand, App>
    {
        private readonly IAppRepository _appRepository;
        public async Task<App> Handle(GetByIdAppCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _appRepository.GetByIdAsync(request.Id);
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex.ToString());
                throw;
            }
        }
    }
}
