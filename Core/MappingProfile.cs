using AutoMapper;
using Data.DataModels;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Container, ContainerResponseEntity>();
            CreateMap<ContainerCreateEntity, Container>();
            CreateMap<ContainerUpdateEntity, Container>();
            CreateMap<VehicleUpdateEntity, Vehicle>();
            CreateMap<ContainerResponseEntity, Vehicle>();
            CreateMap<VehicleCreateEntity, Vehicle>();
        }

    }
}
