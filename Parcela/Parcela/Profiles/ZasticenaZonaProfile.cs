using AutoMapper;
using Parcela.Entities.ZasticenaZona;
using Parcela.Models;
using Parcela.Models.ZasticenaZona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Profiles
{
    public class ZasticenaZonaProfile : Profile
    {
        public ZasticenaZonaProfile()
        {
            CreateMap<ZasticenaZonaEntity, ZasticenZonaDto>();
            CreateMap<ZasticenaZonaCreationDto, ZasticenaZonaEntity>();
            CreateMap<ZasticenZonaDto, ZasticenaZonaEntity>();
            CreateMap<ZasticenaZonaEntity, ZasticenaZonaEntity>();
        }
    }
}
