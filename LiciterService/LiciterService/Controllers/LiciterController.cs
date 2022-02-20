using AutoMapper;
using LiciterService.Data;
using LiciterService.Entities;
using LiciterService.Models;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class LiciterController: ControllerBase
    {
        private readonly ILiciterRepository liciterRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public LiciterController(LinkGenerator linkGenerator,IMapper mapper,ILiciterRepository liciterRepository)
        {
            this.liciterRepository = liciterRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Vraca sve licitere
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraća licitere</response>
        /// <response code="500">Došlo je do greške na serveru</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<LiciterDto>> GetLiciteri()
        {
            var liciteri = liciterRepository.GetLiciteri();
            if (liciteri == null || liciteri.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<LiciterDto>>(liciteri));
        }

        /// <summary>
        /// Vraca licitere po id-ju
        /// </summary>
        /// <param name="liciterId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Kreiranje licitera
        /// </summary>
        /// <param name="liciter"></param>
        /// <returns></returns>
        /// <response code="200">Vraća kreiranog licitera</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja licitera</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LiciterConfirmationDto> CreateLiciter([FromBody] LiciterCreationDto liciter)
        {
            try
            {
                Liciter liciterEntity = mapper.Map<Liciter>(liciter);
                LiciterConfirmation confirmation = liciterRepository.CreateLiciter(liciterEntity);
                liciterRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetLiciter", "Liciter", new { liciterId = confirmation.LiciterId });
                return Created(location, mapper.Map<LiciterConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        /// <summary>
        /// Azuriranje licitera
        /// </summary>
        /// <param name="liciter">Model licitera</param>
        /// <returns></returns>
        /// <response code="200">Vraća ažuriranog licitera</response>
        /// <response code="400">Liciter koji se ažurira nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja licitera</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LiciterConfirmationDto> UpdateLiciter(LiciterUpdateDto liciter)
        {
            try
            {
                var oldLiciter = liciterRepository.GetLiciterById(liciter.LiciterId);
                if (oldLiciter == null)
                {
                    return NotFound();
                }
                Liciter liciterEntity = mapper.Map<Liciter>(liciter);
                mapper.Map(liciterEntity, oldLiciter);
                liciterRepository.SaveChanges();
                return Ok(mapper.Map<LiciterConfirmationDto>(oldLiciter));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        /// <summary>
        /// Brisanje licitera
        /// </summary>
        /// <param name="liciterId">ID licitera</param>
        /// <returns></returns>
        /// <response code="204">Liciter uspešno obrisan</response>
        /// <response code="404">Nije pronađen liciter za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja licitera</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{liciterId}")]
        public IActionResult DeleteLiciter(Guid liciterId)
        {
            try
            {
                var liciter = liciterRepository.GetLiciterById(liciterId);

                if (liciter == null)
                {
                    return NotFound();
                }

                liciterRepository.DeleteLiciter(liciterId);
                liciterRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Vraca opcije za rad sa liciterima
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetLiciterOpctions()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT, DELETE");
            return Ok();
        }
    }
}
