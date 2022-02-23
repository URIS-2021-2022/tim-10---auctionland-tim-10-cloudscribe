using AutoMapper;
using LiciterService.Data;
using LiciterService.Entities;
using LiciterService.Models;
using LiciterService.ServiceCalls;
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
    [Authorize]
    [ApiController]
    [Route("api/liciter")]

    public class LiciterController: ControllerBase
    {
        private readonly ILiciterRepository liciterRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;
        private readonly ILiceService liceService;

        public LiciterController(LinkGenerator linkGenerator,IMapper mapper,ILiciterRepository liciterRepository, ILoggerService loggerService,ILiceService liceService)
        {
            this.liciterRepository = liciterRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "Liciter";
            this.liceService = liceService;
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
            loggerDto.HttpMethod = "GET";
            List<Liciter> liciteri = liciterRepository.GetLiciteri();
            if (liciteri == null || liciteri.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }

            foreach (Liciter b in liciteri)
            {
                LiceLiciterDto lice = liceService.GetLica(b.liceId).Result;
                b.Lice = lice;
            }

            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
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
            loggerDto.HttpMethod = "GET";
            var liciter = liciterRepository.GetLiciterById(liciterId);
            if (liciter == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }

            LiceLiciterDto lice = liceService.GetLica(liciter.liceId).Result;
            liciter.Lice = lice;
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<LiciterDto>(liciter));

        }

        /// <summary>
        /// Kreiranje licitera
        /// </summary>
        /// <param name="liciter"></param>
        /// <returns></returns>
        ///  Primer zahteva za kreiranje licitera
        /// POST /api/liciter\
        ///  {
        ///       "kupacId": "32cd906d-8bab-457c-ade2-fbc4ba523029",
        ///       "zastupnikId": "044f3de0-a9dd-4c2e-b745-89976a1b2a52"      
        ///   }
        /// <response code="200">Vraća kreiranog licitera</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja licitera</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LiciterConfirmationDto> CreateLiciter([FromBody] LiciterCreationDto liciter)
        {
            try
            {
                loggerDto.HttpMethod = "POST";

                Liciter liciterEntity = mapper.Map<Liciter>(liciter);
                LiciterConfirmation confirmation = liciterRepository.CreateLiciter(liciterEntity);
                liciterRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetLiciter", "Liciter", new { liciterId = confirmation.LiciterId });

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return Created(location, mapper.Map<LiciterConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        /// <summary>
        /// Azuriranje licitera
        /// </summary>
        /// <param name="liciter">Model licitera</param>
        /// <returns></returns>
        ///Primer zahteva za azuriranje licitera
        /// PUT /api/liciter\
        /// {
        ///      "liciterId": "6a411c13-a195-48f7-8dbd-67596c3974c0",
        ///      "kupacId": "32cd906d-8bab-457c-ade2-fbc4ba523029",
        ///       "zastupnikId": "044f3de0-a9dd-4c2e-b745-89976a1b2a52"      
        ///  }
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
                    loggerDto.Level = "WARN";
                    return NotFound();
                }
                mapper.Map(liciter, oldLiciter);
                liciterRepository.SaveChanges();
                return Ok(mapper.Map<LiciterDto>(oldLiciter));
            }
            catch (Exception)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
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
                loggerDto.HttpMethod = "DELETE";
                var liciter = liciterRepository.GetLiciterById(liciterId);

                if (liciter == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                liciterRepository.DeleteLiciter(liciterId);
                liciterRepository.SaveChanges();

                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return NoContent();
            }
            catch (Exception)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);

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
