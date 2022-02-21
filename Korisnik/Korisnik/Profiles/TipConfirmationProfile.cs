using AutoMapper;
using Korisnik.Entities;
using Korisnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Profiles
{
    public class TipConfirmationProfile : Profile
    {
        public TipConfirmationProfile()
        {
            CreateMap<Tip, TipDto>();
        }
    }
}
