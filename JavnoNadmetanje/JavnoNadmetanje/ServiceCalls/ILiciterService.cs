using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.ServiceCalls
{
    public interface ILiciterService
    {
        public Task<LiciterDto> GetLiciterById(Guid liciterId);
    }
}
