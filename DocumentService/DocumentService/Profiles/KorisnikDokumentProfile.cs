using AutoMapper;
using DocumentService.Models;
using DocumentService.Models.DokumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Profiles
{
    public class KorisnikDokumentProfile : Profile
    {
        public KorisnikDokumentProfile()
        {
            CreateMap<DokumentCreationDto, KorisnikDokumentDto>();
        }
    }
}
