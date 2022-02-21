using AutoMapper;
using JavnoNadmetanje.Entities;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class JZOPConfirmationProfile : Profile
    {
        public JZOPConfirmationProfile()
        {
            CreateMap<JZOPEntity, JZOPConfirmation>();

            CreateMap<JZOPConfirmation, JZOPConfirmationDto>();

            CreateMap<JZOPConfirmationDto, JZOPConfirmation>();

            CreateMap<JZOPEntity, JZOPConfirmationDto>();
        }
    }
}
