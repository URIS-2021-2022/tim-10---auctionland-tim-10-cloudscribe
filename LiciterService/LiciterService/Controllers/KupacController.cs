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
    [Route("api/kupac")]

    public class KupacController : ControllerBase
    {
        
        private readonly IKupacRepository kupacRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        
        public KupacController(IMapper mapper,LinkGenerator linkGenerator, IKupacRepository kupacRepository)
        {
           
            this.kupacRepository = kupacRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        

        }

        /// <summary>
        /// Vraca sve kupce
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraća kupce</response>
        /// <response code="500">Došlo je do greške na serveru</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KupacDto>> GetKupci()
        {
            var kupci = kupacRepository.GetKupci();
            if(kupci==null || kupci.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<KupacDto>>(kupci));
        }

       /// <summary>
       /// Vraca kupce po id-ju
       /// </summary>
       /// <param name="kupacId"></param>
       /// <returns></returns>
        [HttpGet("{kupacId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<KupacDto> GetKupac(Guid kupacId)
        {
           var kupac = kupacRepository.GetKupacById(kupacId);
            if(kupac == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<KupacDto>(kupac));
        }

        /// <summary>
        /// Kreiranje kupca
        /// </summary>
        /// <param name="kupac">Model kupca</param>
        /// <returns></returns>
        ///<response code="200">Vraća kreiranog kupca</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja kupca</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacConfirmationDto> CreateKupac([FromBody] KupacCreationDto kupac)
        {
            try
            {
                Kupac kupacEntity = mapper.Map<Kupac>(kupac);
                KupacConfirmation confirmation = kupacRepository.CreateKupac(kupacEntity);
                kupacRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetKupac", "Kupac", new { kupacId = confirmation.KupacId });
                return Created(location, mapper.Map<KupacConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
            
        }

        /// <summary>
        /// Azuriranje kupca
        /// </summary>
        /// <param name="kupac">Model kupca</param>
        /// <returns></returns>
        ///<response code="200">Vraća ažuriranog kupca</response>
        /// <response code="400">Kupac koja se ažurira nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kupca</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacConfirmationDto> UpdateKupac(KupacUpdateDto kupac)
        {
            
            try
            {
                var oldKupac = kupacRepository.GetKupacById(kupac.KupacId);
                if (oldKupac == null)
                {
                    return NotFound();
                }
                Kupac kupacEntity = mapper.Map<Kupac>(kupac);
                mapper.Map(kupacEntity, oldKupac);
                kupacRepository.SaveChanges();
                return Ok(mapper.Map<KupacDto>(oldKupac));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        /// <summary>
        /// Brisanje kupca
        /// </summary>
        /// <param name="kupacId">ID kupca</param>
        /// <returns></returns>
        /// <response code="204">Kupac uspešno obrisan</response>
        /// <response code="404">Nije pronađen kupac za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja kupca</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{kupacId}")]
        public IActionResult DeleteKupac(Guid kupacId)
        {
            try
            {
                var kupac = kupacRepository.GetKupacById(kupacId);

                if (kupac == null)
                {
                    return NotFound();
                }

                kupacRepository.DeleteKupac(kupacId);
                kupacRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Vraca opcije za rad sa kupcima
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
