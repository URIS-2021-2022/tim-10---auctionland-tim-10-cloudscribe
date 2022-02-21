using AutoMapper;
using Licitacija.Entities;
using Licitacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Profiles
{
    public class LicitacijaConfirmationProfile :Profile
    {
        public LicitacijaConfirmationProfile()
        {
            CreateMap<LicitacijaConfirmation, LicitacijaConfirmationDto>();

            CreateMap<LicitacijaModel, LicitacijaConfirmation>();

        }
    }
}
