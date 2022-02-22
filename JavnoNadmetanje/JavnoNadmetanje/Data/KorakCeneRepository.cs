using JavnoNadmetanje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public class KorakCeneRepository : IKorakCeneRepository
    {
        private readonly JavnoNadmetanjeContext context;

        public KorakCeneRepository(JavnoNadmetanjeContext context)
        {
            this.context = context;
        }
        public KorakCeneEntity GetKorakCeneById(Guid javnoNadmetanjeId)
        {
            return context.KorakCene.FirstOrDefault(p => p.korakCeneID == javnoNadmetanjeId);
        }

        public List<KorakCeneEntity> GetKorakCene()
        {
            return context.KorakCene.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
