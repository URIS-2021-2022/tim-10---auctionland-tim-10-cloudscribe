using Lice.Entities;
using Lice.Entities.Lice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Data
{
    public class LiceRepository : ILiceRepository
    {

        public LiceRepository()
        {

        }
        public LiceConfirmationEntity CreateLice(LiceEntity liceEntity)
        {
            throw new NotImplementedException();
        }

        public void DeleteLice(Guid liceId)
        {
            throw new NotImplementedException();
        }

        public List<LiceEntity> GetLica()
        {
            throw new NotImplementedException();
        }

        public LiceEntity GetLiceById(Guid liceId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateLice(LiceEntity liceEntity)
        {
            throw new NotImplementedException();
        }
    }
}
