using AutoMapper;
using Lice.Entities;
using Lice.Models.PravnoLice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Profiles
{
    public class PravnoLiceConfirmationProfile : Profile
    {
        public PravnoLiceConfirmationProfile()
        {
            CreateMap<PravnoLiceEntity, PravnoLiceConfirmationEntity>()
                .ForMember(
                    dest => dest.opisPrioriteta,
                    opt => opt.MapFrom(src => src.Prioritet.opisPrioriteta));

            CreateMap<PravnoLiceConfirmationEntity, PravnoLiceConfirmationDto>()
                .ForMember(
                    dest => dest.opisPrioriteta,
                    opt => opt.MapFrom(src => src.opisPrioriteta));

            CreateMap<PravnoLiceEntity, PravnoLiceConfirmationDto>();
        }
    }
}
