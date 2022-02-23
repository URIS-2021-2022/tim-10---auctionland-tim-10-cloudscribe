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
    [Route("api/zastupnik")]

    public class ZastupnikController: ControllerBase
    {
        private readonly IZastupnikRepository zastupnikRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;
        private readonly IAdresaService adresaService;

        public ZastupnikController(IZastupnikRepository zastupnikRepository,IMapper mapper,LinkGenerator linkGenerator,ILoggerService loggerService,IAdresaService adresaService)
        {
            this.zastupnikRepository = zastupnikRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "Zastupnik";
            this.adresaService = adresaService;
        }

        /// <summary>
        /// Vraca sve zastupnike
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraća zastupnike</response>
        /// <response code="500">Došlo je do greške na serveru</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ZastupnikDto>> GetZastupnici()
        {
            loggerDto.HttpMethod = "GET";
            //var zastupnici = zastupnikRepository.GetZastupnici();
            List<Zastupnik> zastupnici= zastupnikRepository.GetZastupnici();
            if (zastupnici == null || zastupnici.Count==0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }

            foreach (Zastupnik b in zastupnici)
            {
               AdresaZastupnikDto adresa = adresaService.GetAdrese(b.AdresaId).Result;
                b.Adresa = adresa;
              
            }

            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<ZastupnikDto>>(zastupnici));
        }
        /// <summary>
        /// Vracanje zastupnika po id-ju
        /// </summary>
        /// <param name="zastupnikId"></param>
        /// <returns></returns>
        /// <response code="200">Vraća zastupnika po id-ju</response>
        [HttpGet("{zastupnikId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ZastupnikDto> GetZastupnik(Guid zastupnikId)
        {
            loggerDto.HttpMethod = "GET";
            var zastupnik = zastupnikRepository.GetZastupnikById(zastupnikId);
            if (zastupnik == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }

            AdresaZastupnikDto adresa = adresaService.GetAdrese(zastupnik.AdresaId).Result;

            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<ZastupnikDto>(zastupnik));
        }

        /// <summary>
        /// Kreiranje zastupnika
        /// </summary>
        /// <param name="zastupnik"></param>
        /// <returns></returns>
        /// Primer zahteva za kreiranje zastupnika
        /// POST /api/zastupnik\
        /// {
        ///    "jmbg": "",
        ///    "brojPasosa": "123456789",
        ///    "nazivDrzave": "Rusija",
        ///    "brojTable": 365,
        ///    "kupacId": "044f3de0-a9dd-4c2e-b745-89976a1b2a36"
        ///  }
        /// <response code="200">Vraća kreiranog zastupnika</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja zastupnika</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZastupnikConfirmationDto> CreateZastupnik([FromBody] ZastupnikCreationDto zastupnik)
        {
            try
            {
                loggerDto.HttpMethod = "POST";

                Zastupnik zastupnikEntity = mapper.Map<Zastupnik>(zastupnik);
                ZastupnikConfirmation confirmation = zastupnikRepository.CreateZastupnik(zastupnikEntity);
                zastupnikRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetZastupnik", "Zastupnik", new { zastupnikId = confirmation.ZastupnikId });

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return Created(location, mapper.Map<ZastupnikConfirmationDto>(confirmation));
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
        /// Azuriranje zastupnika
        /// </summary>
        /// <param name="zastupnik"></param>
        /// <returns></returns>
        /// Primer zahteva za azuriranje zastupnika
        /// PUT /api/zastupnik\
        /// {
        ///    "zastupnikId": "044f3de0-a9dd-4c2e-b745-89976a1b2a52",
        ///    "jmbg": "5896634547231",
        ///    "brojPasosa": "123456789",
        ///    "nazivDrzave": "Slovenija",
        ///    "brojTable": 365,
        ///    "kupacId": "32cd906d-8bab-457c-ade2-fbc4ba523029"  
        ///  }
        /// <response code="400">Zastupnik koji se ažurira nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja zastupnika</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZastupnikConfirmationDto> UpdateZastupnik(ZastupnikUpdateDto zastupnik)
        {
            try
            {
                var oldZastupnik = zastupnikRepository.GetZastupnikById(zastupnik.ZastupnikId);
                if (oldZastupnik == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }
                mapper.Map(zastupnik,oldZastupnik);
                zastupnikRepository.SaveChanges();
                return Ok(mapper.Map<ZastupnikDto>(oldZastupnik));
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
        /// Brisanje zastupnika
        /// </summary>
        /// <param name="zastupnikId"></param>
        /// <returns></returns>
        /// <response code="404">Nije pronađen zastupnik za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja zastupnika</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{zastupnikId}")]
        public IActionResult DeleteZastupnik(Guid zastupnikId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var zastupnik = zastupnikRepository.GetZastupnikById(zastupnikId);

                if (zastupnik == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                zastupnikRepository.DeleteZastupnik(zastupnikId);
                zastupnikRepository.SaveChanges();
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
        /// Vraca opcije za rad sa zastupnicima
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetZastupnikOpctions()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT, DELETE");
            return Ok();
        }
    }
}
