using AutoMapper;
using Parcela.Entities.Parcela;
using Parcela.Models.Parcela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Profiles
{
    public class ParcelaConfirmationProfile : Profile
    {
        public ParcelaConfirmationProfile()
        {
            CreateMap<ParcelaConfirmation, ParcelaConfirmationDto>();

            CreateMap<ParcelaEntity, ParcelaConfirmation>();
        }
    }
}
