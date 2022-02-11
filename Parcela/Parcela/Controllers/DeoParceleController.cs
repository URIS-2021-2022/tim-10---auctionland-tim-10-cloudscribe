using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Parcela.Data.DeoParcele;
using Parcela.Entities.DeoParcele;
using Parcela.Models.DeoParcele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Controllers
{
    [ApiController]
    [Route("api/deoparcele")]
    [Produces("application/json", "application/xml")]
    public class DeoParceleController : ControllerBase
    {
        private readonly IDeoParceleRepository deoParceleRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public DeoParceleController(IDeoParceleRepository deoRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.deoParceleRepository = deoRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DeoParceleDto>> GetDeoParcele()
        {
            var deoParcele = deoParceleRepository.GetDeoParcele();
            if(deoParcele == null || deoParcele.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<DeoParceleDto>>(deoParcele));
        }

        [HttpGet("{DeoParceleId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<DeoParceleDto> GetDeoParceleById(Guid deoParceleId)
        {
            var deoParcele = deoParceleRepository.GetDeoParceleById(deoParceleId);
            if (deoParcele == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DeoParceleDto>(deoParcele));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleConfirmationDto> CreateDeoParcele([FromBody] DeoParceleCreationDto deoParcele)
        {
            try
            {
                DeoParceleEntity deoParceleEntity = mapper.Map<DeoParceleEntity>(deoParcele);
                DeoParceleConfirmation confirmation = deoParceleRepository.CreateDeoParcele(deoParceleEntity);
                deoParceleRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetDeoParcele", "DeoParcele", new { deoParceleId = confirmation.DeoParceleId });

                return Created(location, mapper.Map<DeoParceleConfirmationDto>(confirmation));

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
        public ActionResult<DeoParceleConfirmationDto> UpdateDeoParcele(DeoParceleUpdateDto deoParcele)
        {
            try
            {
                var oldDeoParcele = deoParceleRepository.GetDeoParceleById(deoParcele.DeoParceleId);
                if(oldDeoParcele == null)
                {
                    return NotFound();
                }
                DeoParceleEntity deoParceleEntity = mapper.Map<DeoParceleEntity>(deoParcele);

                mapper.Map(deoParceleEntity, oldDeoParcele);

                deoParceleRepository.SaveChanges();
                return Ok(mapper.Map<DeoParceleDto>(oldDeoParcele));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        [HttpDelete("{DeoParceleId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteDeoParcele (Guid DeoParceleId)
        {
            try
            {
                var registration = deoParceleRepository.GetDeoParceleById(DeoParceleId);

                if(registration == null)
                {
                    return NotFound();
                }
                deoParceleRepository.DeleteDeoParcele(DeoParceleId);
                deoParceleRepository.SaveChanges();

                return Ok();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }


        [HttpOptions]
        [AllowAnonymous] //Dozvoljavamo pristup anonimnim korisnicima
        public IActionResult GetDeoParceleOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }

}
