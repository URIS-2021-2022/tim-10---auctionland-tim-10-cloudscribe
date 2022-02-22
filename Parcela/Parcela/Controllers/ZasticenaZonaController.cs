using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Parcela.Data.ZasticenaZona;
using Parcela.Entities.ZasticenaZona;
using Parcela.Models;
using Parcela.Models.ZasticenaZona;
using Parcela.ServiceCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Controllers
{
    [ApiController]
    [Route("api/zasticenazona")]
    [Produces("application/json", "application/xml")]
    [Authorize]
    public class ZasticenaZonaController : ControllerBase
    {
        private readonly IZasticenaZonaRepository zasticenaZonaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;

        public ZasticenaZonaController(IZasticenaZonaRepository zasticenaZonaRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.zasticenaZonaRepository = zasticenaZonaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "ZAŠTIĆENA ZONA";
        }

        /// <summary>
        /// Vraća sve zaštićene zone.
        /// </summary>
        /// <returns>Lista zaštićenih zona</returns>
        /// <response code="200">Vraća listu zaštićenih zona</response>
        /// <response code="404">Nije pronađena ni jedna zaštićena zona</response>


        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ZasticenZonaDto>> GetZasticenaZona()
        {

            loggerDto.HttpMethod = "GET";
            var zasticenaZona = zasticenaZonaRepository.GetZasticenaZona();
            if(zasticenaZona == null ||zasticenaZona.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<ZasticenZonaDto>>(zasticenaZona));
        }

        /// <summary>
        /// Vraća jednu zaštićenu zonu na osnovu ID-ja.
        /// </summary>
        /// <param name="ZasticenZonaId">ID zaštićene zone</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženu zaštićenu zonu</response>


        [HttpGet("{ZasticenZonaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ZasticenZonaDto> GetZasticenaZonaById(Guid ZasticenZonaId)
        {
            loggerDto.HttpMethod = "GET";
            var zasticenZona = zasticenaZonaRepository.GetZasticenaZonaById(ZasticenZonaId);
            if (zasticenZona == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<ZasticenZonaDto>(zasticenZona));
        }

        /// <summary>
        /// Kreira novu zaštićenu zonu.
        /// </summary>
        /// <param name="zasticenaZona">Model zaštićene zone</param>
        /// <returns>Potvrdu o kreiranoj zaštićenoj zoni.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove zaštićene zone \
        /// POST /api/zasticenazona \
        /// {     \
        ///        zasticenaZona = 6, \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranu zaštićenu zonu</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja zaštićene zone</response>


        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZasticenZonaConfirmationDto> CreateZasticenaZona([FromBody] ZasticenaZonaCreationDto zasticenaZona)
        {

            try
            {
                loggerDto.HttpMethod = "POST";
                ZasticenaZonaEntity zasticenaZonaEntity = mapper.Map<ZasticenaZonaEntity>(zasticenaZona);
                ZasticenaZonaConfirmation confirmation = zasticenaZonaRepository.CreateZasticenaZona(zasticenaZonaEntity);
                zasticenaZonaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetZasticenaZona", "ZasticenaZona", new { zasticenZonaId = confirmation.ZasticenZonaId });
                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<ZasticenZonaConfirmationDto>(confirmation));
            }
            catch
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }



        /// <summary>
        /// Ažurira jednu zaštićenu zonu.
        /// </summary>
        /// <param name="zasticenaZona">Model zaštićene zone koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj zaštićenoj zoni.</returns>
        /// <response code="200">Vraća ažuriranu zaštićenu zonu</response>
        /// <response code="400">Zaštićena zona koja se ažurira nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja zaštićene zone</response>


        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZasticenZonaDto> UpdateZasticenaZona(ZasticenZonaDto zasticenaZona)
        {
            try
            {
                var oldZasticenaZona = zasticenaZonaRepository.GetZasticenaZonaById(zasticenaZona.ZasticenZonaId);
                if(oldZasticenaZona == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }

                ZasticenaZonaEntity zasticenaZonaEntity = mapper.Map<ZasticenaZonaEntity>(zasticenaZona);

                mapper.Map(zasticenaZonaEntity, oldZasticenaZona);

                zasticenaZonaRepository.SaveChanges();
                return Ok(mapper.Map<ZasticenZonaDto>(oldZasticenaZona));
            }
            catch
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        /// <summary>
        /// Vrši brisanje jedne zaštićene zone na osnovu ID-ja.
        /// </summary>
        /// <param name="ZasticenZonaId">ID parcele</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Zaštićena zona uspešno obrisana</response>
        /// <response code="404">Nije pronađena zaštićena zona</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja zaštićene zone</response>

        [HttpDelete("{ZasticenZonaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteZasticenaZona(Guid ZasticenZonaId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var registration = zasticenaZonaRepository.GetZasticenaZonaById(ZasticenZonaId);
                if(registration == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                zasticenaZonaRepository.DeleteZasticenaZona(ZasticenZonaId);
                zasticenaZonaRepository.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                loggerDto.Response = "200 OK";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa zaštićenim zonama
        /// </summary>
        /// <returns></returns>


        [HttpOptions]
        [AllowAnonymous] //Dozvoljavamo pristup anonimnim korisnicima
        public IActionResult GetZasticenaZonaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
