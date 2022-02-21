using AutoMapper;
using LiciterService.Entities;
using LiciterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Profiles
{
    public class ZastupnikConfirmationProfile: Profile
    {
        public ZastupnikConfirmationProfile()
        {
            CreateMap<ZastupnikConfirmation, ZastupnikConfirmationDto>();
            CreateMap<ZastupnikConfirmationDto, ZastupnikConfirmation>();
        }
    }
}
