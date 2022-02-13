using AutoMapper;
using LiciterService.Data;
using LiciterService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Controllers
{
    [ApiController]
    [Route("api/liciter")]
    //[Authorize]
    public class LiciterController: ControllerBase
    {
        private readonly ILiciterRepository liciterRepository;
        private readonly IMapper mapper;

        public LiciterController(IMapper mapper,ILiciterRepository liciterRepository)
        {
            this.liciterRepository = liciterRepository;
            this.mapper = mapper;
        }

        [HttpGet("{liciterId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<LiciterDto> GetLiciter(Guid liciterId)
        {
            var liciter = liciterRepository.GetLiciterById(liciterId);
            if (liciter == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LiciterDto>(liciter));

        }
    }
}
