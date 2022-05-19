using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.AppStore.Domain.Interfaces
{
    public interface IAppRepository
    {
        Task<IEnumerable<App>> GetAppsAsync();

        Task<App> GetByIdAsync(Guid appId);

        Task<App> CreateAsync(App app);
    }
}
