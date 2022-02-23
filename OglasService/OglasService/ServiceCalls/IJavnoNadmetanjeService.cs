using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public bool JavnoNadmetanjeInOglas(Guid javnoNadmetanjeID);
    }
}
