using AutoMapper;
using MediatR;
using Serilog;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.AppStore.Application.Commands.AppCommands.Create
{
    public class CreateAppCommandHandler : IRequestHandler<CreateAppCommand, App>
    {
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public CreateAppCommandHandler(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository ?? throw new ArgumentNullException(nameof(appRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<App> Handle(CreateAppCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _appRepository.CreateAsync(_mapper.Map<App>(request.Payload));
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex.ToString());
                throw ex;
            }
        }
    }
}
