using AutoMapper;
using Licitacija.Entities;
using Licitacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Profiles
{
    public class LicitacijaProfile : Profile
    {
        public LicitacijaProfile()
        {
            CreateMap<LicitacijaModel, LicitacijaModelDto>();

            CreateMap<LicitacijaCreateDto, LicitacijaModel>();
            CreateMap<LicitacijaUpdateDto, LicitacijaModel>();

            CreateMap<LicitacijaModel, LicitacijaCreateDto>();
            CreateMap<LicitacijaModel, LicitacijaUpdateDto>();
        }
    }
}
