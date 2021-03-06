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
                    opt => opt.MapFrom(src => src.Ulica + " " + src.Broj))
                .ForMember(
                    dest => dest.NazivDrzave,
                    opt => opt.MapFrom(src => src.NazivDrzave));

            CreateMap<AdresaEntity, AdresaConfirmationDto>()
                .ForMember(
                    dest => dest.UlicaBroj,
                    opt => opt.MapFrom(src => src.Ulica + " " + src.Broj));
           CreateMap<AdresaEntity, AdresaConfirmationEntity>()
                .ForMember(
                    dest => dest.NazivDrzave, 
                    opt => opt.MapFrom(src => src.Drzava.NazivDrzave));
        }
    }
}
