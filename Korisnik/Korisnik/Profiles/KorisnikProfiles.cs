using AutoMapper;
using Korisnik.Entities;
using Korisnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Profiles
{
    public class KorisnikProfiles : Profile
    {
        public KorisnikProfiles()
        {
            CreateMap<Korisnikk, KorisnikDto>()
              .ForMember(
              dest => dest.Tip,
              opt => opt.MapFrom(src => $"{src.Tip.TipKorisnika}"));
            CreateMap<KorisnikDto, Korisnikk>();
            CreateMap<KorisnikDto, KorisnikDto>();
               

            CreateMap<KorisnikCreationDto, Korisnikk>();
            CreateMap<Korisnikk, KorisnikCreationDto>();
            CreateMap<Korisnikk, KorisnikUpdateDto>();
            CreateMap<KorisnikUpdateDto, Korisnikk>();
            CreateMap<KorisnikUpdateDto, KorisnikUpdateDto>();

        }
    }
}
