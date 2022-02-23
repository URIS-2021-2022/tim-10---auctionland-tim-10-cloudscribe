using AutoMapper;
using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Profiles
{
    public class OglasJavnoNadmetanjeProfile:Profile
    {
        public OglasJavnoNadmetanjeProfile()
        {
            CreateMap<OglasCreationDto, OglasJavnoNadmetanjeDto>();
        }
    }
}
