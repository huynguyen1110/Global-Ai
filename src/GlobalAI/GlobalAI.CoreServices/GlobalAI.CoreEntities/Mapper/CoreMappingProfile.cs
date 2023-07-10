using AutoMapper;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.CoreEntities.Dto.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.Mapper
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<CoreRole, ViewRoleDto>().ReverseMap();
            CreateMap<CoreRole, AddRoleDto>().ReverseMap();
            CreateMap<CoreRole, UpdateRoleDto>().ReverseMap();
        }
    }
}
