using AutoMapper;
using Parcela.Entities.KatastarskaOpstina;
using Parcela.Models.KatastarskaOpstina;
using Parcela.Modelsc.KatastarskaOpstina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Profiles
{
    public class KatastarskaOpstinaProfile : Profile
    {
        public KatastarskaOpstinaProfile() 
        {
            CreateMap<KatastarskaOpstinaEntity, KatastarskaOpstinaDto>();
            CreateMap<KatastarskaOpstinaDto, KatastarskaOpstinaEntity>();
            CreateMap<KatastarskaOpstinaEntity, KatastarskaOpstinaEntity>();
            CreateMap<KatastarskaOpstinaCreationDto, KatastarskaOpstinaEntity>();
        }

    }
}
