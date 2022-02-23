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
    [Route("api/javneLicitacije")]
    [Produces("application/json", "applciation/xml")]
    public class JavnaLicitacijaController : ControllerBase
    {
        private readonly IJavnaLicitacijaRepository javnaLicitacijaRepository;
        private readonly IEtapaRepository etapaRepository;
        private readonly IKorakCeneRepository korakCeneRepository;
        private readonly ILoggerService loggerService;
        private readonly IAdresaService adresaService;
        private readonly ILiciterService liciterService;
        private readonly IParcelaService parcelaService;
        private readonly LoggerDto loggerDto;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public JavnaLicitacijaController(IJavnaLicitacijaRepository javnaLicitacijaRepository, IEtapaRepository etapaRepository, IKorakCeneRepository korakCeneRepository, ILoggerService loggerService, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.javnaLicitacijaRepository = javnaLicitacijaRepository;
            this.etapaRepository = etapaRepository;
            this.korakCeneRepository = korakCeneRepository;
            this.loggerService = loggerService;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "JavnoNadmetanje";
        }

        /// <summary>
        /// Vraća sve javne licitacije
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<JavnaLicitacijaDto>> GetJavneLicitacije()
        {
            loggerDto.HttpMethod = "GET";
            var javneLicitacije = javnaLicitacijaRepository.GetJavneLicitacije();
            if (javneLicitacije == null || javneLicitacije.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }

            foreach (JavnaLicitacijaEntity lDto in javneLicitacije) 
            {
                AdresaDto adresaDto = adresaService.GetAdresaById(lDto.adresaId).Result;
                lDto.adresaDto = adresaDto;

                LiciterDto liciter = liciterService.GetLiciterById(lDto.liciterId).Result;
                lDto.liciterDto = liciter;

                ParcelaDto parcela = parcelaService.GetParcelaById(lDto.parcelaId).Result;
                lDto.parcelaDto = parcela;


            }

            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<JavnaLicitacijaDto>>(javneLicitacije));
        }

        /// <summary>
        /// Vraća javnu licitaciju na osnovu ID-ja javnog nadmetanja
        /// </summary>
        /// <param name="javnoNadmetanjeId">ID javnog nadmetanja</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{javnoNadmetanjeId}")]
        public ActionResult<JavnaLicitacijaDto> GetJavnaLicitacija(Guid javnoNadmetanjeId)
        {
            loggerDto.HttpMethod = "GET";
            var javnaLicitacija = javnaLicitacijaRepository.GetJavnaLicitacijaById(javnoNadmetanjeId);

            if (javnaLicitacija == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }

            AdresaDto adresaDto = adresaService.GetAdresaById(javnaLicitacija.adresaId).Result;
            javnaLicitacija.adresaDto = adresaDto;

            LiciterDto liciter = liciterService.GetLiciterById(javnaLicitacija.liciterId).Result;
            javnaLicitacija.liciterDto = liciter;

            ParcelaDto parcela = parcelaService.GetParcelaById(javnaLicitacija.parcelaId).Result;
            javnaLicitacija.parcelaDto = parcela;

            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<JavnaLicitacijaDto>(javnaLicitacija));
        }

        /// <summary>
        /// Dodaje novu javnu licitaciju
        /// </summary>
        /// <param name="javnaLicitacija">Model javne licitacije</param>
        /// /// <remarks>
        /// Primer zahteva za kreiranje nove javne licitacije\
        /// POST /api/javneLicitacije \
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
        /// "brojJavnElicitacije" : 1,
        /// "opisJavneLicitacije" : "",
        /// "korakCeneID" : ""
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<JavnaLicitacijaConfirmationDto> CreateJavnaLicitacija([FromBody] JavnaLicitacijaCreateDto javnaLicitacija)
        {
            try
            {
                loggerDto.HttpMethod = "POST";

                JavnaLicitacijaEntity javnaLicitacijaEntity = mapper.Map<JavnaLicitacijaEntity>(javnaLicitacija);
                javnaLicitacijaEntity.Etapa = etapaRepository.GetEtapaById(javnaLicitacija.etapaID);
                javnaLicitacijaEntity.KorakCene = korakCeneRepository.GetKorakCeneById(javnaLicitacija.korakCeneID);
                JavnaLicitacijaConfirmation confirmation = javnaLicitacijaRepository.CreateJavnaLicitacija(javnaLicitacijaEntity);
                javnaLicitacijaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetJavnaLicitacija", "JavnaLicitacija", new { javnoNadmetanjeId = confirmation.javnoNadmetanjeID });

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return Created(location, mapper.Map<JavnaLicitacijaConfirmationDto>(confirmation));
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
        /// Ažurira postojeću javnu licitaciju
        /// </summary>
        /// <param name="javnaLicitacija">Model javne licitacije</param>
        /// /// <remarks>
        /// Primer zahteva za ažuriranje postojeće javne licitacije\
        /// PUT /api/javneLicitacije \
        /// {   \
        ///     "javnoNadmetanjeId": "",
        ///     "datum" : "2021-05-01T09:00:00",
        ///     "vremePocetka" : "2021-05-01T09:00:00",
        ///     "vremeKraja" : "2021-05-01T13:59:00",
        ///     "pocetnaCena" : 120000,
        ///     "izuzeto" : false,
        ///     "tip" : 1,
        ///     "izlicitiranaCena" : 280000,
        ///     "katastarskaOpstina" : "Novi Grad",
        ///     "periodZakupa" : 15,
        ///     "brojUcesnika" : 25,
        ///     "dopunaDepozita" : 5000,
        ///     "krug" : 1,
        ///     "status" : "Prvi krug",
        ///     "etapaID" : "26797103-3a18-4750-9f27-33416e6e30d4"
        ///     "brojJavneLicitacije" : 1,
        ///     "opisJavneLicitacije" : "",
        ///     "korakCeneID" : ""
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPut]
        public ActionResult<JavnaLicitacijaDto> UpdateJavnaLicitacija([FromBody] JavnaLicitacijaUpdateDto javnaLicitacija)
        {
            try
            {
                var oldJavnaLicitacija = javnaLicitacijaRepository.GetJavnaLicitacijaById(javnaLicitacija.javnoNadmetanjeID);

                if (oldJavnaLicitacija == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }

                JavnaLicitacijaEntity javnaLicitacijaEntity = mapper.Map<JavnaLicitacijaEntity>(javnaLicitacija);
                javnaLicitacijaEntity.Etapa = etapaRepository.GetEtapaById(javnaLicitacija.etapaID);
                javnaLicitacijaEntity.KorakCene = korakCeneRepository.GetKorakCeneById(javnaLicitacija.korakCeneID);
                mapper.Map(javnaLicitacijaEntity, oldJavnaLicitacija);
                javnaLicitacijaRepository.SaveChanges();

                return Ok(mapper.Map<JavnaLicitacijaDto>(oldJavnaLicitacija));
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
        /// Vrši brisanje jednog javnog nadmetanja na osnovu ID-ja
        /// </summary>
        /// <param name="javnoNadmetanjeId">ID javnog nadmetanja</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{javnoNadmetanjeId}")]
        public IActionResult DeleteJavnaLicitacija(Guid javnoNadmetanjeId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var javnaLicitacija = javnaLicitacijaRepository.GetJavnaLicitacijaById(javnoNadmetanjeId);

                if (javnaLicitacija == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);

                    return NotFound();
                }

                javnaLicitacijaRepository.DeleteJavnaLicitacija(javnoNadmetanjeId);
                javnaLicitacijaRepository.SaveChanges();

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
        /// Sve opcije za rad sa javnim licitacijama
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetJavnaLicitacijaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
