using Lice.Entities;
using Lice.Entities.Lice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Data
{
    public interface ILiceRepository
    {
        List<LiceEntity> GetLica();

        LiceEntity GetLiceById(Guid liceId);

        LiceConfirmationEntity CreateLice(LiceEntity liceEntity);

        void UpdateLice(LiceEntity liceEntity);

        void DeleteLice(Guid liceId);

        bool SaveChanges();
    }
}
