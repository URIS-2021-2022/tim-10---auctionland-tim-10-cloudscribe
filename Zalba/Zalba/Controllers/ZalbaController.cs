using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Controllers
{
    /// <summary>
    /// Controller class for Zalba
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ZalbaController : ControllerBase
    {
        private ITipZalbeRepository tipZalbeRepository { get; }

        private IStatusZalbeRepository statusZalbeRepository { get; }
        private IZalbaRepository zalbaRepository { get; }

        /// <summary>
        /// Constructor which takes repository instances as parameter through Dependency Injection
        /// </summary>
        /// <param name="statusZalbeRepository"></param>
        /// <param name="zalbaRepository"></param>
        /// <param name="tipZalbeRepository"></param>
        public ZalbaController(IStatusZalbeRepository statusZalbeRepository, IZalbaRepository zalbaRepository, ITipZalbeRepository tipZalbeRepository)
        {
            this.statusZalbeRepository = statusZalbeRepository;
            this.zalbaRepository = zalbaRepository;
            this.tipZalbeRepository = tipZalbeRepository;
        }

        /// <summary>
        /// Endpoint for retrieving all Zalbas from the Database
        /// </summary>
        /// <returns code="200">List of Zalbas</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllZalbas()
        {
            return Ok(zalbaRepository.GetAllZalbas());
        }

        /// <summary>
        /// Method that returns zalba by its id
        /// </summary>
        /// <param name="zalbaId">Id of zalba</param>
        /// <returns code="200">zalba entity</returns>
        /// <returns code="404">entity not found</returns>
        [HttpGet("{zalbaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTipZalbeById(int zalbaId)
        {
            Zalba zalba = zalbaRepository.GetZalbaById(zalbaId);
            if (zalba == null)
            {
                return NotFound();
            }
            return Ok(zalba);
        }

        /// <summary>
        /// Endpoint for creating a Zalba
        /// </summary>
        /// <param name="zalbaDto">DTO object containing required properties for Zalba entit</param>
        /// <returns code="200">zalba entity</returns>
        /// <returns code="400">zalba already exists</returns>
        /// <returns code="500">server error</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateZalba(ZalbaDto zalbaDto)
        {
            // Perform validation 
            string validationResult = zalbaRepository.ValidateZalba(zalbaDto.BrojOdluke, zalbaDto.BrojResenja, zalbaDto.DatumResenja, zalbaDto.TipZalbeId);
            
            if (string.IsNullOrEmpty(validationResult))
            {
                return BadRequest(validationResult);
            }

            if (!tipZalbeRepository.Exists(zalbaDto.TipZalbeId))
            {
                return NotFound("There is no TipZalbe with given TipZalbeId");
            }

            // Get statusZalbe
            int statusZalbeId = statusZalbeRepository.GetStatusZalbeIdByStatusZalbe("Otvorena");

            if (statusZalbeId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            zalbaRepository.AddZalba(zalbaDto, statusZalbeId);

            try
            {
                if (!zalbaRepository.SaveChanges())
                {
                    throw new Exception("Zalba hasn't been created successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            // not returning Created because that would require a redundant endpoint
            return Ok("Zalba has been created.");

        }

        /// <summary>
        /// Method that updates the field of statusZalbe
        /// </summary>
        /// <param name="resolveZalbaDto"></param>
        /// <returns code="200">zalba entity</returns>
        /// <returns code="400">zalba already exists</returns>
        /// <returns code="404">zalba doesn't exist</returns>
        /// <returns code="500">server error</returns>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ResolveZalba(ResolveZalbaDto resolveZalbaDto)
        {
            // Checking if StatusZalbe with passed StatusZalbeId exists in the database
            if (!statusZalbeRepository.Exists(resolveZalbaDto.StatusZalbeId))
            {
                return BadRequest("There is no StatusZalbe with given StatusZalbeId.");
            }

            // Retrieving Zalba entity from the database based on the passed ZalbaID
            Zalba zalba = zalbaRepository.GetZalbaById(resolveZalbaDto.ZalbaId);

            // If the entity doesn't exist, we're returning a 400 error
            if (zalba == null)
            {
                return NotFound();
            }

            // If Zalba is already resolved, it cannot be updated
            // Only Zalba with StatusZalbeId 1 can be updated
            if (zalba.StatusZalbeId != 1)
            {
                return BadRequest("Zalba is already resolved and cannot be updated.");
            }

            zalbaRepository.ResolveZalba(zalba, resolveZalbaDto);

            try
            {
                if (!zalbaRepository.SaveChanges())
                {
                    throw new Exception("Zalba hasn't been updated successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Zalba has been updated.");
        }

        /// <summary>
        /// Method that updates the fields of Zalba
        /// </summary>
        /// <param name="updateZalbaDto"></param>
        /// <returns code="200">zalba entity</returns>
        /// <returns code="400">zalba already exists</returns>
        /// <returns code="404">zalba doesn't exist</returns>
        /// <returns code="500">server error</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateZalba(UpdateZalbaDto updateZalbaDto)
        {
            string validationResult = zalbaRepository.ValidateZalba(updateZalbaDto.BrojOdluke, updateZalbaDto.BrojResenja, updateZalbaDto.DatumResenja, updateZalbaDto.TipZalbeId);

            if (string.IsNullOrEmpty(validationResult))
            {
                return BadRequest(validationResult);
            }

            if (!tipZalbeRepository.Exists(updateZalbaDto.TipZalbeId))
            {
                return NotFound("There is no TipZalbe with given TipZalbeId");
            }

            // Retrieving Zalba entity from the database based on the passed ZalbaID
            Zalba zalba = zalbaRepository.GetZalbaById(updateZalbaDto.ZalbaId);

            // If the entity doesn't exist, we're returning a 400 error
            if (zalba == null)
            {
                return NotFound();
            }

            zalbaRepository.UpdateZalba(zalba, updateZalbaDto);

            try
            {
                if (!zalbaRepository.SaveChanges())
                {
                    throw new Exception("Zalba hasn't been updated successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Zalba has been updated.");
        }

        /// <summary>
        /// Endpoint for deleting Zalba
        /// </summary>
        /// <param name="zalbaId"></param>
        /// <returns code="404">entity not found</returns>
        /// <returns code="500">server error</returns>
        [HttpDelete("{zalbaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteZalba(int zalbaId)
        {
            try
            {
                Zalba zalba = zalbaRepository.GetZalbaById(zalbaId);

                if (zalba == null)
                {
                    return NotFound();
                }

                zalbaRepository.DeleteZalba(zalba);

                if (!zalbaRepository.SaveChanges())
                {
                    throw new Exception("Zalba hasn't been deleted successfully.");
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }
        }

        /// <summary>
        /// Returns options for manipulating Zalbas
        /// </summary>
        /// <returns>options for manipulating Zalbas</returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetZalbaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE");
            return Ok();
        }
    }
}
