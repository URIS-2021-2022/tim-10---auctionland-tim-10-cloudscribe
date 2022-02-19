using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data
{
    public interface ILiciterRepository
    {
        List<Liciter> GetLiciteri();
        Liciter GetLiciterById(Guid liciterId);
        LiciterConfirmation CreateLiciter(Liciter liciter);
        void UpdateLiciter(Liciter liciter);
        void DeleteLiciter(Guid liciterId);
        bool SaveChanges();
    }
}
