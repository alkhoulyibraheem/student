using AutoMapper;
using student.core.Dto;
using student.core.ViweModel;
using student.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<User, userViewModel>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.ImageURL, x => x.Ignore());
            CreateMap <UpDateUserDto, User>().ForMember(x => x.ImageURL, x => x.Ignore());
            CreateMap<User, UpDateUserDto>().ForMember(x => x.Imege, x => x.Ignore());
        }

    }
}
