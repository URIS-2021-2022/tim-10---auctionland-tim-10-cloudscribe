using JavnoNadmetanje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public interface IJzopRepository
    {
        List<JzopEntity> GetJZOP();

        JzopEntity GetJZOPById(Guid javnoNadmetanjeId);

        JzopConfirmation CreateJZOP(JzopEntity JZOP);

        void UpdateJZOP(JzopEntity JZOP);

        void DeleteJZOP(Guid javnoNadmetanjeId);

        bool SaveChanges();
    }
}
