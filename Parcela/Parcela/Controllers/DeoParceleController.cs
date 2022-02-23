using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Parcela.Data.DeoParcele;
using Parcela.Entities.DeoParcele;
using Parcela.Models;
using Parcela.Models.DeoParcele;
using Parcela.ServiceCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Controllers
{
    [ApiController]
    [Route("api/deoparcele")]
    [Produces("application/json", "application/xml")]
    [Authorize]
    public class DeoParceleController : ControllerBase
    {
        private readonly IDeoParceleRepository deoParceleRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;

        public DeoParceleController(IDeoParceleRepository deoRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.deoParceleRepository = deoRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "DEO PARCELE";
        }


        /// <summary>
        /// Vraća sve delove parcele.
        /// </summary>
        /// <returns>Lista parcela</returns>
        /// <response code="200">Vraća listu delova parcela</response>
        /// <response code="404">Nije pronađena ni jedan deo parcela</response>

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DeoParceleDto>> GetDeoParcele()
        {
            loggerDto.HttpMethod = "GET";
            var deoParcele = deoParceleRepository.GetDeoParcele();
            if(deoParcele == null || deoParcele.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<DeoParceleDto>>(deoParcele));
        }

        /// <summary>
        /// Vraća jedan deo parcele na osnovu ID-ja.
        /// </summary>
        /// <param name="deoParceleId">ID dela parcele</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženi deo parcele</response>

        [HttpGet("{DeoParceleId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<DeoParceleDto> GetDeoParceleById(Guid deoParceleId)
        {
            loggerDto.HttpMethod = "GET";
            var deoParcele = deoParceleRepository.GetDeoParceleById(deoParceleId);
            if (deoParcele == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<DeoParceleDto>(deoParcele));
        }

        /// <summary>
        /// Kreira novi deo parcele.
        /// </summary>
        /// <param name="deoParcele">Model dela parcele</param>
        /// <returns>Potvrdu o kreiranom delu parcele.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog dela parcele \
        /// POST /api/parcela \
        /// {     \
        ///            DeoParceleId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"), \
        ///            ParcelaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"), \
        ///            Povrsina = 100, \
        ///            RedniBroj = 1, \
        ///            Dodeljena = false \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreirani deo parcele</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja dela parcele</response>


        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleConfirmationDto> CreateDeoParcele([FromBody] DeoParceleCreationDto deoParcele)
        {
            try
            {
                loggerDto.HttpMethod = "POST";
                DeoParceleEntity deoParceleEntity = mapper.Map<DeoParceleEntity>(deoParcele);
                DeoParceleConfirmation confirmation = deoParceleRepository.CreateDeoParcele(deoParceleEntity);
                deoParceleRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetDeoParcele", "DeoParcele", new { deoParceleId = confirmation.DeoParceleId });
                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<DeoParceleConfirmationDto>(confirmation));

            }
            catch
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }


        /// <summary>
        /// Ažurira deo jedne parcele.
        /// </summary>
        /// <param name="deoParcele">Model kreiranja dela parcele koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom delu parcele.</returns>
        /// <response code="200">Vraća ažurirani deo parcelu</response>
        /// <response code="400">Deo parcele koji se ažurira nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja dela parcele</response>

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleDto> UpdateDeoParcele(DeoParceleUpdateDto deoParcele)
        {
            try
            {
                var oldDeoParcele = deoParceleRepository.GetDeoParceleById(deoParcele.DeoParceleId);
                if(oldDeoParcele == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }
                

                mapper.Map(deoParcele, oldDeoParcele);

                deoParceleRepository.SaveChanges();
                return Ok(mapper.Map<DeoParceleDto>(oldDeoParcele));
            }
            catch
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }


        /// <summary>
        /// Vrši brisanje dela jedne parcele na osnovu ID-ja.
        /// </summary>
        /// <param name="DeoParceleId">ID dela parcele</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Deo parcele uspešno obrisan</response>
        /// <response code="404">Nije pronađen deo parcele za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja dela parcele</response>

        [HttpDelete("{DeoParceleId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteDeoParcele (Guid DeoParceleId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var registration = deoParceleRepository.GetDeoParceleById(DeoParceleId);

                if(registration == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }
                deoParceleRepository.DeleteDeoParcele(DeoParceleId);
                deoParceleRepository.SaveChanges();

                return Ok();
            }
            catch(Exception)
            {
                loggerDto.Response = "200 OK";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa delovima parcela
        /// </summary>
        /// <returns></returns>


        [HttpOptions]
        [AllowAnonymous] //Dozvoljavamo pristup anonimnim korisnicima
        public IActionResult GetDeoParceleOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }

}
