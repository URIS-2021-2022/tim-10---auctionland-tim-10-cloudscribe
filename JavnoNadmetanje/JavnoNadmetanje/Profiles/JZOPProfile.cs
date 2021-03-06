using AutoMapper;
using JavnoNadmetanje.Entities;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class JzopProfile : Profile
    {
        public JzopProfile()
        {
            CreateMap<JzopEntity, JzopDto>();
            CreateMap<JzopCreateDto, JzopEntity>();
            CreateMap<JzopUpdateDto, JzopEntity>();
            CreateMap<JzopEntity, JzopEntity>();
        }
            
    }
}
