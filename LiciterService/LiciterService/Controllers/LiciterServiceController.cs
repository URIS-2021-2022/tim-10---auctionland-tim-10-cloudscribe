using LiciterService.Data;
using LiciterService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Controllers
{
    [ApiController]
    [Route("api/liciter")]
    public class LiciterServiceController : ControllerBase
    {
        private readonly ILiciterRepository liciterRepository;
        private readonly IKupacRepository kupacRepository;
        private readonly LinkGenerator linkGenerator;

        public LiciterServiceController(LinkGenerator linkGenerator,ILiciterRepository liciterRepository, IKupacRepository kupacRepository)
        {
            this.liciterRepository = liciterRepository;
            this.kupacRepository = kupacRepository;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet("{liciterId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<LiciterDto> GetLiciter(Guid liciterId)
        {
            var liciter = liciterRepository.GetLiciterById(liciterId);
            if(liciter == null)
            {
                return NotFound();
            }
            return Ok(liciter);

        }

        /// <summary>
        /// Vraca sve kupce
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraća kreiranu prijavu ispita</response>
        /// <response code="500">Došlo je do greške na serveru prilikom prijave ispita</response>
        [HttpGet("kupac")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KupacDto>> GetKupci()
        {
            var kupci = kupacRepository.GetKupci();
            if(kupci==null || kupci.Count == 0)
            {
                return NoContent();
            }
            return Ok(kupci);
        }
       /// <summary>
       /// Vraca kupce po id-ju
       /// </summary>
       /// <param name="kupacId"></param>
       /// <returns></returns>
        [HttpGet("kupac/{kupacId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<KupacDto> GetKupac(Guid kupacId)
        {
           var kupac = kupacRepository.GetKupacById(kupacId);
            if(kupac == null)
            {
                return NotFound();
            }
            return Ok(kupac);

        }

        /*public ActionResult<KupacDto> CreateKupac([FromBody] KupacDto kupac)
        {
            try
            {
                KupacDto confirmation = kupacRepository.CreateKupac(kupac);
                kupacRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetKupci", "Kupci", new { kupacId = confirmation.KupacId });

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
            
        }*/
    }
}
