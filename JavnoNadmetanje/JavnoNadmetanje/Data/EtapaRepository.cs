using JavnoNadmetanje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public class EtapaRepository : IEtapaRepository
    {
        private readonly JavnoNadmetanjeContext context;

        public EtapaRepository(JavnoNadmetanjeContext context)
        {
            this.context = context;
        }
        public EtapaEntity GetEtapaById(Guid etapaId)
        {
            return context.Etapa.FirstOrDefault(p => p.etapaID == etapaId);
        }

        public List<EtapaEntity> GetEtape()
        {
            return context.Etapa.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
