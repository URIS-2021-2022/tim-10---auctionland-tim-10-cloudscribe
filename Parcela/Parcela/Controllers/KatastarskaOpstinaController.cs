using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Parcela.Data.KatastarskaOpstina;
using Parcela.Entities.KatastarskaOpstina;
using Parcela.Models.KatastarskaOpstina;
using Parcela.Modelsc.KatastarskaOpstina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Controllers
{
    [ApiController]
    [Route("api/opstina")]
    [Produces("application/json", "application/xml")]
    [Authorize]
    public class KatastarskaOpstinaController :ControllerBase
    {
        private readonly IKatastarskaOpstinaRepository opstinaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public KatastarskaOpstinaController(IKatastarskaOpstinaRepository opstinaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.opstinaRepository = opstinaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KatastarskaOpstinaDto>> GetKatastarskaOpstina()
        {
            var opstina = opstinaRepository.GetKatastarskaOpstina();
            if(opstina == null ||opstina.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<KatastarskaOpstinaDto>>(opstina));
        }

        [HttpGet("{katastarskaOpstinaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<KatastarskaOpstinaDto> GetKatastarskaOpstinaById(Guid katastarskaOpstinaId)
        {
            var opstina = opstinaRepository.GetKatastarskaOpstinaById(katastarskaOpstinaId);
            if(opstina == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<KatastarskaOpstinaDto>(opstina));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KatastarskaOpstinaConfirmationDto> CreateKatastarskaOpstina([FromBody] KatastarskaOpstinaCreationDto katastarskaOpstina)
        {
            try
            {
                KatastarskaOpstinaEntity opstina = mapper.Map<KatastarskaOpstinaEntity>(katastarskaOpstina);
                KatastarskaOpstinaConfirmation confirmation = opstinaRepository.CreateKatastarskaOpstina(opstina);
                opstinaRepository.SaveChanges();

                

                string location = linkGenerator.GetPathByAction("GetKatastarskaOpstina", "KatastarskaOpstina", new { katastarskaOpstinaId = confirmation.KatastarskaOpstinaId });

                return Created(location, mapper.Map<KatastarskaOpstinaConfirmationDto>(confirmation));
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
        public ActionResult<KatastarskaOpstinaDto> UpdateKatastarskaOpstina(KatastarskaOpstinaDto katastarskaOpstina)
        {
            try
            {
                var oldOpstina = opstinaRepository.GetKatastarskaOpstinaById(katastarskaOpstina.KatastarskaOpstinaId);
                if(oldOpstina == null)
                {
                    return NotFound();
                }

                KatastarskaOpstinaEntity katastarskaOpstinaEntity = mapper.Map<KatastarskaOpstinaEntity>(katastarskaOpstina);
                mapper.Map(katastarskaOpstinaEntity, oldOpstina);

                opstinaRepository.SaveChanges();
                return Ok(mapper.Map<KatastarskaOpstinaDto>(oldOpstina));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        [HttpDelete("{katastarskaOpstinaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteKatastarskaOpstina(Guid katastarskaOpstinaId)
        {
            try
            {
                var registration = opstinaRepository.GetKatastarskaOpstinaById(katastarskaOpstinaId);
                if(registration == null)
                {
                    return NotFound();
                }
                opstinaRepository.DeleteKatastarskaOpstina(katastarskaOpstinaId);
                opstinaRepository.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
    }
}
