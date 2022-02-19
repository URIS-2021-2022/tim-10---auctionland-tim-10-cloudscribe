using AutoMapper;
using DocumentService.Data;
using DocumentService.Entities;
using DocumentService.Models;
using DocumentService.Models.DokumentModel;
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
    [Produces("application/json", "application/xml")]
    public class DokumentController : ControllerBase
    {
        private readonly IDokumentRepository dokumentRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public DokumentController(IDokumentRepository dokumentRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.dokumentRepository = dokumentRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
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
        {
            var dokumenti = dokumentRepository.GetAllDokuments();
            if (dokumenti == null || dokumenti.Count == 0)
            {
                return NotFound();
            }
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
            var dokument = dokumentRepository.GetDokumentEntityById(dokumentId);
            if (dokument==null)
            {
                return NotFound();
            }
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
                Dokument dokumentEntity = mapper.Map<Dokument>(dokument);
                DokumentConfirmation confirmation = dokumentRepository.CreateDokument(dokumentEntity);
                dokumentRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetAllDokuments", "Dokument", new { dokumentId = confirmation.DokumentID });
                return Created(location, mapper.Map<DokumentConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
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
                    return NotFound();
                }
                Dokument dokumentEntity = mapper.Map<Dokument>(dokument);
                mapper.Map(dokumentEntity, oldDokument);
                dokumentRepository.SaveChanges();
                return Ok(mapper.Map<DokumentConfirmationDto>(oldDokument));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        /// <summary>
        /// Brisanje dokumenta
        /// </summary>
        /// <param name="dokumentId"></param>
        /// <returns></returns>
        /// <response code="404">Nije pronađen zastupnik za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja zastupnika</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{dokumentId}")]
        public IActionResult DeleteDokument(Guid dokumentId)
        {
            try
            {
                var dokument = dokumentRepository.GetDokumentEntityById(dokumentId);

                if (dokument == null)
                {
                    return NotFound();
                }

                dokumentRepository.DeleteDokument(dokumentId);
                return NoContent();
            }
            catch (Exception)
            {
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
            Response.Headers.Add("Allow", "GET, POST PUT,DELETE");
            return Ok();
        }
    }
}
