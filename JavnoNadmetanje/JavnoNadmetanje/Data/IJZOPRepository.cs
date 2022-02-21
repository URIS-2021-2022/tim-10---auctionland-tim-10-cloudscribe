using JavnoNadmetanje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public interface IJZOPRepository
    {
        List<JZOPEntity> GetJZOP();

        JZOPEntity GetJZOPById(Guid javnoNadmetanjeId);

        JZOPConfirmation CreateJZOP(JZOPEntity JZOP);

        void UpdateJZOP(JZOPEntity JZOP);

        void DeleteJZOP(Guid javnoNadmetanjeId);

        bool SaveChanges();
    }
}
