using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OglasService.Data;
using OglasService.Entities;
using OglasService.Models;
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

        public SluzbeniListController(IMapper mapper, LinkGenerator linkGenerator,ISluzbeniListRepository sluzbeniListRepository)
        {
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.sluzbeniListRepository = sluzbeniListRepository;
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
            var sList = sluzbeniListRepository.GetSluzbeniListovi();
            if (sList == null || sList.Count == 0)
            {
                return NoContent();
            }
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
            var sList = sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);
            if (sList == null)
            {
                return NotFound();
            }
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
                SluzbeniList sluzbeniListEntity = mapper.Map<SluzbeniList>(sluzbeniList);
                SluzbeniListConfirmation confirmation = sluzbeniListRepository.CreateSluzbeniList(sluzbeniListEntity);
                sluzbeniListRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetSluzbeniList", "SluzbeniList", new { sluzbeniListId = confirmation.SluzbeniListId });
                return Created(location, mapper.Map<SluzbeniListConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
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
                    return NotFound();
                }
                //SluzbeniList sluzbeniListEntity = mapper.Map<SluzbeniList>(sluzbeniList);
                mapper.Map(sluzbeniList, oldSluzbeniList);
                sluzbeniListRepository.SaveChanges();
                return Ok(mapper.Map<SluzbeniListDto>(oldSluzbeniList));
            }
            catch (Exception)
            {
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
                var sList = sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);

                if (sList == null)
                {
                    return NotFound();
                }

                sluzbeniListRepository.DeleteSluzbeniList(sluzbeniListId);
                sluzbeniListRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
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
