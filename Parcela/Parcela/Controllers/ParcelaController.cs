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
using Parcela.ServiceCalls;
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
    //[Authorize]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaRepository parcelaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;

        //private readonly IHttpContextAccessor httpContextAccessor;


        public ParcelaController(IParcelaRepository parcelaRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.parcelaRepository = parcelaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            //this.httpContextAccessor = httpContextAccessor;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "PARCELA";
        }

        /// <summary>
        /// Vraća sve parcele.
        /// </summary>
        /// <returns>Lista parcela</returns>
        /// <response code="200">Vraća listu parcela</response>
        /// <response code="404">Nije pronađena ni jedna parcela</response>

        [HttpGet]
        [HttpHead]   
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ParcelaDto>> GetParcele()
        {
            loggerDto.HttpMethod = "GET";
            //var identityClaims = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;
            var parcele = parcelaRepository.GetParcela();
            if(parcele == null || parcele.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);

            return Ok(mapper.Map<List<ParcelaDto>>(parcele));
        }


        /// <summary>
        /// Vraća jednu parcelu na osnovu ID-ja.
        /// </summary>
        /// <param name="parcelaId">ID parcele</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženu parcelu</response>

        [HttpGet("{parcelaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ParcelaDto> GetParcela(Guid parcelaId)
        {
            loggerDto.HttpMethod = "GET";
            var parcela = parcelaRepository.GetParcelaById(parcelaId);

            if(parcela == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<ParcelaDto>(parcela));
        }

        /// <summary>
        /// Kreira novu parcelu.
        /// </summary>
        /// <param name="parcela">Model parcelee</param>
        /// <returns>Potvrdu o kreiranoj parceli.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove parcele \
        /// POST /api/parcela \
        /// {     \
        ///        Povrsina = 100, \
        ///        KorisnikId = Guid.Parse("6a411c13-a295-48f7-8dbd-67596c3974c0"), \
        ///        BrojParcele = "1", \
        ///        KatastarskaOpstinaId = Guid.Parse("1807A208-3BCA-49DE-A159-293E14393909"), \
        ///        BrojListaNepokretnosti = "5", \
        ///        Kultura = "Njive", \
        ///        Klasa = 1, \
        ///        Obradivost = "Obradivo", \
        ///        ZasticenaZonaId = Guid.Parse("AF2D6F85-D341-4433-8F21-3F28F816A79E"), \
        ///        OblikSvojine = "Drzavno", \
        ///        Odvodnjavanje = "Podvnodno" \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranu parcelu</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja parcele</response>


        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaConfirmationDto> CreateParcela([FromBody] ParcelaCreationDto parcela)
        {
            try
            {
                loggerDto.HttpMethod = "POST";
                ParcelaEntity parcelaEntity = mapper.Map<ParcelaEntity>(parcela);
                ParcelaConfirmation confirmation = parcelaRepository.CreateParcela(parcelaEntity);
                parcelaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetParcela", "Parcela", new { parcelaId = confirmation.ParcelaId });
                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<ParcelaConfirmationDto>(confirmation));

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
        /// Ažurira jednu parcelu.
        /// </summary>
        /// <param name="parcela">Model kreiranja parcele koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj parceli.</returns>
        /// <response code="200">Vraća ažuriranu parcelu</response>
        /// <response code="400">Parcela koja se ažurira nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja parcele</response>

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
                    loggerDto.Level = "WARN";
                    return NotFound();
                }
                //ParcelaEntity parcelaEntity = mapper.Map<ParcelaEntity>(parcela);

                mapper.Map(parcela, oldParcela);

                parcelaRepository.SaveChanges();
                return Ok(mapper.Map<ParcelaDto>(oldParcela));
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
        /// Vrši brisanje jedne parcele na osnovu ID-ja.
        /// </summary>
        /// <param name="parcelaId">ID parcele</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Parcela uspešno obrisana</response>
        /// <response code="404">Nije pronađena parcela za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja parcele</response>


        [HttpDelete("{parcelaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteParcela (Guid parcelaId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var registration = parcelaRepository.GetParcelaById(parcelaId);

                if(registration == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                parcelaRepository.DeleteParcela(parcelaId);
                parcelaRepository.SaveChanges();
                loggerDto.Response = "200 OK";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }


        /// <summary>
        /// Vraća opcije za rad sa parcelama
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
