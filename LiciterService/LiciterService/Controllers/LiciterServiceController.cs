using LiciterService.Data;
using LiciterService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Controllers
{
    [ApiController]
    [Route("api/liciter")]
    public class LiciterServiceController: ControllerBase
    {
        private readonly ILiciterRepository liciterRepository;

        public LiciterServiceController(ILiciterRepository liciterRepository)
        {
            this.liciterRepository = liciterRepository;
        }

        [HttpGet("{liciterId}")]
        public ActionResult<LiciterDto> GetLiciter(Guid liciterId)
        {
            var liciter = liciterRepository.GetLiciterById(liciterId);
            if(liciter == null)
            {
                return NotFound();
            }
            return Ok(liciter);

        }
    }
}
