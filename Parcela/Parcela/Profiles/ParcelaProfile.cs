using AutoMapper;
using Parcela.Entities.Parcela;
using Parcela.Models;
using Parcela.Models.Parcela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Profiles
{
    public class ParcelaProfile : Profile
    {
        public ParcelaProfile()
        {
            CreateMap<ParcelaEntity, ParcelaDto>()
                .ForMember(
                    dest => dest.KatastarskaOpstina,
                    opt => opt.MapFrom(src => $"{ src.KatastarskaOpstinaEntity.ImeKatastarskeOpstine }"))
                .ForMember(
                    dest => dest.ZasticenaZona,
                    opt => opt.MapFrom(src => $"{ src.ZasticenaZonaEntity.BrojZone}"));
                    


            CreateMap<ParcelaCreationDto, ParcelaEntity>();
            CreateMap<ParcelaUpdateDto, ParcelaEntity>();
            CreateMap<ParcelaEntity, ParcelaEntity>();

        }
        
    }
}
