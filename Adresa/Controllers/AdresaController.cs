using Adresa.Data;
using Adresa.Entities;
using Adresa.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Controllers
{
    [ApiController]
    [Route("api/adrese")]
    //[Authorize]
    [Produces("application/json", "applciation/xml")]
    public class AdresaController : ControllerBase
    {
        private readonly IAdresaRepository adresaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public AdresaController(IAdresaRepository adresaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.adresaRepository = adresaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        /// <summary>
        /// Vraća sve adrese
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<AdresaDto>> GetAdrese()
        {
            var adrese = adresaRepository.GetAdrese();
            if(adrese == null || adrese.Count == 0)
            {
                return NoContent();
            }
                return Ok(mapper.Map<List<AdresaDto>>(adrese));
                 
        }

        /// <summary>
        /// Vraća adresu na osnovu ID-ja prijave
        /// </summary>
        /// <param name="adresaId">ID adrese</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{adresaId}")]
        public ActionResult<AdresaDto> GetAdresa(Guid adresaId)
        {
            var adresa = adresaRepository.GetAdresaById(adresaId);

            if(adresa == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AdresaDto>(adresa));
        }

        /// <summary>
        /// Kreira novu adresu
        /// </summary>
        /// <param name="adresa">Model adrese</param>
        /// <remarks>
        /// Primer zahteva za kreiranje nove adrese\
        /// POST /api/adresa \
        /// {   \
        ///     "ulica": "Ulica3",
        ///     "broj": "3",
        ///     "mesto": "Mesto3",
        ///     "postanskiBroj": 12345,
        ///     "drzavaId": "2109d328-5014-40c1-9e1e-1a08b3f67192"
        ///}
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<AdresaConfirmationDto> CreateAdresa([FromBody] AdresaCreationDto adresa) 
        {
            try
            {
                AdresaEntity adresaEntity = mapper.Map<AdresaEntity>(adresa);
                AdresaConfirmationEntity confirmation = adresaRepository.CreateAdresa(adresaEntity);
                adresaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetAdresa", "Adresa", new { AdresaId = confirmation.AdresaId });
                return Created(location, mapper.Map<AdresaConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");

            }
        }

        /// <summary>
        /// Ažurira postojeću adresu
        /// </summary>
        /// <param name="adresa">Model adrese</param>
        /// <remarks>
        /// Primer zahteva za ažuriranje postojeće adrese\
        /// POST /api/adresa \
        /// {   \
        ///     "adresaId" : "6a411c13-a195-48f7-8dbd-67596c3974c0",
        ///     "ulica": "Ulica1",
        ///     "broj": "10",
        ///     "mesto": "Mesto10",
        ///     "postanskiBroj": 123,
        ///     "drzavaId": "170960f3-f8e0-4614-aff2-653aadf5c720"
        ///}
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPut]
        public ActionResult<AdresaDto> UpdateAdresa([FromBody] AdresaUpdateDto adresa)
        {
            try
            {
                var oldAdresa = adresaRepository.GetAdresaById(adresa.AdresaId);
                
                if (oldAdresa == null)
                {
                    return NotFound();
                }

                AdresaEntity adresaEntity = mapper.Map<AdresaEntity>(adresa);

                mapper.Map(adresaEntity, oldAdresa);

                adresaRepository.SaveChanges();
                
                return Ok(mapper.Map<AdresaDto>(oldAdresa));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");

            }
        }

        /// <summary>
        /// Vrši brisanje jedne adrese na osnovu ID-ja
        /// </summary>
        /// <param name="adresaId">ID adrese</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{adresaId}")]
        public IActionResult DeleteAdresa(Guid adresaId)
        {
            try
            {
                var adresa = adresaRepository.GetAdresaById(adresaId);

                if(adresa == null)
                {
                    return NotFound();
                }
                adresaRepository.DeleteAdresa(adresaId);
                adresaRepository.SaveChanges();
                return NoContent();

            } catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Vreće opcije za rad sa adresama
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpOptions]
        public IActionResult GetAdresaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
