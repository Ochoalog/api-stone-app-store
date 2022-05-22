using AutoMapper;
using Serilog;
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

        public AppService(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository ?? throw new ArgumentNullException(nameof(appRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AppModel>> GetApps()
        {
            try
            {
                var appsEntity = await _appRepository.GetAppsAsync();

                return _mapper.Map<IEnumerable<AppModel>>(appsEntity);
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex.ToString());
                throw ex;
            }
            
        }

        public async Task Add(AppModel appModel)
        {
            try
            {
                var appEntity = _mapper.Map<App>(appModel);
                await _appRepository.CreateAsync(appEntity);
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex.ToString());
                throw ex;
            }

        }

        public async Task<AppModel> GetById(Guid id)
        {
            try
            {
                var appEntity = await _appRepository.GetByIdAsync(id);
                return _mapper.Map<AppModel>(appEntity);
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex.ToString());
                throw ex;
            }

        }
    }
}
