using AutoMapper;
using LiciterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Profiles
{
    public class LiceLiciterProfile:Profile
    {
        public LiceLiciterProfile()
        {
            CreateMap<LiciterCreationDto, LiceLiciterDto>();
        }
    }
}
