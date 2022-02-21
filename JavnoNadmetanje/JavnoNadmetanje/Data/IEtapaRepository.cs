using JavnoNadmetanje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public interface IEtapaRepository
    {
        List<EtapaEntity> GetEtape();

        EtapaEntity GetEtapaById(Guid javnoNadmetanjeId);

        bool SaveChanges();
    }
}
