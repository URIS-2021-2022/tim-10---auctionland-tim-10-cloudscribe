using AutoMapper;
using LiciterService.Entities;
using LiciterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Profiles
{
    public class LiciterProfile: Profile
    {
        public LiciterProfile()
        {
            CreateMap<Liciter, LiciterDto>();
            CreateMap<Liciter, LiciterCreationDto>();
            CreateMap<LiciterCreationDto, Liciter>();
            CreateMap<Liciter, LiciterUpdateDto>();
            CreateMap<LiciterUpdateDto, Liciter>();
            CreateMap<Liciter, LiciterConfirmation>();
            CreateMap<Liciter, Liciter>();
        }
    }
}
