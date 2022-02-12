using AutoMapper;
using Lice.Entities;
using Lice.Models.FizickoLice;
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

            CreateMap<FizickoLiceConfirmationEntity, FizickoLiceConfirmationDto>()
                .ForMember(
                    dest => dest.ImePrezime,
                    opt => opt.MapFrom(src => src.ime + " " + src.prezime));

            CreateMap<FizickoLiceEntity, FizickoLiceConfirmationDto>()
                .ForMember(
                    dest => dest.ImePrezime,
                    opt => opt.MapFrom(src => src.ime + " " + src.prezime));

        }
    }
}
