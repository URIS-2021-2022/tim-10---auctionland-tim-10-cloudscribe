using AutoMapper;
using LiciterService.Entities.ZastupnikEntity;
using LiciterService.Models.Zastupnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Profiles.Zastupnik
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
