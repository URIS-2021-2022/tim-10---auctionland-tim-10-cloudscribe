using Licitacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public Task<JavnaLicitacijaDto> GetJavnaLicitacijaById(Guid javnoNadmetanjeId);
    }
}
