using Lice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Data
{
    interface ILiceRepository
    {
        List<LiceEntity> GetLica();

        LiceEntity GetLiceById(Guid liceId);

        LiceConfirmationEntity CreateLice(LiceEntity liceEntity);

        void UpdateLice(LiceEntity liceEntity);

        void DeleteLice(Guid liceId);

        bool SaveChanges();
    }
}
