using AutoMapper;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class AdresaProfile : Profile
    {
        public AdresaProfile()
        {
            CreateMap<JavnaLicitacijaCreateDto, AdresaDto>();
            CreateMap<JzopCreateDto, AdresaDto>();

        }
    }
}
