using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data
{
    public interface ILiciterRepository
    {
        Liciter GetLiciterById(Guid liciterId);
        bool SaveChanges();
    }
}
