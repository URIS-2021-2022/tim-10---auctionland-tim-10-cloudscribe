using AutoMapper;
using DocumentService.Entities.TipDokumentaEntity;
using DocumentService.Models.TipDokumentaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Profiles.TipDokumentaProfile
{
    public class TipDokumentaConfirmationProfile : Profile
    {
        public TipDokumentaConfirmationProfile() {

            CreateMap<TipDokumentaConfirmation, TipDokumentaConfirmationDto>();
            CreateMap<TipDokumentaConfirmationDto, TipDokumentaConfirmation>();
        }
    }
}
