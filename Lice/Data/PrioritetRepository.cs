using Lice.Entities;
using Lice.Entities.Prioritet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Data
{
    public class PrioritetRepository : IPrioritetRepository
    {
        private readonly LiceContext context;

        public PrioritetRepository(LiceContext context)
        {
            this.context = context;
        }
        public PrioritetEntity GetPrioritetById(Guid prioritetId)
        {
            return context.Prioriteti.FirstOrDefault(p => p.prioritetId == prioritetId);
        }

        public List<PrioritetEntity> GetPrioriteti()
        {
            return context.Prioriteti.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
