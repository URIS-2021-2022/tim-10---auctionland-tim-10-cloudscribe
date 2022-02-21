using JavnoNadmetanje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public interface IJavnoNadmetanjeRepository
    {
        JavnoNadmetanjeEntity GetJavnoNadmetanjeById(Guid javnoNadmetanjeId);
        List<JavnoNadmetanjeEntity> GetAllJavnaNadmetanja();
        JavnoNadmetanjeConfirmation CreateJavnoNadmetanje(JavnoNadmetanjeEntity javnoNadmetanjeEntity);
        void UpdateJavnoNadmetanje(JavnoNadmetanjeEntity javnoNadmetanjeEntity);
        void DeleteJavnoNadmetanje(Guid javnoNadmetanjeId);

        bool SaveChanges();
    }
}
