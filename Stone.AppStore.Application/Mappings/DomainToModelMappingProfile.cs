using AutoMapper;
using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;

namespace Stone.AppStore.Application.Mappings
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<App, AppModel>().ReverseMap();
        }
    }
}
