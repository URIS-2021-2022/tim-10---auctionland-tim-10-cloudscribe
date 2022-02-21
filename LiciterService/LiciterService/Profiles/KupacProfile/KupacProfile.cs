using AutoMapper;
using LiciterService.Entities;
using LiciterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Profiles
{
    public class KupacProfile: Profile
    {
        public KupacProfile()
        {
            CreateMap<Kupac, KupacCreationDto>();
            CreateMap<KupacCreationDto, Kupac>();
            CreateMap<Kupac, KupacDto>();
            CreateMap<Kupac, KupacUpdateDto>();
            CreateMap<KupacUpdateDto, Kupac>();
            CreateMap<Kupac, KupacConfirmation>();
            CreateMap<Kupac, Kupac>();
        }
    }
}
