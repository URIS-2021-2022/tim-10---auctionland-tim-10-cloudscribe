using AutoMapper;
using JavnoNadmetanje.Entities;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class JZOPProfile : Profile
    {
        public JZOPProfile()
        {
            CreateMap<JZOPEntity, JZOPDto>();
            CreateMap<JZOPCreateDto, JZOPEntity>();
            CreateMap<JZOPUpdateDto, JZOPEntity>();
            CreateMap<JZOPEntity, JZOPEntity>();
        }
            
    }
}
