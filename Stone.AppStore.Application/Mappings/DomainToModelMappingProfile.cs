using AutoMapper;
using Stone.AppStore.Application.Models;
using Stone.AppStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.AppStore.Application.Mappings
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<AppModel, App>().ReverseMap();
        }
    }
}
