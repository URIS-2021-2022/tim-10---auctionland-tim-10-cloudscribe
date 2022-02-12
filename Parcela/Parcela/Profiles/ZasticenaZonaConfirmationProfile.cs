using AutoMapper;
using Parcela.Entities.ZasticenaZona;
using Parcela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Profiles
{
    public class ZasticenaZonaConfirmationProfile : Profile
    {
        public ZasticenaZonaConfirmationProfile()
        {
            CreateMap<ZasticenaZonaConfirmation, ZasticenZonaConfirmationDto>();
            CreateMap<ZasticenaZonaEntity, ZasticenaZonaConfirmation>();
        }
    }
}
