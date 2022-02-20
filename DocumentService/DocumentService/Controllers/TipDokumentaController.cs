using AutoMapper;
using DocumentService.Data.TipDokumenta;
using DocumentService.Entities.TipDokumentaEntity;
using DocumentService.Models.TipDokumentaModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Controllers
{
        //[Authorize]
        [ApiController]
        [Route("api/tip_dokument")]
        [Produces("application/json", "application/xml")]
        public class TipDokumentaController : ControllerBase
        {
            private readonly ITipDokumentaRepository tipdokumentaRepository;
            private readonly IMapper mapper;
            private readonly LinkGenerator linkGenerator;

            public TipDokumentaController(ITipDokumentaRepository tipdokumentaRepository, IMapper mapper, LinkGenerator linkGenerator)
            {
                this.tipdokumentaRepository = tipdokumentaRepository;
                this.mapper = mapper;
                this.linkGenerator = linkGenerator;
            }

            //Vraca sve tipove
            /// <response code="200">Vraća dokumente</response>
            /// <response code="500">Došlo je do greške na serveru</response>
            /// 
            [HttpGet]
            [HttpHead]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public ActionResult<List<TipDokumentaDto>> GetAllTip()
            {
                var tipovi = tipdokumentaRepository.GetAllTip();
                if (tipovi == null || tipovi.Count == 0)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<List<TipDokumentaDto>>(tipovi));
            }
            /// <summary>
            /// Vracanje tipova po id-ju
            /// </summary>
            /// <param name="tipID"></param>
            /// <returns></returns>
            /// <response code="200">Vraća dokument po id-ju</response>
            [HttpGet("{tipID}")]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public ActionResult<TipDokumentaDto> GetTipByID(Guid tipID)
            {
                var tip = tipdokumentaRepository.GetTipByID(tipID);
                if (tip == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<TipDokumentaDto>(tip));
            }


        /// <summary>
        /// Kreiranje tipa
        /// </summary>
        /// <param name="tip">Model tipa</param>
        /// <returns></returns>
        ///<response code="200">Vraća kreirani tip</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja tipa</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipDokumentaConfirmationDto> CreateTipDokumenta([FromBody] TipDokumentaCreationDto tip)
        {
            try
            {
                TipDokumentaE tipEntity = mapper.Map<TipDokumentaE>(tip);
                TipDokumentaConfirmation confirmation = tipdokumentaRepository.CreateTipDokumenta(tipEntity);
                tipdokumentaRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetAllTip", "Tip", new { tipId = confirmation.TipDokumentaID });
                return Created(location, mapper.Map<TipDokumentaConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

        }


        /// <summary>
        /// Azuriranje tipa
        /// </summary>
        /// <param name="tip"></param>
        /// <returns></returns>
        /// <response code="400">Dokument koji se ažurira nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja dokumenta</response>
        [HttpPut]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public ActionResult<TipDokumentaConfirmationDto> UpdateTipDokumenta(TipDokumentaUpdateDto tip)
            {
                try
                {
                var oldTip = tipdokumentaRepository.GetTipByID(tip.TipDokumentaID);
                    if (oldTip == null)
                    {
                        return NotFound();
                    }
                    TipDokumentaE tipDokumentaEntity = mapper.Map<TipDokumentaE>(tip);
                    mapper.Map(tipDokumentaEntity, oldTip);
                    tipdokumentaRepository.SaveChanges();
                    return Ok(mapper.Map<TipDokumentaConfirmationDto>(oldTip));
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
                }
            }

            /// <summary>
            /// Brisanje tipa
            /// </summary>
            /// <param name="tipID"></param>
            /// <returns></returns>
            /// <response code="404">Nije pronađen dokument za brisanje</response>
            /// <response code="500">Došlo je do greške na serveru prilikom brisanja dokumenta</response>
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [HttpDelete("{tipID}")]
            public IActionResult DeleteTipDokumenta(Guid tipID)
            {
                try
                {
                    var tip = tipdokumentaRepository.GetTipByID(tipID);

                    if (tip == null)
                    {
                        return NotFound();
                    }

                    tipdokumentaRepository.DeleteTipDokumenta(tipID);
                    tipdokumentaRepository.SaveChanges();
                    return NoContent();
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
                }
            }

            /// <summary>
            /// Vraca opcije za rad sa tipovima
            /// </summary>
            /// <returns></returns>
            [HttpOptions]
            [AllowAnonymous]
            public IActionResult GetTipDokumentaOptions()
            {
                Response.Headers.Add("Allow", "GET, PUT,DELETE");
                return Ok();
            }
        }
}

