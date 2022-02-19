using AutoMapper;
using DocumentService.Entities;
using DocumentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Profiles
{
    public class DokumentConfirmationProfile : Profile
    {
        public DokumentConfirmationProfile()
        {
            CreateMap<DokumentConfirmation, DokumentConfirmationDto>();
            CreateMap<DokumentConfirmationDto, DokumentConfirmation>();
        }
    }
}
