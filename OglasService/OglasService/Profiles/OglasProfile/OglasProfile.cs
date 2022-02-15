using AutoMapper;
using OglasService.Entities;
using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Profiles
{
    public class OglasProfile: Profile
    {
        public OglasProfile()
        {
            CreateMap<Oglas, OglasCreationDto>();
            CreateMap <OglasCreationDto, Oglas>();
            CreateMap<Oglas, OglasDto>();
            CreateMap<Oglas, OglasUpdateDto>();
            CreateMap<OglasUpdateDto,Oglas>();
            CreateMap<Oglas, OglasConfirmation>();
        }
    }
}
