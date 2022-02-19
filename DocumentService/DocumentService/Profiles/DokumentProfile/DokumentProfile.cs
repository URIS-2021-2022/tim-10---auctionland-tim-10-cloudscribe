using AutoMapper;
using DocumentService.Entities;
using DocumentService.Models;
using DocumentService.Models.DokumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Profiles
{
    public class DokumentProfile : Profile
    {
        public DokumentProfile()
        {
            CreateMap<Dokument, DokumentDto>();
            CreateMap<Dokument, DokumentCreationDto>();
            CreateMap<DokumentCreationDto, Dokument>();
            CreateMap<Dokument, DokumentUpdateDto>();
            CreateMap<DokumentUpdateDto, Dokument>();
            CreateMap<Dokument, DokumentConfirmation>();


        }

    }
}
