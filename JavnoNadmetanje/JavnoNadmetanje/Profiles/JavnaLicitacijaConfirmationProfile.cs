using AutoMapper;
using JavnoNadmetanje.Entities;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class JavnaLicitacijaConfirmationProfile : Profile
    {
        public JavnaLicitacijaConfirmationProfile()
        {
            CreateMap<JavnaLicitacijaEntity, JavnaLicitacijaConfirmation>();

            CreateMap<JavnaLicitacijaConfirmation, JavnaLicitacijaConfirmationDto>();

            CreateMap<JavnaLicitacijaConfirmationDto, JavnaLicitacijaConfirmation>();

            CreateMap<JavnaLicitacijaEntity, JavnaLicitacijaConfirmationDto>();
        }
       
    }
}
