using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Parcela.Entities.KatastarskaOpstina;
using Parcela.Models.KatastarskaOpstina;


namespace Parcela.Profiles
{
    public class KatastarskaOpstinaConfirmationProfile : Profile
    {
        public KatastarskaOpstinaConfirmationProfile()
        {
            CreateMap<KatastarskaOpstinaConfirmation, KatastarskaOpstinaConfirmationDto>();
            CreateMap<KatastarskaOpstinaEntity, KatastarskaOpstinaConfirmation>();
        }
    }
}
