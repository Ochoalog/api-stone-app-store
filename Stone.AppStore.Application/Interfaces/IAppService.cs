using Stone.AppStore.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.AppStore.Application.Interfaces
{
    public interface IAppService
    {
        Task<IEnumerable<AppModel>> GetApps();

        Task<AppModel> GetById(Guid Id);

        Task Add(AppModel appModel);
    }
}
