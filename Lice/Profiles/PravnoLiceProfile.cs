using AutoMapper;
using Lice.Entities;
using Lice.Models.PravnoLice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Profiles
{
    public class PravnoLiceProfile : Profile
    {
        public PravnoLiceProfile()
        {
            CreateMap<PravnoLiceEntity, PravnoLiceDto>()
            .ForMember(dest => dest.opisPrioriteta, opt => opt.MapFrom(src => src.Prioritet.opisPrioriteta)); ;

            CreateMap<PravnoLiceCreationDto, PravnoLiceEntity>();
            CreateMap<PravnoLiceUpdateDto, PravnoLiceEntity>();
            CreateMap<PravnoLiceEntity, PravnoLiceEntity>();
        }
    }
}
