using AutoMapper;
using Stone.AppStore.Application.Interfaces;
using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.AppStore.Application.Services
{
    public class AppService : IAppService
    {
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public AppService(IAppRepository appRepository)
        {
            _appRepository = appRepository ?? throw new ArgumentNullException(nameof(appRepository));
        }

        public async Task<IEnumerable<AppModel>> GetApps()
        {
            var appsEntity = await _appRepository.GetAppsAsync();
            return _mapper.Map<IEnumerable<AppModel>>(appsEntity);
        }

        public async Task Add(AppModel appModel)
        {
            var appEntity = _mapper.Map<App>(appModel);
            await _appRepository.CreateAsync(appEntity);
        }

        public async Task<AppModel> GetById(Guid id)
        {
            var appEntity = await _appRepository.GetByIdAsync(id);
            return _mapper.Map<AppModel>(appEntity);
        }
    }
}
