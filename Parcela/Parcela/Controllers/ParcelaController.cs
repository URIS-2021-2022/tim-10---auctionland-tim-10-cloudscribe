using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Parcela.Data.Parcela;
using Parcela.Entities;
using Parcela.Entities.Parcela;
using Parcela.Models;
using Parcela.Models.Parcela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Parcela.Controllers
{
    [ApiController]
    [Route("api/parcela")]
    [Produces("application/json", "application/xml")]
    [Authorize]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaRepository parcelaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        //private readonly IHttpContextAccessor httpContextAccessor;


        public ParcelaController(IParcelaRepository parcelaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.parcelaRepository = parcelaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            //this.httpContextAccessor = httpContextAccessor;

        }

        /// <summary>
        /// Vraća sve parcele.
        /// </summary>
        /// <returns>Lista prijava ispita</returns>
        /// <response code="200">Vraća listu parcela</response>
        /// <response code="404">Nije pronađena ni jedna parcela</response>

        [HttpGet]
        [HttpHead]   
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ParcelaDto>> GetParcele()
        {

            //var identityClaims = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;
            var parcele = parcelaRepository.GetParcela();
            if(parcele == null || parcele.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<ParcelaDto>>(parcele));
        }

        [HttpGet("{parcelaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ParcelaDto> GetParcela(Guid parcelaId)
        {
            var parcela = parcelaRepository.GetParcelaById(parcelaId);

            if(parcela == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ParcelaDto>(parcela));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaConfirmationDto> CreateParcela([FromBody] ParcelaCreationDto parcela)
        {
            try
            {
                ParcelaEntity parcelaEntity = mapper.Map<ParcelaEntity>(parcela);
                ParcelaConfirmation confirmation = parcelaRepository.CreateParcela(parcelaEntity);
                parcelaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetParcela", "Parcela", new { parcelaId = confirmation.ParcelaId });

                return Created(location, mapper.Map<ParcelaConfirmationDto>(confirmation));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }


        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaConfirmationDto> UpdateParcela(ParcelaUpdateDto parcela)
        {
            try
            {
                var oldParcela = parcelaRepository.GetParcelaById(parcela.ParcelaId);
                if(oldParcela == null)
                {
                    return NotFound();
                }
                ParcelaEntity parcelaEntity = mapper.Map<ParcelaEntity>(parcela);

                mapper.Map(parcelaEntity, oldParcela);

                parcelaRepository.SaveChanges();
                return Ok(mapper.Map<ParcelaDto>(oldParcela));
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }




        [HttpDelete("{parcelaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteParcela (Guid parcelaId)
        {
            try
            {
                var registration = parcelaRepository.GetParcelaById(parcelaId);

                if(registration == null)
                {
                    return NotFound();
                }

                parcelaRepository.DeleteParcela(parcelaId);
                parcelaRepository.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        [HttpOptions]
        [AllowAnonymous] //Dozvoljavamo pristup anonimnim korisnicima
        public IActionResult GetParcelaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
