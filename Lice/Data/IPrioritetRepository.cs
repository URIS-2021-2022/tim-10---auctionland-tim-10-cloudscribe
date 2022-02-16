using Lice.Entities.Prioritet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Data
{
    public interface IPrioritetRepository
    {
        List<PrioritetEntity> GetPrioriteti();

        PrioritetEntity GetPrioritetById(Guid liceId);

        bool SaveChanges();
    }
}
