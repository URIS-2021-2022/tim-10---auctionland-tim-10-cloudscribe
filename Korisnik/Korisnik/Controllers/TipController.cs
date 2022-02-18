using AutoMapper;
using Korisnik.Data;
using Korisnik.Entities;
using Korisnik.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Controllers
{
    [ApiController]
    [Route("api/tip")]
    [Produces("application/json", "application/xml")] //Sve akcije kontrolera mogu da vraćaju definisane formate
    [Authorize(Roles = "Administrator")]
    public class TipController : ControllerBase
    {
        private readonly ITipRepository tipRepository;
        private readonly LinkGenerator linkGenerator;

        private readonly IMapper mapper;
        public TipController(ITipRepository tipRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.tipRepository = tipRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve tipove
        /// </summary>

        /// <returns>Lista tipova</returns>
        /// <response code="200">Vraća listu tipova</response>
        /// <response code="404">Nije pronan ni jedan tip</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)] //Eksplicitno definišemo šta sve može ova akcija da vrati
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<TipDto>> GetTipovi()
        {
            List<Tip> tipovi = tipRepository.GetTip();
            if (tipovi == null || tipovi.Count == 0)
            {
                return NoContent();

            }
            return Ok(mapper.Map<List<TipDto>>(tipovi));
        }

        /// <summary>
        /// Vraća jednog tipa na osnovu njegovog ID-ja
        /// </summary>
        /// <param name="tipId">ID tipa</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženi tip</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet("{tipId}")]
        public ActionResult<TipDto> GetTip(Guid tipId)
        {
            Tip tipModel = tipRepository.GetTipById(tipId);
            if (tipModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TipDto>(tipModel));
        }

        /// <summary>
        /// Kreira novog korisnika
        /// </summary>
        /// <param name="tipp">Model tipa</param>
        /// <returns>Potvrdu o kreiranom tipu korisnika </returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog tipa korisnika \
        /// POST /api/ExamRegistration \
        /// {     \
        ///     "TipId": "2841defc-761e-40d8-b8a3-d3e58516dca7", \
        ///     "TipKorisnika": "Administrator", \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreirani tip</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja tipa</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipDto> CreateTip([FromBody] TipDto tipp)
        {
            try
            {
                Tip tip = mapper.Map<Tip>(tipp);
                Tip conf = tipRepository.CreateTip(tip);
                string location = linkGenerator.GetPathByAction("GetTip", "Tip", new { tipId = conf.TipId });
                return Created(location, mapper.Map<Tip>(conf));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");

            }

        }
    }


}
