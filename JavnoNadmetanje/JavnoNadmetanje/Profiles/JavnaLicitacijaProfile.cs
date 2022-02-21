using AutoMapper;
using JavnoNadmetanje.Entities;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class JavnaLicitacijaProfile : Profile 
    {
        public JavnaLicitacijaProfile()
        {

            CreateMap<JavnaLicitacijaEntity, JavnaLicitacijaDto>();
            CreateMap<JavnaLicitacijaCreateDto, JavnaLicitacijaEntity>();
            CreateMap<JavnaLicitacijaUpdateDto, JavnaLicitacijaEntity>();
            CreateMap<JavnaLicitacijaEntity, JavnaLicitacijaEntity>();
        }
    }
}
