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
   //[Authorize]
    [Route("api/jzop")]
    [Produces("application/json", "applciation/xml")]
    public class JZOPController : ControllerBase
    {
        private readonly IJZOPRepository jzopRepository;
        private readonly IEtapaRepository etapaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public JZOPController(IJZOPRepository jzopLiceRepository, IEtapaRepository etapaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.jzopRepository = jzopLiceRepository;
            this.etapaRepository = etapaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sva javna otvaranja zatvorenih ponuda
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<JZOPDto>> GetJZOP()
        {
            var jzop = jzopRepository.GetJZOP();
            if (jzop == null || jzop.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<JZOPDto>>(jzop));
        }

        /// <summary>
        /// Vraća javna otvaranja zatvorenih ponuda na osnovu ID-ja javnih nadmetanja
        /// </summary>
        /// <param name="javnoNadmetanjeId">ID javnog nadmetanja</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{javnoNadmetanjeId}")]
        public ActionResult<JZOPDto> GetJZOP(Guid javnoNadmetanjeId)
        {
            var jzop = jzopRepository.GetJZOPById(javnoNadmetanjeId);

            if (jzop == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<JZOPDto>(jzop));
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
        public ActionResult<JZOPConfirmationDto> CreateJZOP([FromBody] JZOPCreateDto jzop)
        {
            try
            {
                JZOPEntity jzopEntity = mapper.Map<JZOPEntity>(jzop);
                jzopEntity.Etapa = etapaRepository.GetEtapaById(jzop.etapaID);
                JZOPConfirmation confirmation = jzopRepository.CreateJZOP(jzopEntity);
                jzopRepository.SaveChanges();

                Console.WriteLine(confirmation.brojJZOP);

                string location = linkGenerator.GetPathByAction("GetJZOP", "JZOP", new { javnoNadmetanjeId = confirmation.javnoNadmetanjeID });
                return Created(location, mapper.Map<JZOPConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
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
        public ActionResult<JZOPDto> UpdateJZOP([FromBody] JZOPUpdateDto jzop)
        {
            try
            {
                var oldJZOP = jzopRepository.GetJZOPById(jzop.javnoNadmetanjeID);

                if (oldJZOP == null)
                {
                    return NotFound();
                }

                JZOPEntity jzopEntity = mapper.Map<JZOPEntity>(jzop);
                jzopEntity.Etapa = etapaRepository.GetEtapaById(jzop.etapaID);
                mapper.Map(jzopEntity, oldJZOP);
                jzopRepository.SaveChanges();

                return Ok(mapper.Map<JZOPDto>(oldJZOP));
            }
            catch (Exception)
            {
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
                var jzop = jzopRepository.GetJZOPById(javnoNadmetanjeId);

                if (jzop == null)
                {
                    return NotFound();
                }

                jzopRepository.DeleteJZOP(javnoNadmetanjeId);
                jzopRepository.SaveChanges();
                return NoContent();
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
