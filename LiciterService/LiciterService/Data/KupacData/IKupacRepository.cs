using LiciterService.Entities;
using LiciterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data
{
    public interface IKupacRepository
    {
        List<Kupac> GetKupci();
        Kupac GetKupacById(Guid kupacId);
        KupacConfirmation CreateKupac(Kupac kupac);
        void UpdateKupac(Kupac kupac);
        void DeleteKupac(Guid kupacId);
        bool SaveChanges();
        
    }
}
