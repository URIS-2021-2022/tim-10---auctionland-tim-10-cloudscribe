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
                    dest => dest.StvarnoStanje,
                    opt => opt.MapFrom(src => $"{src.KulturaStvarnoStanje} { src.KlasaStvarnoStanje} {src.OBradivostStvarnoStanje} {src.OdvodnjavanjeStvarnoStanje} {src.ZasticenZonaStvarnoStanje}"))
                .ForMember(dest => dest.parcelaOpstine,
                    opt => opt.MapFrom(src => $"{src.BrojParcele} {src.KatastarskaOpstina}"));
            CreateMap<ParcelaCreationDto, ParcelaEntity>();
            CreateMap<ParcelaUpdateDto, ParcelaEntity>();
            CreateMap<ParcelaEntity, ParcelaEntity>();

        }
        
    }
}
