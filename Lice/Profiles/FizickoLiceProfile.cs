using AutoMapper;
using Lice.Entities;
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
                    opt => opt.MapFrom(src => src.ime + " " + src.prezime));

            CreateMap<FizickoLiceCreationDto, FizickoLiceEntity>();
            CreateMap<FizickoLiceUpdateDto, FizickoLiceEntity>();
            CreateMap<FizickoLiceEntity, FizickoLiceEntity>();
        }
    }
}
