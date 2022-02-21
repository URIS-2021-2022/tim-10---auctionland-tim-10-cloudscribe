using AutoMapper;
using Korisnik.Entities;
using Korisnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Profiles
{
    public class TipProfiles : Profile
    {
        public TipProfiles()
        {
            CreateMap<Tip, TipDto>();
            CreateMap<TipDto, Tip>();
            CreateMap<TipDto, TipDto>();

        }
    }
}
