using AutoMapper;
using Lice.Entities;
using Lice.Entities.Prioritet;
using Lice.Models.FizickoLice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Profiles
{
    public class FizickoLiceProfile : Profile
    {
        public FizickoLiceProfile()
        {
            CreateMap<FizickoLiceEntity, FizickoLiceDto>()
            .ForMember(
                dest => dest.ImePrezime,
                opt => opt.MapFrom(src => src.ime + " " + src.prezime))
            .ForMember(
                dest => dest.opisPrioriteta, 
                opt => opt.MapFrom(src => src.Prioritet.opisPrioriteta));

            CreateMap<FizickoLiceCreationDto, FizickoLiceEntity>();
            CreateMap<FizickoLiceUpdateDto, FizickoLiceEntity>();
            CreateMap<FizickoLiceEntity, FizickoLiceEntity>();
        }
    }
}
