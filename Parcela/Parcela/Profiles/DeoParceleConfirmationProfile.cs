using AutoMapper;
using Parcela.Entities.DeoParcele;
using Parcela.Models.DeoParcele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Profiles
{
    public class DeoParceleConfirmationProfile : Profile
    {

        public DeoParceleConfirmationProfile()
        {
            CreateMap<DeoParceleConfirmation, DeoParceleConfirmationDto>();
            CreateMap<DeoParceleEntity, DeoParceleConfirmation>();
        }

    }
}
