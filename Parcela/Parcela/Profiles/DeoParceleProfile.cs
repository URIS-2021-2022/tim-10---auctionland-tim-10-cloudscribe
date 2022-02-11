using AutoMapper;
using Parcela.Entities.DeoParcele;
using Parcela.Models.DeoParcele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Profiles
{
    public class DeoParceleProfile : Profile
    {
        public DeoParceleProfile()
        {
            CreateMap<DeoParceleEntity, DeoParceleDto>();
            CreateMap<DeoParceleCreationDto, DeoParceleEntity>();
            CreateMap<DeoParceleUpdateDto, DeoParceleEntity>();
            CreateMap<DeoParceleEntity, DeoParceleEntity>();
        }
    }
}
