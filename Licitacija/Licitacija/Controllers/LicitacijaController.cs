using AutoMapper;
using Licitacija.Data;
using Licitacija.Entities;
using Licitacija.Models;
using Licitacija.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Controllers
{
    [ApiController]
    [Route("api/licitacije")]
    [Produces("application/json", "applciation/xml")]
    [Authorize]
    public class LicitacijaController : ControllerBase
    {
        private readonly ILicitacijaRepository licitacijaRepository;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public LicitacijaController(ILicitacijaRepository licitacijaRepository, ILoggerService loggerService, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.licitacijaRepository = licitacijaRepository;
            this.loggerService = loggerService;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "LICITACIJA";
        }

        /// <summary>
        /// Vraća sve licitacije
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<LicitacijaModelDto>> GetAllLicitacije()
        {
            loggerDto.HttpMethod = "GET";
            var licitacije = licitacijaRepository.GetAllLicitacije();
            if (licitacije == null || licitacije.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<LicitacijaModelDto>>(licitacije));
        }

        /// <summary>
        /// Vraća licitaciju na osnovu ID-ja licitacije
        /// </summary>
        /// <param name="licitacijaId">ID lica</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{licitacijaId}")]
        public ActionResult<LicitacijaModelDto> GetLicitacija(Guid licitacijaId)
        {
            loggerDto.HttpMethod = "GET";
            var licitacijaModel = licitacijaRepository.GetLicitacijaById(licitacijaId);
            if (licitacijaModel == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<LicitacijaModelDto>(licitacijaModel));
        }

        /// <summary>
        /// Dodaje novu licitaciju
        /// </summary>
        /// <param name="licitacija">Model licitacije</param>
        /// /// <remarks>
        /// Primer zahteva za kreiranje nove licitacije\
        /// POST /api/licitacija \
        /// {   \
        /// "brojLicitacije" : 3,
        /// "godinaLicitacije" : 2021,
        /// "datumRaspisivanja" : "2021-06-01T09:00:00",
        /// "ogranicenje" : 0,
        /// "krugLicitacije" : 1,
        /// "rokZaPrijave" : "2021-07-01T23:59:00"
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<LicitacijaConfirmationDto> CreateLicitacija([FromBody] LicitacijaCreateDto licitacija)
        {
            try
            {
                loggerDto.HttpMethod = "POST";
                LicitacijaModel licitacijaModel = mapper.Map<LicitacijaModel>(licitacija);

                LicitacijaConfirmation confirmation = licitacijaRepository.CreateLicitacija(licitacijaModel);

                licitacijaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetLicitacija", "Licitacija", new { licitacijaId = confirmation.licitacijaId });
                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<LicitacijaConfirmationDto>(confirmation));

            }
            catch
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        /// <summary>
        /// Vrši brisanje jedne licitacije na osnovu ID-ja
        /// </summary>
        /// <param name="licitacijaId">ID licitacije</param>
        /// <returns></returns>
        [HttpDelete("{licitacijaId}")]
        public IActionResult DeleteLicitacija(Guid licitacijaId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var licitacijaModel = licitacijaRepository.GetLicitacijaById(licitacijaId);
                if (licitacijaModel == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }
                licitacijaRepository.DeleteLicitacija(licitacijaId);
                licitacijaRepository.SaveChanges();
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        /// <summary>
        /// Ažurira postojeću licitaciju
        /// </summary>
        /// <param name="licitacija">Model licitacije</param>
        /// /// <remarks>
        /// Primer zahteva za ažuriranje postojeće licitacije\
        /// PUT /api/licitacija \
        /// {   \
        ///     "licitacijaId" : "",
        /// "brojLicitacije" : 3,
        /// "godinaLicitacije" : 2021,
        /// "datumRaspisivanja" : "2021-06-01T09:00:00",
        /// "ogranicenje" : 1,
        /// "krugLicitacije" : 2,
        /// "rokZaPrijave" : "2021-07-01T23:59:00"
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPut]
        public ActionResult<LicitacijaModelDto> UpdateLicitacija(LicitacijaUpdateDto licitacija)
        {
            try
            {

                var oldLicitacija = licitacijaRepository.GetLicitacijaById(licitacija.licitacijaId);

                if (oldLicitacija == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound(); 
                }
                LicitacijaModel licitacijaModelEntity = mapper.Map<LicitacijaModel>(licitacija);
                mapper.Map(licitacijaModelEntity, oldLicitacija);                

                licitacijaRepository.SaveChanges(); 
                return Ok(mapper.Map<LicitacijaModelDto>(oldLicitacija));
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
        /// Vreće opcije za rad sa licitacijama
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetLicitacijeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
