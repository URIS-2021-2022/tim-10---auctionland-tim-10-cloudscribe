using AutoMapper;
using Lice.Data;
using Lice.Entities;
using Lice.Models.FizickoLice;
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
    [Route("api/fizickaLica")]
    [Produces("application/json", "applciation/xml")]
    public class FizickoLiceController : ControllerBase
    {
        private readonly IFizickoLiceRepository fizickoLiceRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public FizickoLiceController(IFizickoLiceRepository fizickoLiceRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.fizickoLiceRepository = fizickoLiceRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sva fizicka lica
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<FizickoLiceDto>> GetFizickaLica()
        {
            var fizickaLica = fizickoLiceRepository.GetFizickaLica();
            if (fizickaLica == null || fizickaLica.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<FizickoLiceDto>>(fizickaLica));
        }

        /// <summary>
        /// Vraća fizicko lice na osnovu ID-ja lica
        /// </summary>
        /// <param name="liceId">ID lica</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{liceId}")]
        public ActionResult<FizickoLiceDto> GetFizickoLice(Guid liceId)
        {
            var fizickoLice = fizickoLiceRepository.GetFizickoLiceById(liceId);

            if (fizickoLice == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<FizickoLiceDto>(fizickoLice));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fizickoLice">Model fizickog lica</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<FizickoLiceConfirmationDto> CreateFizickoLice([FromBody] FizickoLiceCreationDto fizickoLice)
        {
            try
            {
                FizickoLiceEntity fizickoLiceEntity = mapper.Map<FizickoLiceEntity>(fizickoLice);
                FizickoLiceConfirmationEntity confirmation = fizickoLiceRepository.CreateFizickoLice(fizickoLiceEntity);
                fizickoLiceRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetFizickoLice", "FizickoLice", new { liceId = confirmation.liceId });
                return Created(location, mapper.Map<FizickoLiceConfirmationDto>(confirmation));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        /// <summary>
        /// Ažurira postojeće fizicko lice
        /// </summary>
        /// <param name="fizickoLice">Model fizickog lica</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPut]
        public ActionResult<FizickoLiceDto> UpdateFizickoLice([FromBody] FizickoLiceUpdateDto fizickoLice)
        {
            try
            {
                var oldFizickoLice = fizickoLiceRepository.GetFizickoLiceById(fizickoLice.liceId);

                if (oldFizickoLice == null)
                {
                    return NotFound();
                }

                FizickoLiceEntity fizickoLiceEntity = mapper.Map<FizickoLiceEntity>(fizickoLice);

                mapper.Map(fizickoLiceEntity, oldFizickoLice);

                fizickoLiceRepository.SaveChanges();

                return Ok(mapper.Map<FizickoLiceDto>(oldFizickoLice));
            }
            catch (Exception)
            {

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
            try
            {
                var fizickoLice = fizickoLiceRepository.GetFizickoLiceById(liceId);

                if(fizickoLice == null)
                {
                    return NotFound();
                }

                fizickoLiceRepository.DeleteFizickoLice(liceId);
                fizickoLiceRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        /// <summary>
        /// Vreće opcije za rad sa fizickim licima
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpOptions]
        public IActionResult GetFizickoLiceOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }


    }
}
