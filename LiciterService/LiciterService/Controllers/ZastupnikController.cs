using AutoMapper;
using LiciterService.Data;
using LiciterService.Entities;
using LiciterService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/zastupnik")]

    public class ZastupnikController: ControllerBase
    {
        private readonly IZastupnikRepository zastupnikRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public ZastupnikController(IZastupnikRepository zastupnikRepository,IMapper mapper,LinkGenerator linkGenerator)
        {
            this.zastupnikRepository = zastupnikRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Vraca sve zastupnike
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraća zastupnike</response>
        /// <response code="500">Došlo je do greške na serveru</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ZastupnikDto>> GetZastupnici()
        {
            var zastupnici = zastupnikRepository.GetZastupnici();
            if (zastupnici == null || zastupnici.Count==0)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<ZastupnikDto>>(zastupnici));
        }
        /// <summary>
        /// Vracanje zastupnika po id-ju
        /// </summary>
        /// <param name="zastupnikId"></param>
        /// <returns></returns>
        /// <response code="200">Vraća zastupnika po id-ju</response>
        [HttpGet("{zastupnikId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ZastupnikDto> GetZastupnik(Guid zastupnikId)
        {
            var zastupnik = zastupnikRepository.GetZastupnikById(zastupnikId);
            if (zastupnik == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ZastupnikDto>(zastupnik));
        }

        /// <summary>
        /// Kreiranje zastupnika
        /// </summary>
        /// <param name="zastupnik"></param>
        /// <returns></returns>
        ///<response code="200">Vraća kreiranog zastupnika</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja zastupnika</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZastupnikConfirmationDto> CreateZastupnik([FromBody] ZastupnikCreationDto zastupnik)
        {
            try
            {
                Zastupnik zastupnikEntity = mapper.Map<Zastupnik>(zastupnik);
                ZastupnikConfirmation confirmation = zastupnikRepository.CreateZastupnik(zastupnikEntity);
                zastupnikRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetZastupnik", "Zastupnik", new { zastupnikId = confirmation.ZastupnikId });
                return Created(location, mapper.Map<ZastupnikConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

        }

        /// <summary>
        /// Azuriranje zastupnika
        /// </summary>
        /// <param name="zastupnik"></param>
        /// <returns></returns>
        /// <response code="400">Zastupnik koji se ažurira nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja zastupnika</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZastupnikConfirmationDto> UpdateZastupnik(ZastupnikUpdateDto zastupnik)
        {
            try
            {
                var oldZastupnik = zastupnikRepository.GetZastupnikById(zastupnik.ZastupnikId);
                if (oldZastupnik == null)
                {
                    return NotFound();
                }
                Zastupnik zastupnikEntity = mapper.Map<Zastupnik>(zastupnik);
                mapper.Map(zastupnikEntity, oldZastupnik);
                zastupnikRepository.SaveChanges();
                return Ok(mapper.Map<ZastupnikDto>(oldZastupnik));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
        /// <summary>
        /// Brisanje zastupnika
        /// </summary>
        /// <param name="zastupnikId"></param>
        /// <returns></returns>
        /// <response code="404">Nije pronađen zastupnik za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja zastupnika</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{zastupnikId}")]
        public IActionResult DeleteZastupnik(Guid zastupnikId)
        {
            try
            {
                var zastupnik = zastupnikRepository.GetZastupnikById(zastupnikId);

                if (zastupnik == null)
                {
                    return NotFound();
                }

                zastupnikRepository.DeleteZastupnik(zastupnikId);
                zastupnikRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Vraca opcije za rad sa zastupnicima
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetZastupnikOpctions()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT, DELETE");
            return Ok();
        }
    }
}
