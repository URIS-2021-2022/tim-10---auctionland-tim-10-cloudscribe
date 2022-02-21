using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data
{
    public interface IZastupnikRepository
    {
        List<Zastupnik> GetZastupnici();
        Zastupnik GetZastupnikById(Guid zastupnikId);
        ZastupnikConfirmation CreateZastupnik(Zastupnik zastupnik);
        //void UpdateZastupnik(Zastupnik zastupnik);
        void DeleteZastupnik(Guid zastupnikId);
        bool SaveChanges();

    }
}
