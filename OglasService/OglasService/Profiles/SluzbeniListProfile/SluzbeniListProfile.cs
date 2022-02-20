using AutoMapper;
using OglasService.Entities;
using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Profiles.SluzbeniListProfile
{
    public class SluzbeniListProfile: Profile
    {
        public SluzbeniListProfile()
        {
            CreateMap<SluzbeniList, SluzbeniListCreationDto>();
            CreateMap<SluzbeniListCreationDto, SluzbeniList>();
            CreateMap<SluzbeniList, SluzbeniListDto>();
            CreateMap<SluzbeniList, SluzbeniListUpdateDto>();
            CreateMap<SluzbeniListUpdateDto, SluzbeniList>();
            CreateMap<SluzbeniList, SluzbeniListConfirmation>();
            CreateMap<SluzbeniList, SluzbeniList>();
        }
    }
}
