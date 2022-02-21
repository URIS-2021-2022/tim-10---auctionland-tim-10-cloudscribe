using OglasService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Data
{
    public interface ISluzbeniListRepository
    {
        List<SluzbeniList> GetSluzbeniListovi();
        SluzbeniList GetSluzbeniListById(Guid sluzbeniListId);
        SluzbeniListConfirmation CreateSluzbeniList(SluzbeniList sluzbeniList);
        void UpdateSluzbeniList(SluzbeniList sluzbeniList);
        void DeleteSluzbeniList(Guid sluzbeniListId);
        bool SaveChanges();
    }
}
