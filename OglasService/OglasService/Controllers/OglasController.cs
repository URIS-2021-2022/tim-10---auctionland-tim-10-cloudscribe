using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OglasService.Data;
using OglasService.Entities;
using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Controllers
{
    [ApiController]
    [Route("api/oglas")]
    public class OglasController:ControllerBase
    {
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly IOglasRepository oglasRepository;

        public OglasController(IMapper mapper,LinkGenerator linkGenerator,IOglasRepository oglasRepository)
        {
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.oglasRepository = oglasRepository;
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
            var oglasi = oglasRepository.GetOglasi();
            if(oglasi==null || oglasi.Count == 0)
            {
                return NoContent();
            }
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
            var oglas = oglasRepository.GetOglasById(oglasId);
            if (oglas == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<OglasDto>(oglas));
        }

        /// <summary>
        /// Kreiranje oglasa
        /// </summary>
        /// <param name="oglas"></param>
        /// <returns></returns>
        /// <response code="200">Vraća kreirani oglas</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja oglasa</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OglasConfirmationDto> CreateOglas([FromBody] OglasCreationDto oglas)
        {
            try
            {
                Oglas oglasEntity = mapper.Map<Oglas>(oglas);
                OglasConfirmation confirmation = oglasRepository.CreateOglas(oglasEntity);
                oglasRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetOglas", "Oglas", new { oglasId = confirmation.OglasId });
                return Created(location, mapper.Map<OglasConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        /// <summary>
        /// Azuriranje oglasa
        /// </summary>
        /// <param name="oglas"></param>
        /// <returns></returns>
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
                    return NotFound();
                }
                Oglas oglasEntity = mapper.Map<Oglas>(oglas);
                mapper.Map(oglasEntity, oldOglas);
                oglasRepository.SaveChanges();
                return Ok(mapper.Map<OglasConfirmationDto>(oldOglas));
            }
            catch (Exception)
            {
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
                var oglas = oglasRepository.GetOglasById(oglasId);

                if (oglas == null)
                {
                    return NotFound();
                }

                oglasRepository.DeleteOglas(oglasId);
                return NoContent();
            }
            catch (Exception)
            {
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
