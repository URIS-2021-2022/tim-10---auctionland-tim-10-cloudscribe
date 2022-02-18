using AutoMapper;
using Korisnik.Entities;
using Korisnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Profiles
{
    public class KorisnikConfirmationProfile: Profile
    {
        public KorisnikConfirmationProfile ()
        {
            CreateMap<KorisnikConfirmation, KorisnikConfirmationDto>();
            

                                                                       
            CreateMap<KorisnikConfirmationDto, KorisnikConfirmation>();
            CreateMap<KorisnikConfirmation, Korisnikk>();

            CreateMap<Korisnikk, KorisnikConfirmation>()
                 .ForMember(
              dest => dest.Tip,
              opt => opt.MapFrom(src => $"{src.Tip.TipKorisnika}"));
            CreateMap<Korisnikk, KorisnikConfirmationDto>();
            CreateMap<KorisnikConfirmationDto, Korisnikk>();

        }
    }
}
