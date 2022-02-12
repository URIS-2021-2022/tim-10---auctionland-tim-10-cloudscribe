using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Parcela.Data.ZasticenaZona;
using Parcela.Entities.ZasticenaZona;
using Parcela.Models;
using Parcela.Models.ZasticenaZona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Controllers
{
    [ApiController]
    [Route("api/zasticenazona")]
    [Produces("application/json", "application/xml")]
    public class ZasticenaZonaController : ControllerBase
    {
        private readonly IZasticenaZonaRepository zasticenaZonaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public ZasticenaZonaController(IZasticenaZonaRepository zasticenaZonaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.zasticenaZonaRepository = zasticenaZonaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ZasticenZonaDto>> GetZasticenaZona()
        {
            var zasticenaZona = zasticenaZonaRepository.GetZasticenaZona();
            if(zasticenaZona == null ||zasticenaZona.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<ZasticenZonaDto>>(zasticenaZona));
        }

        [HttpGet("{ZasticenZonaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ZasticenZonaDto> GetZasticenaZonaById(Guid ZasticenZonaId)
        {
            var zasticenZona = zasticenaZonaRepository.GetZasticenaZonaById(ZasticenZonaId);
            if (zasticenZona == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ZasticenZonaDto>(zasticenZona));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZasticenZonaConfirmationDto> CreateZasticenaZona([FromBody] ZasticenaZonaCreationDto zasticenaZona)
        {
            try
            {
                ZasticenaZonaEntity zasticenaZonaEntity = mapper.Map<ZasticenaZonaEntity>(zasticenaZona);
                ZasticenaZonaConfirmation confirmation = zasticenaZonaRepository.CreateZasticenaZona(zasticenaZonaEntity);
                zasticenaZonaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetZasticenaZona", "ZasticenaZona", new { zasticenZonaId = confirmation.ZasticenZonaId });

                return Created(location, mapper.Map<ZasticenZonaConfirmationDto>(confirmation));
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
        public ActionResult<ZasticenZonaDto> UpdateZasticenaZona(ZasticenZonaDto zasticenaZona)
        {
            try
            {
                var oldZasticenaZona = zasticenaZonaRepository.GetZasticenaZonaById(zasticenaZona.ZasticenZonaId);
                if(oldZasticenaZona == null)
                {
                    return NotFound();
                }

                ZasticenaZonaEntity zasticenaZonaEntity = mapper.Map<ZasticenaZonaEntity>(zasticenaZona);

                mapper.Map(zasticenaZonaEntity, oldZasticenaZona);

                zasticenaZonaRepository.SaveChanges();
                return Ok(mapper.Map<ZasticenZonaDto>(oldZasticenaZona));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        [HttpDelete("{ZasticenZonaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteZasticenaZona(Guid ZasticenZonaId)
        {
            try
            {
                var registration = zasticenaZonaRepository.GetZasticenaZonaById(ZasticenZonaId);
                if(registration == null)
                {
                    return NotFound();
                }

                zasticenaZonaRepository.DeleteZasticenaZona(ZasticenZonaId);
                zasticenaZonaRepository.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }



        [HttpOptions]
        [AllowAnonymous] //Dozvoljavamo pristup anonimnim korisnicima
        public IActionResult GetZasticenaZonaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
