using AutoMapper;
using DocumentService.Data.TipDokumenta;
using DocumentService.Entities.TipDokumentaEntity;
using DocumentService.Models;
using DocumentService.Models.TipDokumentaModel;
using DocumentService.ServiceCalls;
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
        
        [ApiController]
        [Route("api/tip_dokument")]
        [Produces("application/json", "application/xml")]
        //[Authorize]
    public class TipDokumentaController : ControllerBase
        {
            private readonly ITipDokumentaRepository tipdokumentaRepository;
            private readonly IMapper mapper;
            private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;

        public TipDokumentaController(ITipDokumentaRepository tipdokumentaRepository, IMapper mapper, LinkGenerator linkGenerator, ILoggerService loggerService)
            {
                this.tipdokumentaRepository = tipdokumentaRepository;
                this.mapper = mapper;
                this.linkGenerator = linkGenerator;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "Dokument";
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
                loggerDto.HttpMethod = "GET";

                var tipovi = tipdokumentaRepository.GetAllTip();
                if (tipovi == null || tipovi.Count == 0)
                {

                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return NotFound();
                }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);

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
                loggerDto.HttpMethod = "GET";
                var tip = tipdokumentaRepository.GetTipByID(tipID);
                if (tip == null)
                {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
                }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);

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
                loggerDto.HttpMethod = "POST";


                TipDokumentaE tipEntity = mapper.Map<TipDokumentaE>(tip);
                TipDokumentaConfirmation confirmation = tipdokumentaRepository.CreateTipDokumenta(tipEntity);
                tipdokumentaRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetAllTip", "Tip", new { tipId = confirmation.TipDokumentaID });

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<TipDokumentaConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
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

                    loggerDto.Level = "WARN";
                    return NotFound();
                    }
                    TipDokumentaE tipDokumentaEntity = mapper.Map<TipDokumentaE>(tip);
                    mapper.Map(tipDokumentaEntity, oldTip);
                    tipdokumentaRepository.SaveChanges();
                    return Ok(mapper.Map<TipDokumentaDto>(oldTip));
                }
                catch (Exception)
                {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
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
                    loggerDto.HttpMethod = "DELETE";
                    var tip = tipdokumentaRepository.GetTipByID(tipID);

                    if (tip == null)
                    {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                    }

                    tipdokumentaRepository.DeleteTipDokumenta(tipID);
                    tipdokumentaRepository.SaveChanges();

                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
                }
                catch (Exception)
                {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
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
                Response.Headers.Add("Allow", "GET, POST, PUT,DELETE");
                return Ok();
            }
        }
}

