using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public Task<OglasJavnoNadmetanjeDto> GetJavnaNadmetanje(Guid javnoNadmetanjeID);
    }
}
