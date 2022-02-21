using JavnoNadmetanje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public interface IKorakCeneRepository
    {
        List<KorakCeneEntity> GetKorakCene();

        KorakCeneEntity GetKorakCeneById(Guid javnoNadmetanjeId);

        bool SaveChanges();
    }
}
