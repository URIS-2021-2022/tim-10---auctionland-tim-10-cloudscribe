using AutoMapper;
using Lice.Data;
using Lice.Entities;
using Lice.Models.FizickoLice;
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
    [Route("api/fizickaLica")]
    [Produces("application/json", "applciation/xml")]
    public class FizickoLiceController : ControllerBase
    {
        private readonly IFizickoLiceRepository fizickoLiceRepository;
        private readonly IPrioritetRepository prioritetRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;

        public FizickoLiceController(IFizickoLiceRepository fizickoLiceRepository, IPrioritetRepository prioritetRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.fizickoLiceRepository = fizickoLiceRepository;
            this.prioritetRepository = prioritetRepository;
            this.linkGenerator = linkGenerator;7
            this.mapper = mapper;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "FIZICKO LICE";
        }

        /// <summary>
        /// Vraća sva fizička lica
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<FizickoLiceDto>> GetFizickaLica()
        {
            loggerDto.HttpMethod = "GET";
            var fizickaLica = fizickoLiceRepository.GetFizickaLica();
            if (fizickaLica == null || fizickaLica.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }

            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<FizickoLiceDto>>(fizickaLica));
        }

        /// <summary>
        /// Vraća fizičko lice na osnovu ID-ja lica
        /// </summary>
        /// <param name="liceId">ID lica</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{liceId}")]
        public ActionResult<FizickoLiceDto> GetFizickoLice(Guid liceId)
        {
            loggerDto.HttpMethod = "GET";
            var fizickoLice = fizickoLiceRepository.GetFizickoLiceById(liceId);

            if (fizickoLice == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }

            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<FizickoLiceDto>(fizickoLice));
        }

        /// <summary>
        /// Dodaje novo fizičko lice
        /// </summary>
        /// <param name="fizickoLice">Model fizičkog lica</param>
        /// /// <remarks>
        /// Primer zahteva za kreiranje novog fizičkog lica\
        /// POST /api/fizickaLica \
        /// {   \
        ///     "brojTelefona1": "062535856",
        ///     "brojTelefona2": "061258457",
        ///     "email": "mmarkovic@gmail.com",
        ///     "brojRacuna": "80045875687",
        ///     "prioritetId": "26797103-3a18-4750-9f27-33416e6e30d4",
        ///     "ime": "Marko",
        ///     "prezime": "Marković"
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<FizickoLiceConfirmationDto> CreateFizickoLice([FromBody] FizickoLiceCreationDto fizickoLice)
        {
            loggerDto.HttpMethod = "POST";

            try
            {
                FizickoLiceEntity fizickoLiceEntity = mapper.Map<FizickoLiceEntity>(fizickoLice);
                fizickoLiceEntity.Prioritet = prioritetRepository.GetPrioritetById(fizickoLice.prioritetId);
                FizickoLiceConfirmationEntity confirmation = fizickoLiceRepository.CreateFizickoLice(fizickoLiceEntity);
                fizickoLiceRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetFizickoLice", "FizickoLice", new { liceId = confirmation.liceId });

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<FizickoLiceConfirmationDto>(confirmation));
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
        /// Ažurira postojeće fizičko lice
        /// </summary>
        /// <param name="fizickoLice">Model fizičkog lica</param>
        /// /// <remarks>
        /// Primer zahteva za ažuriranje postojećeg fizičkog lica\
        /// PUT /api/fizickaLica \
        /// {   \
        ///     "liceId": "",
        ///     "brojTelefona1": "062535856",
        ///     "brojTelefona2": "061258457",
        ///     "email": "nnikolic2@gmail.com",
        ///     "brojRacuna": "8008465687",
        ///     "prioritetId": "26797103-3a18-4750-9f27-33416e6e30d4",
        ///     "ime": "Nikola",
        ///     "prezime": "Nikolić"
        /// }
        ///</remarks>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPut]
        public ActionResult<FizickoLiceDto> UpdateFizickoLice([FromBody] FizickoLiceUpdateDto fizickoLice)
        {
            loggerDto.HttpMethod = "PUT";

            try
            {
                var oldFizickoLice = fizickoLiceRepository.GetFizickoLiceById(fizickoLice.liceId);
                
                if (oldFizickoLice == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                FizickoLiceEntity fizickoLiceEntity = mapper.Map<FizickoLiceEntity>(fizickoLice);
                fizickoLiceEntity.Prioritet = prioritetRepository.GetPrioritetById(fizickoLice.prioritetId);
                mapper.Map(fizickoLiceEntity, oldFizickoLice);
                fizickoLiceRepository.SaveChanges();

                loggerDto.Response = "200 OK";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Ok(mapper.Map<FizickoLiceDto>(oldFizickoLice));
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
        public IActionResult DeleteFizickoLice(Guid liceId)
        {
            loggerDto.HttpMethod = "DELETE";

            try
            {
                var fizickoLice = fizickoLiceRepository.GetFizickoLiceById(liceId);

                if(fizickoLice == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                fizickoLiceRepository.DeleteFizickoLice(liceId);
                fizickoLiceRepository.SaveChanges();

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
        /// Vreće opcije za rad sa fizičkim licima
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetFizickoLiceOptions()
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
