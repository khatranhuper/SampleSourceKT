using AutoMapper;
using SampleSourceKT.Application.DTO.Requests.Users;
using SampleSourceKT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterRequestDto, AppUser>();
        }
    }
}
