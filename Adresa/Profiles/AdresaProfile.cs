using Adresa.Entities;
using Adresa.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Profiles
{
    public class AdresaProfile : Profile
    {
        public AdresaProfile()
        {
            CreateMap<AdresaEntity, AdresaDto>()
                .ForMember(
                    dest => dest.UlicaBroj,
                    opt => opt.MapFrom(src => src.Ulica + " " + src.Broj));
            CreateMap<AdresaCreationDto, AdresaEntity>();
            CreateMap<AdresaUpdateDto, AdresaEntity>();
            CreateMap<AdresaEntity, AdresaEntity>();
        }
    }
}
