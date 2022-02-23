using AutoMapper;
using LiciterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Profiles
{
    public class AdresaZastupnikProfile: Profile
    {
        public AdresaZastupnikProfile()
        {
            CreateMap<ZastupnikCreationDto, AdresaZastupnikDto>();
        }
    }
}
