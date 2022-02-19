using AutoMapper;
using DocumentService.Entities;
using DocumentService.Entities.TipDokumentaEntity;
using DocumentService.Models.DokumentModel;
using DocumentService.Models.TipDokumentaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Profiles.TipDokumentaProfile
{
    public class TipDokumentaProfile : Profile
    {
        public TipDokumentaProfile()
        {

            CreateMap<TipDokumentaE, TipDokumentaDto>();
            CreateMap<TipDokumentaE, TipDokumentaCreationDto>();
            CreateMap<TipDokumentaCreationDto, TipDokumentaE>();
            CreateMap<TipDokumentaE, DokumentUpdateDto>();
            CreateMap<DokumentUpdateDto, Dokument>();
            CreateMap<TipDokumentaE, TipDokumentaConfirmation>();
        }
    }
}
//dodati update model za Tip

