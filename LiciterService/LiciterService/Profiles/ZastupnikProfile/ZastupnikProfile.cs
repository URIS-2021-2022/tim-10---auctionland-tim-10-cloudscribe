using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiciterService.Entities;
using LiciterService.Models;

namespace LiciterService.Profiles
{
    public class ZastupnikProfile: Profile
    {
      public ZastupnikProfile()
        {
            CreateMap<Zastupnik, ZastupnikDto>();
            CreateMap<Zastupnik, ZastupnikCreationDto>();
            CreateMap<ZastupnikCreationDto, Zastupnik>();
            CreateMap<Zastupnik, ZastupnikUpdateDto>();
            CreateMap<ZastupnikUpdateDto, Zastupnik>();
            CreateMap<Zastupnik, ZastupnikConfirmation>();
            CreateMap<Zastupnik, Zastupnik>();
        }
    }
}
