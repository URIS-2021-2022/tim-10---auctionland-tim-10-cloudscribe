using AutoMapper;
using OglasService.Entities;
using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Profiles
{
    public class OglasConfirmationProfile:Profile
    {
        public OglasConfirmationProfile()
        {
            CreateMap<OglasConfirmation, OglasConfirmationDto>();
            CreateMap<OglasConfirmationDto, OglasConfirmation>();
        }
    }
}
