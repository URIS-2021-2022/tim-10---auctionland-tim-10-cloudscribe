using AutoMapper;
using JavnoNadmetanje.Data;
using JavnoNadmetanje.Entities;
using JavnoNadmetanje.Models;
using JavnoNadmetanje.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/jzop")]
    [Produces("application/json", "applciation/xml")]
    public class JzopController : ControllerBase
    {
        private readonly IJzopRepository jzopRepository;
        private readonly IEtapaRepository etapaRepository;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public JzopController(IJzopRepository jzopLiceRepository, IEtapaRepository etapaRepository, ILoggerService loggerService, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.jzopRepository = jzopLiceRepository;
            this.etapaRepository = etapaRepository;
            this.loggerService = loggerService;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "JavnoNadmetanje";
        }

        /// <summary>
        /// Vraća sva javna otvaranja zatvorenih ponuda
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<JzopDto>> GetJZOP()
        {
            loggerDto.HttpMethod = "GET";
            var jzop = jzopRepository.GetJZOP();
            if (jzop == null || jzop.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<JzopDto>>(jzop));
        }

        /// <summary>
        /// Vraća javna otvaranja zatvorenih ponuda na osnovu ID-ja javnih nadmetanja
        /// </summary>
        /// <param name="javnoNadmetanjeId">ID javnog nadmetanja</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{javnoNadmetanjeId}")]
        public ActionResult<JzopDto> GetJZOP(Guid javnoNadmetanjeId)
        {
            loggerDto.HttpMethod = "GET";
            var jzop = jzopRepository.GetJZOPById(javnoNadmetanjeId);

            if (jzop == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);

                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);

            return Ok(mapper.Map<JzopDto>(jzop));
        }

        /// <summary>
        /// Dodaje novo javno zatvaranje otvorenih ponuda
        /// </summary>
        /// <param name="jzop">Model javnih zatvaranja otvorenih ponuda</param>
        /// /// <remarks>
        /// Primer zahteva za kreiranje novog javnog zatvaranja otvorenih ponuda\
        /// POST /api/jzpo \
        /// {   \
        /// "datum" : "2021-05-01T09:00:00",
        /// "vremePocetka" : "2021-05-01T09:00:00",
        /// "vremeKraja" : "2021-05-01T13:59:00",
        /// "pocetnaCena" : 120000,
        /// "izuzeto" : false,
        /// "tip" : 1,
        /// "izlicitiranaCena" : 280000,
        /// "katastarskaOpstina" : "Novi Grad",
        /// "periodZakupa" : 15,
        /// "brojUcesnika" : 25,
        /// "dopunaDepozita" : 5000,
        /// "krug" : 1,
        /// "status" : "Prvi krug",
        /// "etapaID" : "26797103-3a18-4750-9f27-33416e6e30d4",
        /// "brojJZOP" : 1,
        /// "opisJZOP" : ""
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<JzopConfirmationDto> CreateJZOP([FromBody] JzopCreateDto jzop)
        {
            try
            {
                loggerDto.HttpMethod = "POST";
                JzopEntity jzopEntity = mapper.Map<JzopEntity>(jzop);
                jzopEntity.Etapa = etapaRepository.GetEtapaById(jzop.etapaID);
                JzopConfirmation confirmation = jzopRepository.CreateJZOP(jzopEntity);
                jzopRepository.SaveChanges();

                Console.WriteLine(confirmation.brojJZOP);

                string location = linkGenerator.GetPathByAction("GetJZOP", "JZOP", new { javnoNadmetanjeId = confirmation.javnoNadmetanjeID });

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return Created(location, mapper.Map<JzopConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);

                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        /// <summary>
        /// Ažurira postojeće JZOP
        /// </summary>
        /// <param name="jzop">Model JZOP</param>
        /// /// <remarks>
        /// Primer zahteva za ažuriranje postojećeg JZOP\
        /// PUT /api/jzop \
        /// {   \
        /// "javnoNadmetanjeId": "",
        /// "datum" : "2021-05-01T09:00:00",
        /// "vremePocetka" : "2021-05-01T09:00:00",
        /// "vremeKraja" : "2021-05-01T13:59:00",
        /// "pocetnaCena" : 120000,
        /// "izuzeto" : false,
        /// "tip" : 1,
        /// "izlicitiranaCena" : 280000,
        /// "katastarskaOpstina" : "Novi Grad",
        /// "periodZakupa" : 15,
        /// "brojUcesnika" : 25,
        /// "dopunaDepozita" : 5000,
        /// "krug" : 1,
        /// "status" : "Prvi krug",
        /// "etapaID" : "26797103-3a18-4750-9f27-33416e6e30d4",
        /// "brojJZOP" : 1,
        /// "opisJZOP" : ""
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPut]
        public ActionResult<JzopDto> UpdateJZOP([FromBody] JzopUpdateDto jzop)
        {
            try
            {
                var oldJZOP = jzopRepository.GetJZOPById(jzop.javnoNadmetanjeID);

                if (oldJZOP == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }

                JzopEntity jzopEntity = mapper.Map<JzopEntity>(jzop);
                jzopEntity.Etapa = etapaRepository.GetEtapaById(jzop.etapaID);
                mapper.Map(jzopEntity, oldJZOP);
                jzopRepository.SaveChanges();

                return Ok(mapper.Map<JzopDto>(oldJZOP));
            }
            catch (Exception)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);

                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
            }
        }

        /// <summary>
        /// Vrši brisanje jednog JZOP na osnovu ID-ja
        /// </summary>
        /// <param name="javnoNadmetanjeId">ID javnog nadmetanja</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{javnoNadmetanjeId}")]
        public IActionResult DeleteJZOP(Guid javnoNadmetanjeId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var jzop = jzopRepository.GetJZOPById(javnoNadmetanjeId);

                if (jzop == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);

                    return NotFound();
                }

                jzopRepository.DeleteJZOP(javnoNadmetanjeId);
                jzopRepository.SaveChanges();
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        /// <summary>
        /// Sve opcije za rad sa JZOP
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetJZOPOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
