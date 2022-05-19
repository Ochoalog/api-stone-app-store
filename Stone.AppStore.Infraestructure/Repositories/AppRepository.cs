using Microsoft.EntityFrameworkCore;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Domain.Interfaces;
using Stone.AppStore.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.AppStore.Infraestructure.Repositories
{
    public class AppRepository : IAppRepository
    {
        private readonly AppStoreDbContext _dbContext;

        public AppRepository(AppStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<App> CreateAsync(App app)
        {
            _dbContext.Add(app);
            await _dbContext.SaveChangesAsync();
            return app;
        }

        public async Task<IEnumerable<App>> GetAppsAsync()
        {
            return await _dbContext.Apps.Where(app => 
                app.Active).OrderBy(a => a.Name).ToListAsync();
        }

        public async Task<App> GetByIdAsync(Guid appId)
        {
            return await _dbContext.Apps.FirstOrDefaultAsync(app => 
                app.Id == appId && app.Active);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
        }
    }
}
