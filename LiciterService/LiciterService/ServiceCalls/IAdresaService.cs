using LiciterService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.ServiceCalls
{
    public interface IAdresaService
    {
        public Task<AdresaZastupnikDto> GetAdrese(Guid adresaId);
    }
}
