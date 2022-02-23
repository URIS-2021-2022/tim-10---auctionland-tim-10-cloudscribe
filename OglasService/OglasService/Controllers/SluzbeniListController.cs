using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OglasService.Data;
using OglasService.Entities;
using OglasService.Models;
using OglasService.ServiceCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/sluzbeniList")]
    public class SluzbeniListController:ControllerBase
    {
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ISluzbeniListRepository sluzbeniListRepository;
        private readonly ILoggerService loggerService;
        private readonly LoggerDtos loggerDto;

        public SluzbeniListController(IMapper mapper, LinkGenerator linkGenerator,ISluzbeniListRepository sluzbeniListRepository,ILoggerService loggerService)
        {
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.sluzbeniListRepository = sluzbeniListRepository;
            this.loggerService = loggerService;
            loggerDto = new LoggerDtos();
            loggerDto.ServiceName = "Sluzbeni list";
        }

        /// <summary>
        /// Vraca sve sluzbene listove
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraća sluzbene listove</response>
        /// <response code="500">Došlo je do greške na serveru</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<SluzbeniListDto>> GetSluzbeniListovi()
        {
            loggerDto.HttpMethod = "GET";
            var sList = sluzbeniListRepository.GetSluzbeniListovi();
            if (sList == null || sList.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
            }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<SluzbeniListDto>>(sList));
        }

        /// <summary>
        /// Vraca sluzbene listove po id-ju
        /// </summary>
        /// <param name="sluzbeniListId"></param>
        /// <returns></returns>
        [HttpGet("{sluzbeniListId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<SluzbeniListDto> GetSluzbeniList(Guid sluzbeniListId)
        {
            loggerDto.HttpMethod = "GET";
            var sList = sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);
            if (sList == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<SluzbeniListDto>(sList));
        }

        /// <summary>
        /// Kreiranje sluzbenog lista
        /// </summary>
        /// <param name="sluzbeniList"></param>
        /// <returns></returns>
        /// Primer zahteva za kreiranje sluzbenog lista
        ///  POST /api/sluzbaniList \
        ///  {
        ///      "opstina": "Temerin",
        ///      "brojSluzbenogLista": 15,
        ///      "datumIzdavanja": "2021-05-15T09:00:00"
        ///    }
        /// <response code="200">Vraća kreiran sluzbeni list</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja sluzbenog lista</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SluzbeniListConfirmationDto> CreateSluzbeniList([FromBody] SluzbeniListCreationDto sluzbeniList)
        {
            try
            {
                loggerDto.HttpMethod = "POST";

                SluzbeniList sluzbeniListEntity = mapper.Map<SluzbeniList>(sluzbeniList);
                SluzbeniListConfirmation confirmation = sluzbeniListRepository.CreateSluzbeniList(sluzbeniListEntity);
                sluzbeniListRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetSluzbeniList", "SluzbeniList", new { sluzbeniListId = confirmation.SluzbeniListId });

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);

                return Created(location, mapper.Map<SluzbeniListConfirmationDto>(confirmation));
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
        /// Azurira sluzbeni list
        /// </summary>
        /// <param name="sluzbeniList"></param>
        /// <returns></returns>
        /// Primer zahteva za azuriranje novog sluzbnog lista
        ///  PUT /api/sluzbaniList \
        ///  {
       ///     "sluzbeniListId": "b5a32a14-b173-47ba-455b-08d9f553d0b2",
       ///     "opstina": "Subotica",
       ///     "brojSluzbenogLista": 5,
       ///     "datumIzdavanja": "2021-05-15T09:00:00"
       ///     }
       /// <response code="200">Vraća ažurirani sluzbeni list</response>
       /// <response code="400">Sluzbeni list koji se ažurira nije pronađen</response>
       /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja sluzbenog lista</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SluzbeniListConfirmationDto> UpdateSluzbeniList(SluzbeniListUpdateDto sluzbeniList)
        {
            try
            {
                var oldSluzbeniList = sluzbeniListRepository.GetSluzbeniListById(sluzbeniList.SluzbeniListId);
                if (oldSluzbeniList == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }
                mapper.Map(sluzbeniList, oldSluzbeniList);
                sluzbeniListRepository.SaveChanges();
                return Ok(mapper.Map<SluzbeniListDto>(oldSluzbeniList));
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
        /// Brisanje sluzbenog lista
        /// </summary>
        /// <param name="sluzbeniListId"></param>
        /// <returns></returns>
        /// <response code="204">Sluzbeni list uspešno obrisan</response>
        /// <response code="404">Nije pronađen sluzbeni list za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja sluzbenog lista</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{sluzbeniListId}")]
        public IActionResult DeleteSluzbeniList(Guid sluzbeniListId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var sList = sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);

                if (sList == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                sluzbeniListRepository.DeleteSluzbeniList(sluzbeniListId);
                sluzbeniListRepository.SaveChanges();

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
        /// Vraca opcije za rad sa sluzbenim listovima
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKupacOpctions()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT, DELETE");
            return Ok();
        }
    }
}
