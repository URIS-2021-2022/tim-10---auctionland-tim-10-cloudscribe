using LiciterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.ServiceCalls
{
    public interface ILiceService
    {
        public Task<LiceLiciterDto> GetLica(Guid liceId);

    }
}
