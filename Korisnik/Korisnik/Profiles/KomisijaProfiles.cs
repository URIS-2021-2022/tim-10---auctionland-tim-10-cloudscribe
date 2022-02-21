using AutoMapper;
using Korisnik.Entities;
using Korisnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Profiles
{
    public class KomisijaProfiles : Profile
    {
        public KomisijaProfiles()
        {
            CreateMap<Komisija, KomisijaDto>();
            CreateMap<KomisijaDto, Komisija>();
        }
    }
}
