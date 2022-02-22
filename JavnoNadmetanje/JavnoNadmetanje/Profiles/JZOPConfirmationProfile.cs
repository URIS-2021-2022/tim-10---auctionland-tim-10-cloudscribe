using AutoMapper;
using JavnoNadmetanje.Entities;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class JzopConfirmationProfile : Profile
    {
        public JzopConfirmationProfile()
        {
            CreateMap<JzopEntity, JzopConfirmation>();

            CreateMap<JzopConfirmation, JzopConfirmationDto>();

            CreateMap<JzopConfirmationDto, JzopConfirmation>();

            CreateMap<JzopEntity, JzopConfirmationDto>();
        }
    }
}
