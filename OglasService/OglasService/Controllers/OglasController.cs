using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OglasService.Data;
using OglasService.Entities;
using OglasService.Models;
using OglasService.ServiceCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/oglas")]
    public class OglasController:ControllerBase
    {
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly IOglasRepository oglasRepository;
        private readonly ILoggerService loggerService;
        private readonly LoggerDtos loggerDto;
        private readonly IJavnoNadmetanjeService javnoNadmetanjeService;

        public OglasController(IMapper mapper,LinkGenerator linkGenerator,IOglasRepository oglasRepository,ILoggerService loggerService,IJavnoNadmetanjeService javnoNadmetanjeService)
        {
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.oglasRepository = oglasRepository;
            this.loggerService = loggerService;
            loggerDto = new LoggerDtos();
            loggerDto.ServiceName = "Oglas";
            this.javnoNadmetanjeService = javnoNadmetanjeService;
        }

        /// <summary>
        /// Vraca sve oglase
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraća oglase</response>
        /// <response code="500">Došlo je do greške na serveru</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<OglasDto>> GetOglasi()
        {
            loggerDto.HttpMethod = "GET";
            var oglasi = oglasRepository.GetOglasi();
            if(oglasi==null || oglasi.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }

            foreach (Oglas b in oglasi)
            {
                OglasJavnoNadmetanjeDto javnoNadmetanje = javnoNadmetanjeService.GetJavnaNadmetanje(b.javnoNadmetanjeID).Result;
                b.javnoNadmetanje= javnoNadmetanje;
            }

            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<OglasDto>>(oglasi));
        }

        /// <summary>
        /// Vraca oglase po id-ju
        /// </summary>
        /// <param name="oglasId"></param>
        /// <returns></returns>
        [HttpGet("{oglasId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<OglasDto> GetOglas(Guid oglasId)
        {
            loggerDto.HttpMethod = "GET";
            var oglas = oglasRepository.GetOglasById(oglasId);
            if (oglas == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }

            OglasJavnoNadmetanjeDto javnoNadmetanje = javnoNadmetanjeService.GetJavnaNadmetanje(oglas.javnoNadmetanjeID).Result;
            oglas.javnoNadmetanje = javnoNadmetanje;

            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<OglasDto>(oglas));
        }

        /// <summary>
        /// Kreiranje oglasa
        /// </summary>
        /// <param name="oglas"></param>
        /// <returns></returns>
        /// Primer zahteva za kreiranje novog oglasa
        ///  POST /api/oglas \
        ///  {
        ///    "tekstOglasa": "Javno nadmetanje je u nedelju",
        ///    "sluzbeniListId": "6a411c13-a195-48f7-8dbd-67596c397475"
       ///    }
       /// <response code="200">Vraća kreirani oglas</response>
       /// <response code="500">Došlo je do greške na serveru prilikom kreiranja oglasa</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OglasConfirmationDto> CreateOglas([FromBody] OglasCreationDto oglas)
        {
            try
            {
                loggerDto.HttpMethod = "POST";

                Oglas oglasEntity = mapper.Map<Oglas>(oglas);
                OglasConfirmation confirmation = oglasRepository.CreateOglas(oglasEntity);
                oglasRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetOglas", "Oglas", new { oglasId = confirmation.OglasId });

              

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return Created(location, mapper.Map<OglasConfirmationDto>(confirmation));
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
        /// Azuriranje oglasa
        /// </summary>
        /// <param name="oglas"></param>
        /// <returns></returns>
        /// Primer zahteva za azuriranje novog oglasa
        ///  PUT /api/oglas \
        ///  {
        ///"oglasId": "15816081-a068-4ef1-896c-08d9f553aebe",
        ///"tekstOglasa": "radi",
        ///"sluzbeniListId": "6a411c13-a195-48f7-8dbd-67596c397475"
        ///} 
        /// <response code="200">Vraća ažurirani oglas</response>
        /// <response code="400">Oglas koji se ažurira nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja oglasa</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OglasConfirmationDto> UpdateOglas(OglasUpdateDto oglas)
        {
            try
            {
                var oldOglas = oglasRepository.GetOglasById(oglas.OglasId);
                if (oldOglas == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }
                mapper.Map(oglas, oldOglas);
                oglasRepository.SaveChanges();
                return Ok(mapper.Map<OglasDto>(oldOglas));
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
        /// Brisanje oglasa
        /// </summary>
        /// <param name="oglasId"></param>
        /// <returns></returns>
        /// <response code="204">Oglas uspešno obrisan</response>
        /// <response code="404">Nije pronađen oglas za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja oglasa</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{oglasId}")]
        public IActionResult DeleteOglas(Guid oglasId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var oglas = oglasRepository.GetOglasById(oglasId);

                if (oglas == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                oglasRepository.DeleteOglas(oglasId);
                oglasRepository.SaveChanges();

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
        /// Vraca opcije za rad sa oglasima
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
