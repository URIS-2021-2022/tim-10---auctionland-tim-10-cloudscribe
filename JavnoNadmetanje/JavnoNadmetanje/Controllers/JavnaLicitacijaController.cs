using AutoMapper;
using JavnoNadmetanje.Data;
using JavnoNadmetanje.Entities;
using JavnoNadmetanje.Models;
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
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public JavnaLicitacijaController(IJavnaLicitacijaRepository javnaLicitacijaRepository, IEtapaRepository etapaRepository, IKorakCeneRepository korakCeneRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.javnaLicitacijaRepository = javnaLicitacijaRepository;
            this.etapaRepository = etapaRepository;
            this.korakCeneRepository = korakCeneRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
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
            var javneLicitacije = javnaLicitacijaRepository.GetJavneLicitacije();
            if (javneLicitacije == null || javneLicitacije.Count == 0)
            {
                return NoContent();
            }
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
            var javnaLicitacija = javnaLicitacijaRepository.GetJavnaLicitacijaById(javnoNadmetanjeId);

            if (javnaLicitacija == null)
            {
                return NotFound();
            }
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
                JavnaLicitacijaEntity javnaLicitacijaEntity = mapper.Map<JavnaLicitacijaEntity>(javnaLicitacija);
                javnaLicitacijaEntity.Etapa = etapaRepository.GetEtapaById(javnaLicitacija.etapaID);
                javnaLicitacijaEntity.KorakCene = korakCeneRepository.GetKorakCeneById(javnaLicitacija.korakCeneID);
                JavnaLicitacijaConfirmation confirmation = javnaLicitacijaRepository.CreateJavnaLicitacija(javnaLicitacijaEntity);
                javnaLicitacijaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetJavnaLicitacija", "JavnaLicitacija", new { javnoNadmetanjeId = confirmation.javnoNadmetanjeID });
                return Created(location, mapper.Map<JavnaLicitacijaConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
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
                var javnaLicitacija = javnaLicitacijaRepository.GetJavnaLicitacijaById(javnoNadmetanjeId);

                if (javnaLicitacija == null)
                {
                    return NotFound();
                }

                javnaLicitacijaRepository.DeleteJavnaLicitacija(javnoNadmetanjeId);
                javnaLicitacijaRepository.SaveChanges();
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
