using AutoMapper;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class ParcelaProfile : Profile
    {
        public ParcelaProfile()
        {

            CreateMap<JavnaLicitacijaCreateDto, ParcelaDto>();
            CreateMap<JzopCreateDto, ParcelaDto>();

        }
    }
}
