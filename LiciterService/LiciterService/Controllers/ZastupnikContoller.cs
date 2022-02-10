using AutoMapper;
using LiciterService.Data;
using LiciterService.Entities;
using LiciterService.Entities.ZastupnikEntity;
using LiciterService.Models;
using LiciterService.Models.Zastupnik;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Controllers
{
    [ApiController]
    [Route("api/zastupnik")]
    public class ZastupnikContoller: ControllerBase
    {
        private readonly IZastupnikRepository zastupnikRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public ZastupnikContoller(IZastupnikRepository zastupnikRepository,IMapper mapper,LinkGenerator linkGenerator)
        {
            this.zastupnikRepository = zastupnikRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Vraca sve zastupnike
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraća zastupnike</response>
        /// <response code="500">Došlo je do greške na serveru</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ZastupnikDto>> GetZastupnici()
        {
            var zastupnici = zastupnikRepository.GetZastupnici();
            if (zastupnici == null || zastupnici.Count==0)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<ZastupnikDto>>(zastupnici));
        }
        /// <summary>
        /// Vracanje zastupnika po id-ju
        /// </summary>
        /// <param name="zastupnikId"></param>
        /// <returns></returns>
        /// <response code="200">Vraća zastupnika po id-ju</response>
        [HttpGet("{zastupnikId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ZastupnikDto> GetZastupnik(Guid zastupnikId)
        {
            var zastupnik = zastupnikRepository.GetZastupnikById(zastupnikId);
            if (zastupnik == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ZastupnikDto>(zastupnik));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacConfirmationDto> CreateZastupnik([FromBody] ZastupnikCreationDto zastupnik)
        {
            try
            {
                Zastupnik zastupnikEntity = mapper.Map<Zastupnik>((ZastupnikCreationDto) zastupnik);
                ZastupnikConfirmation confirmation = zastupnikRepository.CreateZastupnik(zastupnikEntity);
                zastupnikRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetZastupnik", "Zastupnik", new { zastupnikId = confirmation.ZastupnikId });
                return Created(location, mapper.Map<ZastupnikConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }

        }
    }
}
