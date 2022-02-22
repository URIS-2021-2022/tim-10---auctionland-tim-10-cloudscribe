using AutoMapper;
using Korisnik.Data;
using Korisnik.Entities;
using Korisnik.Models;
using Korisnik.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Controllers
{   [ApiController]
        [Route("api/komisija")]
        [Produces("application/json", "application/xml")] //Sve akcije kontrolera mogu da vraćaju definisane formate
    [Authorize(Roles = "Administrator, Prva komisija")]
    public class KomisijaController: ControllerBase
    {
        
        private readonly IKomisijaRepository komisijaRepository;
        private readonly LinkGenerator linkGenerator;


        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;
        public KomisijaController(IKomisijaRepository komisijaRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.komisijaRepository = komisijaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "KORISNIK";
        }

        /// <summary>
        /// Vraća sve komisije
        /// </summary>

        /// <returns>Lista komisija</returns>
        /// <response code="200">Vraća listu komisija</response>
        /// <response code="404">Nije pronan ni jedan tip</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)] //Eksplicitno definišemo šta sve može ova akcija da vrati
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KomisijaDto>> GetKomisije()
        {
            
            loggerDto.HttpMethod = "GET";
            List<Komisija> komisija = komisijaRepository.GetKomisija();
            if (komisija == null || komisija.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();

            }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<KomisijaDto>>(komisija));
        }
        /// <summary>
        /// Vraća komisiju na osnovu prosledjenog ID-ja
        /// </summary>
        /// <param name="komisijaId">ID komisije</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženu komisiju </response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet("{komisijaId}")]
        public ActionResult<KomisijaDto> GetKomisijaId(Guid komisijaId)
        {
            loggerDto.HttpMethod = "GET";
            Komisija komisijaModel = komisijaRepository.GetKomisijaById(komisijaId);
            if (komisijaModel == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<KomisijaDto>(komisijaModel));
        }

        /// <summary>
        /// Vrši brisanje komisije na osnovu prosledjenog ID-ja
        /// </summary>
        /// <param name="komisijaId">ID komisije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">komisija je uspesno obrisana</response>
        /// <response code="404">komisija nije pronadjena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja komisije</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [HttpDelete("{komisijaId}")]
        public IActionResult DeleteKomisija(Guid komisijaId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                Komisija komisijaModel = komisijaRepository.GetKomisijaById(komisijaId);
                if (komisijaModel == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }
                komisijaRepository.DeleteKomisija(komisijaId);
                komisijaRepository.SaveChanges();
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            catch
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");

            }
        }

        /// <summary>
        /// Kreira novu komisiju
        /// </summary>
        /// <param name="komisijaa">Model komisije</param>
        /// <returns>Potvrdu o kreiranoj komisiji </returns>
        /// <remarks>
        /// Primer zahteva za kreiranje komisije \
        /// POST /api/ExamRegistration \
        /// {     \
        ///     "KomisijaId": "2841defc-761e-40d8-b8a3-d3e58516dca7", \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranu komisiju</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja komisije</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KomisijaDto> CreateKomisija([FromBody] KomisijaDto komisijaa)
        {
            try
            {
                loggerDto.HttpMethod = "POST";
                
                Komisija komisija = mapper.Map<Komisija>(komisijaa);
                Komisija confirmation = komisijaRepository.CreateKomisija(komisija);
                string location = linkGenerator.GetPathByAction("GetKomisije", "Komisija", new { komisijaId = confirmation.KomisijaId });
                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<Komisija>(confirmation));
            }
            catch(Exception e)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);

            }



        }

        /// <summary>
        /// Ažurira jednog korisnika
        /// </summary>
        /// <param name="komisija">Model komisije koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj komisiji.</returns>
        /// <response code="200">Vraća ažuriranu komisiju</response>
        /// <response code="400">komisija nije pronadjena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja komisije</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KomisijaDto> UpdateKomisija(KomisijaDto komisija)
        {


            try
            {
                var oldKomisija = komisijaRepository.GetKomisijaById(komisija.KomisijaId);
                if (oldKomisija == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }
                mapper.Map(komisija, oldKomisija);
                komisijaRepository.SaveChanges();
                return Ok(mapper.Map<KomisijaDto>(oldKomisija));

            }
            catch (Exception)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");


            }


        }
    }
}
