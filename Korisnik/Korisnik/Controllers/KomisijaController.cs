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
{   [ApiController]
        [Route("api/komisija")]
        [Produces("application/json", "application/xml")] //Sve akcije kontrolera mogu da vraćaju definisane formate
    [Authorize(Roles = "Administrator, Prva komisija")]
    public class KomisijaController: ControllerBase
    {
        
        private readonly IKomisijaRepository komisijaRepository;
        private readonly LinkGenerator linkGenerator;

        private readonly IMapper mapper;
        public KomisijaController(IKomisijaRepository komisijaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.komisijaRepository = komisijaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
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
            List<Komisija> komisija = komisijaRepository.GetKomisija();
            if (komisija == null || komisija.Count == 0)
            {
                return NoContent();

            }
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
            Komisija komisijaModel = komisijaRepository.GetKomisijaById(komisijaId);
            if (komisijaModel == null)
            {
                return NotFound();
            }
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
                Komisija komisijaModel = komisijaRepository.GetKomisijaById(komisijaId);
                if (komisijaModel == null)
                {
                    return NotFound();
                }
                komisijaRepository.DeleteKomisija(komisijaId);
                komisijaRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
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
                
                Komisija komisija = mapper.Map<Komisija>(komisijaa);
                Komisija confirmation = komisijaRepository.CreateKomisija(komisija);
                string location = linkGenerator.GetPathByAction("GetKomisije", "Komisija", new { komisijaId = confirmation.KomisijaId });
                return Created(location, mapper.Map<Komisija>(confirmation));
            }
            catch(Exception e)
            {
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
                    return NotFound();
                }
                //  var korisnikEntity = mapper.Map<KorisnikUpdateDto>(oldKorisnik);
                mapper.Map(komisija, oldKomisija);
                komisijaRepository.SaveChanges();
                return Ok(mapper.Map<KomisijaDto>(oldKomisija));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");


            }


        }
    }
}
