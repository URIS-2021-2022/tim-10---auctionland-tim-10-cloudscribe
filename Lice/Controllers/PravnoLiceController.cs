using AutoMapper;
using Lice.Data;
using Lice.Entities;
using Lice.Models.PravnoLice;
using Lice.Models.Services;
using Lice.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/pravnaLica")]
    [Produces("application/json", "applciation/xml")]
    public class PravnoLiceController : ControllerBase
    {
        private readonly IPravnoLiceRepository pravnoLiceRepository;
        private readonly IPrioritetRepository prioritetRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;

        public PravnoLiceController(IPravnoLiceRepository pravnoLiceRepository, IPrioritetRepository prioritetRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.pravnoLiceRepository = pravnoLiceRepository;
            this.prioritetRepository = prioritetRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "PRAVNO LICE";
        }

        /// <summary>
        /// Vraća sva pravna lica
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<PravnoLiceDto>> GetPravnaLica()
        {
            loggerDto.HttpMethod = "GET";
            var pravnaLica = pravnoLiceRepository.GetPravnaLica();
            if (pravnaLica == null || pravnaLica.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }

            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<PravnoLiceDto>>(pravnaLica));
        }

        /// <summary>
        /// Vraća pravno lice na osnovu ID-ja lica
        /// </summary>
        /// <param name="liceId">ID lica</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{liceId}")]
        public ActionResult<PravnoLiceDto> GetPravnoLice(Guid liceId)
        {
            loggerDto.HttpMethod = "GET";
            var pravnoLice = pravnoLiceRepository.GetPravnoLiceById(liceId);

            if (pravnoLice == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }

            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<PravnoLiceDto>(pravnoLice));
        }

        /// <summary>
        /// Dodaje novo pravno lice
        /// </summary>
        /// <param name="pravnoLice">Model pravnog lica</param>
        /// /// <remarks>
        /// Primer zahteva za kreiranje novog pravnog lica\
        /// POST /api/pravnaLica \
        /// {   \
        ///     "brojTelefona1": "064855446",
        ///     "brojTelefona2": "066985684",
        ///     "email": "masterplast@gmail.com",
        ///     "brojRacuna": "800458757",
        ///     "prioritetId": "26797103-3a18-4750-9f27-33416e6e30d4",
        ///     "naziv": "Masterplast",
        ///     "faks": 024601785,
        ///     "maticniBroj" : "25485674"
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<PravnoLiceConfirmationDto> CreatePravnoLice([FromBody] PravnoLiceCreationDto pravnoLice)
        {
            loggerDto.HttpMethod = "POST";

            try
            {
                PravnoLiceEntity pravnoLiceEntity = mapper.Map<PravnoLiceEntity>(pravnoLice);
                pravnoLiceEntity.Prioritet = prioritetRepository.GetPrioritetById(pravnoLice.prioritetId);
                PravnoLiceConfirmationEntity confirmation = pravnoLiceRepository.CreatePravnoLice(pravnoLiceEntity);
                pravnoLiceRepository.SaveChanges();
                
                string location = linkGenerator.GetPathByAction("GetPravnoLice", "PravnoLice", new { liceId = confirmation.liceId });

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<PravnoLiceConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        /// <summary>
        /// Ažurira postojeće pravno lice
        /// </summary>
        /// <param name="pravnoLice">Model pravnog lica</param>
        /// /// <remarks>
        /// Primer zahteva za ažuriranje postojećeg pravnog lica\
        /// PUT /api/pravnaLica \
        /// {   \
        ///     "liceId": "",
        ///     "brojTelefona1": "064855446",
        ///     "brojTelefona2": "066985684",
        ///     "email": "masterplast@gmail.com",
        ///     "brojRacuna": "800458757",
        ///     "prioritetId": "26797103-3a18-4750-9f27-33416e6e30d4",
        ///     "naziv": "Masterplast",
        ///     "faks": 024601785,
        ///     "maticniBroj": "25485674"
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPut]
        public ActionResult<PravnoLiceDto> UpdatePravnoLice([FromBody] PravnoLiceUpdateDto pravnoLice)
        {
            loggerDto.HttpMethod = "PUT";

            try
            {
                var oldPravnoLice = pravnoLiceRepository.GetPravnoLiceById(pravnoLice.liceId);

                if (oldPravnoLice == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                PravnoLiceEntity pravnoLiceEntity = mapper.Map<PravnoLiceEntity>(pravnoLice);
                pravnoLiceEntity.Prioritet = prioritetRepository.GetPrioritetById(pravnoLice.prioritetId);
                mapper.Map(pravnoLiceEntity, oldPravnoLice);
                pravnoLiceRepository.SaveChanges();

                loggerDto.Response = "200 OK";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Ok(mapper.Map<PravnoLiceDto>(oldPravnoLice));
            }
            catch (Exception)
            {
                loggerDto.Response = "500 INTERNAL SERVER ERROR";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
            }
        }

        /// <summary>
        /// Vrši brisanje jednog lica na osnovu ID-ja
        /// </summary>
        /// <param name="liceId">ID lica</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{liceId}")]
        public IActionResult DeletePravnoLice(Guid liceId)
        {
            loggerDto.HttpMethod = "DELETE";

            try
            {
                var pravnoLice = pravnoLiceRepository.GetPravnoLiceById(liceId);

                if (pravnoLice == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                pravnoLiceRepository.DeletePravnoLice(liceId);
                pravnoLiceRepository.SaveChanges();

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
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        /// <summary>
        /// Vreće opcije za rad sa pravnim licima
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetPravnoLiceOptions()
        {
            loggerDto.HttpMethod = "OPTIONS";

            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");

            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok();
        }
    }
}
