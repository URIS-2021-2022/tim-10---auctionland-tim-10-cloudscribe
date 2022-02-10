using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiciterService.Entities.ZastupnikEntity;
using LiciterService.Models.Zastupnik;
using LiciterService.Models;

namespace LiciterService.Profiles
{
    public class ZastupnikProfile: Profile
    {
      public ZastupnikProfile()
        {
            /*CreateMap<Zastupnik, ZastupnikCreationDto>();
            CreateMap<ZastupnikCreationDto, Zastupnik>();
            CreateMap<Zastupnik, ZastupnikDto>();*/
        }
    }
}
