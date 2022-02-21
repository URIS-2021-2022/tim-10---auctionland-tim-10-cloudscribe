﻿using AutoMapper;
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

        /// <summary>
        /// Vraća sve katastarske opštine.
        /// </summary>
        /// <returns>Lista katastarskih opština</returns>
        /// <response code="200">Vraća listu katastarskih opština</response>
        /// <response code="404">Nije pronađena ni jedna katastarska opština</response>

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

        /// <summary>
        /// Vraća jednu katastarsku opštinu na osnovu ID-ja.
        /// </summary>
        /// <param name="katastarskaOpstinaId">ID katastarske opštine</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženu katastarsku opštinu</response>

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


        /// <summary>
        /// Kreira novu katastarsku opštinu.
        /// </summary>
        /// <param name="katastarskaOpstina">Model katastarske opštine</param>
        /// <returns>Potvrdu o kreiranoj katastarskoj opštini.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove katastarske opštine \
        /// POST /api/parcela \
        /// {     \
        ///        KatastarskaOpstinaId = Guid.Parse("1807A208-3BCA-49DE-A159-293E14393909"), \
        ///        ImeKatastarskeOpstine = Cantavir, \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranu katastarsku opštinu</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja katastarske opštine</response>

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


        /// <summary>
        /// Ažurira jednu katastarsku opštinu.
        /// </summary>
        /// <param name="katastarskaOpstina">Model kreiranja katastarske opštine koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj katastarskoj opštini.</returns>
        /// <response code="200">Vraća ažuriranu katastarsku opštinu</response>
        /// <response code="400">Katastarska opština koja se ažurira nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja katastarske opštine</response>

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


        /// <summary>
        /// Vrši brisanje jedne katastarske opštine na osnovu ID-ja.
        /// </summary>
        /// <param name="katastarskaOpstinaId">ID katastarske opštine</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Katastarska opština uspešno obrisana</response>
        /// <response code="404">Nije pronađena katastarska opština za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja katastarske opštine</response>

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


        /// <summary>
        /// Vraća opcije za rad sa katastarskim opštinama
        /// </summary>
        /// <returns></returns>


        [HttpOptions]
        [AllowAnonymous] //Dozvoljavamo pristup anonimnim korisnicima
        public IActionResult GetParcelaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
