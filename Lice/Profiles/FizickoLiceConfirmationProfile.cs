using AutoMapper;
using Lice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Profiles
{
    public class FizickoLiceConfirmationProfile : Profile
    {
        public FizickoLiceConfirmationProfile()
        {
            CreateMap<FizickoLiceEntity, FizickoLiceConfirmationEntity>();
        }
    }
}
