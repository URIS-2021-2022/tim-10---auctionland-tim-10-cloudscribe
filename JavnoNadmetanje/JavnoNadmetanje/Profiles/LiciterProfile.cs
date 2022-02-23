using AutoMapper;
using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Profiles
{
    public class LiciterProfile : Profile
    {
        public LiciterProfile(){

        CreateMap<JavnaLicitacijaCreateDto, LiciterDto>();
        CreateMap<JzopCreateDto, LiciterDto>();

            }
    }
}
