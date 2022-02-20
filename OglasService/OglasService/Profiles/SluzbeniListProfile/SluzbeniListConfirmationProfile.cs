using AutoMapper;
using OglasService.Entities;
using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Profiles.SluzbeniListProfile
{
    public class SluzbeniListConfirmationProfile:Profile
    {
        public SluzbeniListConfirmationProfile()
        {
            CreateMap<SluzbeniListConfirmation, SluzbeniListConfirmationDto>();
            CreateMap<SluzbeniListConfirmationDto, SluzbeniListConfirmation>();
            CreateMap<SluzbeniList, SluzbeniListConfirmation>();
        }

    }
}
