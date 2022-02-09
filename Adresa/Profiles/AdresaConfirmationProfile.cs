using Adresa.Entities;
using Adresa.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Profiles
{
    public class AdresaConfirmationProfile : Profile
    {
        public AdresaConfirmationProfile()
        {
            CreateMap<AdresaConfirmationEntity, AdresaConfirmationDto>()
                .ForMember(
                    dest => dest.UlicaBroj,
                    opt => opt.MapFrom(src => src.Ulica + " " + src.Broj));

            CreateMap<AdresaEntity, AdresaConfirmationDto>()
                .ForMember(
                    dest => dest.UlicaBroj,
                    opt => opt.MapFrom(src => src.Ulica + " " + src.Broj));
            //CreateMap<AdresaEntity, AdresaConfirmationEntity>();
        }
    }
}
