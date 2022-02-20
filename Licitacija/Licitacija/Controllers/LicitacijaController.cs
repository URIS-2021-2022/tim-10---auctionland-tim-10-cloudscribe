using AutoMapper;
using Licitacija.Data;
using Licitacija.Entities;
using Licitacija.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Controllers
{
    [ApiController]
    [Route("api/licitacije")]
    [Produces("application/json", "applciation/xml")]
  //  [Authorize]
    public class LicitacijaController : ControllerBase
    {
        private readonly ILicitacijaRepository licitacijaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public LicitacijaController(ILicitacijaRepository licitacijaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.licitacijaRepository = licitacijaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve licitacije
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<LicitacijaModelDto>> GetAllLicitacije()
        {
            var licitacije = licitacijaRepository.GetAllLicitacije();
            if (licitacije == null || licitacije.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<LicitacijaModelDto>>(licitacije));
        }

        /// <summary>
        /// Vraća licitaciju na osnovu ID-ja licitacije
        /// </summary>
        /// <param name="licitacijaId">ID lica</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{licitacijaId}")]
        public ActionResult<LicitacijaModelDto> GetLicitacija(Guid licitacijaId)
        {
            var licitacijaModel = licitacijaRepository.GetLicitacijaById(licitacijaId);
            if (licitacijaModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LicitacijaModelDto>(licitacijaModel));
        }

        /// <summary>
        /// Dodaje novu licitaciju
        /// </summary>
        /// <param name="licitacija">Model licitacije</param>
        /// /// <remarks>
        /// Primer zahteva za kreiranje nove licitacije\
        /// POST /api/licitacija \
        /// {   \
        /// "brojLicitacije" : 3,
        /// "godinaLicitacije" : 2021,
        /// "datumRaspisivanja" : "2021-06-01T09:00:00",
        /// "ogranicenje" : 0,
        /// "dokumentId" : 3,
        /// "krugLicitacije" : 1,
        /// "rokZaPrijave" : "2021-07-01T23:59:00",
        /// "javnoNadmetanjeId" : 3
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<LicitacijaConfirmationDto> CreateLicitacija([FromBody] LicitacijaCreateDto licitacija)
        {
            try
            {
                LicitacijaModel licitacijaModel = mapper.Map<LicitacijaModel>(licitacija);

                LicitacijaConfirmation confirmation = licitacijaRepository.CreateLicitacija(licitacijaModel);

                licitacijaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetLicitacija", "Licitacija", new { licitacijaId = confirmation.licitacijaId });
                return Created(location, mapper.Map<LicitacijaConfirmationDto>(confirmation));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        /// <summary>
        /// Vrši brisanje jedne licitacije na osnovu ID-ja
        /// </summary>
        /// <param name="licitacijaId">ID licitacije</param>
        /// <returns></returns>
        [HttpDelete("{licitacijaId}")]
        public IActionResult DeleteLicitacija(Guid licitacijaId)
        {
            try
            {
                var licitacijaModel = licitacijaRepository.GetLicitacijaById(licitacijaId);
                if (licitacijaModel == null)
                {
                    return NotFound();
                }
                licitacijaRepository.DeleteLicitacija(licitacijaId);
                licitacijaRepository.SaveChanges();

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        /// <summary>
        /// Ažurira postojeću licitaciju
        /// </summary>
        /// <param name="licitacija">Model licitacije</param>
        /// /// <remarks>
        /// Primer zahteva za ažuriranje postojeće licitacije\
        /// PUT /api/licitacija \
        /// {   \
        ///     "licitacijaId" : "",
        /// "brojLicitacije" : 3,
        /// "godinaLicitacije" : 2021,
        /// "datumRaspisivanja" : "2021-06-01T09:00:00",
        /// "ogranicenje" : 1,
        /// "dokumentId" : 3,
        /// "krugLicitacije" : 2,
        /// "rokZaPrijave" : "2021-07-01T23:59:00",
        /// "javnoNadmetanjeId" : 3
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPut]
        public ActionResult<LicitacijaModelDto> UpdateLicitacija(LicitacijaUpdateDto licitacija)
        {
            try
            {
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                var oldLicitacija = licitacijaRepository.GetLicitacijaById(licitacija.licitacijaId);

                if (oldLicitacija == null)
                {
                    return NotFound(); //Ukoliko ne postoji vratiti status 404 (NotFound).
                }
                LicitacijaModel licitacijaModelEntity = mapper.Map<LicitacijaModel>(licitacija);
                mapper.Map(licitacijaModelEntity, oldLicitacija); //Update objekta koji treba da sačuvamo u bazi                

                licitacijaRepository.SaveChanges(); //Perzistiramo promene
                return Ok(mapper.Map<LicitacijaModelDto>(oldLicitacija));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        /// <summary>
        /// Vreće opcije za rad sa licitacijama
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetLicitacijeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
