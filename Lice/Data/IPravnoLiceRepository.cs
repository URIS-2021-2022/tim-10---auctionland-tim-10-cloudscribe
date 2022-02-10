using Lice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Data
{
    public interface IPravnoLiceRepository
    {
        List<PravnoLiceEntity> GetPravnaLica();

        PravnoLiceEntity GetPravnoLiceById(Guid liceId);

        PravnoLiceConfirmationEntity CreatePravnoLice(PravnoLiceEntity pravnoLice);

        void UpdatePravnoLice(PravnoLiceEntity pravnoLice);

        void DeletePravnoLice(Guid liceId);

        bool SaveChanges();
    }
}
