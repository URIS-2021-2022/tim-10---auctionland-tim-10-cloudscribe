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
    [Route("api/kupac")]

    public class KupacController : ControllerBase
    {
        
        private readonly IKupacRepository kupacRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;
        private readonly IAdresaService adresaService;
        private readonly AdresaZastupnikDto AdresaDto;

        public KupacController(IMapper mapper,LinkGenerator linkGenerator, IKupacRepository kupacRepository, ILoggerService loggerService,IAdresaService adresaService)
        {
           
            this.kupacRepository = kupacRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "Kupac";

            this.adresaService = adresaService;
            AdresaDto = new AdresaZastupnikDto();
        }

        /// <summary>
        /// Vraca sve kupce
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraća kupce</response>
        /// <response code="500">Došlo je do greške na serveru</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KupacDto>> GetKupci()
        {
            loggerDto.HttpMethod = "GET";
            var kupci = kupacRepository.GetKupci();
            if(kupci==null || kupci.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<KupacDto>>(kupci));
        }

       /// <summary>
       /// Vraca kupce po id-ju
       /// </summary>
       /// <param name="kupacId"></param>
       /// <returns></returns>
        [HttpGet("{kupacId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<KupacDto> GetKupac(Guid kupacId)
        {
            loggerDto.HttpMethod = "GET";
            var kupac = kupacRepository.GetKupacById(kupacId);
            if(kupac == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<KupacDto>(kupac));
        }

        /// <summary>
        /// Kreiranje kupca
        /// </summary>
        /// <param name="kupac">Model kupca</param>
        /// <returns></returns>
        /// Primer zahteva za kreiranje kupca
        /// POST /api/kupac\
        ///  {
        ///        "datumPocetkaZabrane": "2020-11-15T09:00:00",
        ///        "datumPrestankaZabrane": "2021-11-15T09:00:00",
        ///        "duzinaTrajanjaZabrane": 365,
        ///         "imaZabranu": true,
        ///        "ostvarenaPovrsina": 1500000,
        ///        "zastupnikId": "044f3de0-a9dd-4c2e-b745-89976a1b2a52"
        ///}
        ///<response code="200">Vraća kreiranog kupca</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja kupca</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacConfirmationDto> CreateKupac([FromBody] KupacCreationDto kupac)
        {
            try
            {
                loggerDto.HttpMethod = "POST";

                Kupac kupacEntity = mapper.Map<Kupac>(kupac);
                KupacConfirmation confirmation = kupacRepository.CreateKupac(kupacEntity);
                kupacRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetKupac", "Kupac", new { kupacId = confirmation.KupacId });

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return Created(location, mapper.Map<KupacConfirmationDto>(confirmation));
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
        /// Azuriranje kupca
        /// </summary>
        /// <param name="kupac">Model kupca</param>
        /// <returns></returns>
        /// Primer zahteva za azuriranje kupca
        /// PUT /api/kupac\
        ///   {
        ///       "kupacId": "044f3de0-a9dd-4c2e-b745-89976a1b2a36",
        ///       "datumPocetkaZabrane": "2020-11-15T09:00:00",
        ///       "datumPrestankaZabrane": "2021-11-15T09:00:00",
        ///       "duzinaTrajanjaZabrane": 11156999,
        ///       "imaZabranu": true,
        ///       "ostvarenaPovrsina": 1500000,
        ///       "zastupnikId": "044f3de0-a9dd-4c2e-b745-89976a1b2a52"
        ///    }
        ///<response code="200">Vraća ažuriranog kupca</response>
        /// <response code="400">Kupac koja se ažurira nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kupca</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacConfirmationDto> UpdateKupac(KupacUpdateDto kupac)
        {
            
            try
            {
                var oldKupac = kupacRepository.GetKupacById(kupac.KupacId);
                if (oldKupac == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }
                //Kupac kupacEntity = mapper.Map<Kupac>(kupac);
                mapper.Map(kupac, oldKupac);
                kupacRepository.SaveChanges();
                return Ok(mapper.Map<KupacDto>(oldKupac));
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
        /// Brisanje kupca
        /// </summary>
        /// <param name="kupacId">ID kupca</param>
        /// <returns></returns>
        /// <response code="204">Kupac uspešno obrisan</response>
        /// <response code="404">Nije pronađen kupac za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja kupca</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{kupacId}")]
        public IActionResult DeleteKupac(Guid kupacId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var kupac = kupacRepository.GetKupacById(kupacId);

                if (kupac == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                kupacRepository.DeleteKupac(kupacId);
                kupacRepository.SaveChanges();
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
        /// Vraca opcije za rad sa kupcima
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKupacOpctions()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT, DELETE");
            return Ok();
        }
    }
}
