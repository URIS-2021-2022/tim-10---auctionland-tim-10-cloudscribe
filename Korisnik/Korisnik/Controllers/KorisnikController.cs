
using AutoMapper;
using Korisnik.Data;
using Korisnik.Entities;
using Korisnik.Helpers;
using Korisnik.Models;
using Korisnik.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Korisnik.Controllers
{
    [ApiController]
    [Route("api/korisnik")]
    [Produces("application/json", "application/xml")] //Sve akcije kontrolera mogu da vraćaju definisane formate
    [Authorize(Roles = "Administrator")]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikRepository korisnikRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IAuthenticationHelper authenticationHelper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;

        private readonly IMapper mapper;
        public KorisnikController(IKorisnikRepository korisnikRepository, IHttpContextAccessor httpContextAccessor,LinkGenerator linkGenerator, IMapper mapper, IAuthenticationHelper authenticationHelper, ILoggerService loggerService, LoggerDto loggerDto)
        {
            this.korisnikRepository = korisnikRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.authenticationHelper = authenticationHelper;
            this.httpContextAccessor = httpContextAccessor;
            this.loggerService = loggerService;
            loggerDto =  new LoggerDto();
            loggerDto.ServiceName = "KORISNIK";
        }
        /// <summary>
        /// Vraća sve korisnike
        /// </summary>

        /// <returns>Lista korisnika</returns>
        /// <response code="200">Vraća listu korisnika</response>
        /// <response code="404">Nije pronan ni jedan korisnik</response>
        //[Authorize(Roles = "Administrator")]
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)] //Eksplicitno definišemo šta sve može ova akcija da vrati
        [ProducesResponseType(StatusCodes.Status204NoContent)]
       // [Authorize]
        public ActionResult<List<KorisnikDto>> GetKorisnici()
        {
            loggerDto.HttpMethod = "GET";
            var identityClaims = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;
            List<Korisnikk> korisnici = korisnikRepository.GetKorisnik();
            if (korisnici == null || korisnici.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerService.CreateLog(loggerDto);
                return NoContent();

            }
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<KorisnikDto>>(korisnici));
        }

        /// <summary>
        /// Vraća jednog korisnika na osnovu njegovog ID-ja
        /// </summary>
        /// <param name="korisnikId">ID korisnika</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženog korisnika</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize(Roles = "Administrator")]
        [HttpGet("{korisnikId}")]
        public ActionResult<KorisnikDto> GetKorisnik(Guid korisnikId)
        {
            loggerDto.HttpMethod = "GET";
            Korisnikk korisnikModel = korisnikRepository.GetKorisnikById(korisnikId);
            if (korisnikModel == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<KorisnikDto>(korisnikModel));
        }
        /// <summary>
        /// Vraća listu korisnika na osnovu ID-ja komisije
        /// </summary>
        /// <param name="komisijaId">ID komisije</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženog korisnika</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet("/komisija/{komisijaId}")]
        
        public ActionResult<KorisnikDto> GetKorisnikByKomisija(Guid komisijaId)
        {
            loggerDto.HttpMethod = "GET";
            List<Korisnikk> korisnici = korisnikRepository.GetKorisnikByIdKomisija(komisijaId);
            if (korisnici == null || korisnici.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerService.CreateLog(loggerDto);
                return NoContent();

            }
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<KorisnikDto>>(korisnici));

        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet("/tip/{tipkorisnika}")]
        public ActionResult<KorisnikDto> GetKorisnikByTip(string tipKorisnika)
        {
            loggerDto.HttpMethod = "GET";
            List<Korisnikk> korisnici = korisnikRepository.GetKorisnikByImeTipa(tipKorisnika);
            if(korisnici == null || korisnici.Count==0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<KorisnikDto>>(korisnici));
        }
        /// <summary>
        /// Vrši brisanje korisnika na osnovu prosledjenog ID-ja
        /// </summary>
        /// <param name="korisnikId">ID korisnika</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Korisnik je uspesno obrisan</response>
        /// <response code="404">Korisnik nije pronadjen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja korisnika</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       // [Authorize(Roles = "Administrator")]
        [HttpDelete("{KorisnikId}")]
       public IActionResult DeleteKorisnik(Guid korisnikId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                Korisnikk korisnikModel = korisnikRepository.GetKorisnikById(korisnikId);
                if(korisnikModel== null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }
                korisnikRepository.DeleteKorisnik(korisnikId);
                korisnikRepository.SaveChanges();
                loggerDto.Response = "204 NO CONTENT";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            catch
            {
                loggerDto.Response = "500 SERVER ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");

            }
        }

        /// <summary>
        /// Kreira novog korisnika
        /// </summary>
        /// <param name="korisnikk">Model korisnika</param>
        /// <returns>Potvrdu o kreiranom korisniku </returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog korisnika \
        /// POST /api/ExamRegistration \
        /// {     \
        ///     "KorisnikId": "2841defc-761e-40d8-b8a3-d3e58516dca7", \
        ///     "KorisnikIme": "Teodora", \
        ///     "KorisnikPrezime": "Jovanovic", \
        ///     "TipId" : "4563cf92-b8d0-4574-9b40-a725f884da36", \ 
        ///     "KomisijaId" : "00000000-0000-0000-0000-000000000000", \ 
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranog korisnika</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja korisnika</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public ActionResult<KorisnikConfirmationDto> CreateKorisnik([FromBody] KorisnikCreationDto korisnikk)
        {
            try
            {
                loggerDto.HttpMethod = "POST";
                Korisnikk korisnik = mapper.Map<Korisnikk>(korisnikk);
                authenticationHelper.CreateHash(korisnik);
                KorisnikConfirmation confirmation = korisnikRepository.CreateKorisnik(korisnik);
                string location = linkGenerator.GetPathByAction("GetKorisnik", "Korisnik", new { korisnikId = confirmation.KorisnikId });
                loggerDto.Response = "201 CREATED";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<KorisnikConfirmationDto>(confirmation));
            }
            catch(Exception e)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);

            }
                

        
        }

        /// <summary>
        /// Ažurira jednog korisnika
        /// </summary>
        /// <param name="korisnik">Model korisnika koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom korisniku.</returns>
        /// <response code="200">Vraća ažuriranog korisnika</response>
        /// <response code="400">korisnik nije pronadjen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja korisnika</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Administrator, Superuser, Tehnicki sekretar, Prva komisija, Menadzer, Operator nadmetanja")]
        public ActionResult<KorisnikConfirmationDto> UpdateKorisnik(KorisnikUpdateDto korisnik)
        {
            

            try
            {
                loggerDto.HttpMethod = "PUT";
                var oldKorisnik = korisnikRepository.GetKorisnikById(korisnik.KorisnikId);
                if (oldKorisnik == null)
                {
                    loggerDto.Response = "401 NOT FOUND";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }
              //  var korisnikEntity = mapper.Map<KorisnikUpdateDto>(oldKorisnik);
                mapper.Map(korisnik, oldKorisnik);
                korisnikRepository.SaveChanges();
                loggerDto.Response = "200 OK";
                loggerService.CreateLog(loggerDto);
                return Ok(mapper.Map<KorisnikConfirmationDto>(oldKorisnik));

            }
            catch(Exception e)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");


            }


        }
        /// <summary>
        /// Vraća opcije za rad sa korisnicima
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        public IActionResult GetkorisnikOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }


    }
}
