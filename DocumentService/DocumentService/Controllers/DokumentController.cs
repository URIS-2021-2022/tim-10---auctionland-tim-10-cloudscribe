using AutoMapper;
using DocumentService.Data;
using DocumentService.Entities;
using DocumentService.Models;
using DocumentService.Models.DokumentModel;
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
    [Route("api/dokument")]
    //[Produces("application/json", "application/xml")]
  // [Produces("text/plain")]
    [Authorize]
    
    public class DokumentController : ControllerBase
    {
        private readonly IDokumentRepository dokumentRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;
        private readonly IKorisnikService korisnikService;

        public DokumentController(IDokumentRepository dokumentRepository, IMapper mapper, LinkGenerator linkGenerator, ILoggerService loggerService, IKorisnikService korisnikService)
        {
            this.dokumentRepository = dokumentRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "Dokument";
            this.korisnikService = korisnikService;
        }

        //Vraca sve dokumente
        /// <response code="200">Vraća dokumente</response>
        /// <response code="500">Došlo je do greške na serveru</response>
        /// 
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<DokumentDto>> GetAllDokuments()
        // public String GetAllDokuments()
        {
            loggerDto.HttpMethod = "GET";
            var dokumenti = dokumentRepository.GetAllDokuments();
            if (dokumenti == null || dokumenti.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return NoContent();
                
            }
            loggerDto.Level = "INFO";
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<DokumentDto>>(dokumenti));
           
        }
        /// <summary>
        /// Vracanje dokumenata po id-ju
        /// </summary>
        /// <param name="dokumentId"></param>
        /// <returns></returns>
        /// <response code="200">Vraća dokument po id-ju</response>
        [HttpGet("{dokumentId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<DokumentDto> GetDokumentEntityById(Guid dokumentId)
        {
            loggerDto.HttpMethod = "GET";
            var dokument = dokumentRepository.GetDokumentEntityById(dokumentId);
            if (dokument==null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerDto.Level = "ERROR";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerDto.Level = "INFO";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<DokumentDto>(dokument));
        }

        /// <summary>
        /// Kreiranje dokumenta
        /// </summary>
        /// <param name="dokument">Model dokumenta</param>
        /// <returns></returns>
        ///<response code="200">Vraća kreirani dokument</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja dokumenta</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DokumentConfirmation> CreateDokument([FromBody] DokumentCreationDto dokument)
        {
            try
            {
                loggerDto.HttpMethod = "POST";

                Dokument dokumentEntity = mapper.Map<Dokument>(dokument);
                DokumentConfirmation confirmation = dokumentRepository.CreateDokument(dokumentEntity);
                dokumentRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetAllDokuments", "Dokument", new { dokumentId = confirmation.DokumentID });

                var korisnikInfo = mapper.Map<KorisnikDokumentDto>(dokument);

                korisnikInfo.TipId = confirmation.TipId;
                bool korisnik = korisnikService.KorisnikDokument(korisnikInfo.TipId);

                if (!korisnik)
                {
                    dokumentRepository.DeleteDokument(confirmation.DokumentID);
                    throw new KorisnikException("Neuspesni unos dokumenta.  Molimo kontaktirajte administratora.");
                }

                loggerDto.Response = "201 CREATED";
                loggerDto.Level = "INFO";
                loggerService.CreateLog(loggerDto);
                return Created(location, mapper.Map<DokumentConfirmationDto>(confirmation));
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
        /// Azuriranje dokumenta
        /// </summary>
        /// <param name="dokument"></param>
        /// <returns></returns>
        /// <response code="400">Dokument koji se ažurira nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja dokumenta</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DokumentConfirmationDto> UpdateDokument(DokumentUpdateDto dokument)
        {
            try
            {
                var oldDokument = dokumentRepository.GetDokumentEntityById(dokument.DokumentID);
                if (oldDokument == null)
                {
                    loggerDto.Level = "WARN";
                    return NotFound();
                }
                Dokument dokumentEntity = mapper.Map<Dokument>(dokument);
                mapper.Map(dokumentEntity, oldDokument);
                dokumentRepository.SaveChanges();
                return Ok(mapper.Map<DokumentDto>(oldDokument));
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
        /// Brisanje dokumenta
        /// </summary>
        /// <param name="dokumentId"></param>
        /// <returns></returns>
        /// <response code="404">Nije pronađen dokument za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja dokumenta</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{dokumentId}")]
        public IActionResult DeleteDokument(Guid dokumentId)
        {
            try
            {
                loggerDto.HttpMethod = "DELETE";
                var dokument = dokumentRepository.GetDokumentEntityById(dokumentId);

                if (dokument == null)
                {
                    loggerDto.Response = "404 NOT FOUND";
                    loggerDto.Level = "ERROR";
                    loggerService.CreateLog(loggerDto);
                    return NotFound();
                }

                dokumentRepository.DeleteDokument(dokumentId);
                dokumentRepository.SaveChanges();
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
        /// Vraca opcije za rad sa dokumentima
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetDokumentOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT,DELETE");
            return Ok();
        }
    }
}
