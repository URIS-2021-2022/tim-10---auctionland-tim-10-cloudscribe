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
    /// Controller class for StatusZalbe
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatusZalbeController : ControllerBase
    {
        private readonly IStatusZalbeRepository statusZalbeRepository;

        /// <summary>
        /// Constructor which takes statusZalbeRepository instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="statusZalbeRepository">statusZalbeRepository instance</param>
        public StatusZalbeController(IStatusZalbeRepository statusZalbeRepository)
        {
            this.statusZalbeRepository = statusZalbeRepository;
        }

        /// <summary>
        /// Endpoint for retrieving all Zalbas from the Database
        /// </summary>
        /// <response code="200">List of StatusZalbe</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllStatusZalbe()
        {
            return Ok(statusZalbeRepository.GetAllStatusZalbe());
        }

        /// <summary>
        /// Method that returns a list of IdNameDtos for StatusZalbe
        /// </summary>
        /// <returns code="200">list of IdNameDtos for StatusZalbe</returns>
        [HttpGet("dropdown")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetIdNameDropdownItemsForStatusZalbe()
        {
            return Ok(statusZalbeRepository.GetIdNameDropdownItemsForStatusZalbe());
        }

        /// <summary>
        /// Method that returns statusZalbe by its id
        /// </summary>
        /// <param name="statusZalbeId">Id of statusZalbe</param>
        /// <returns code="200">statusZalbe entity</returns>
        /// <returns code="404">entity not found</returns>
        [HttpGet("{statusZalbeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetStatusZalbeById(int statusZalbeId)
        {
            StatusZalbe statusZalbe = statusZalbeRepository.GetStatusZalbeById(statusZalbeId);
            if (statusZalbe == null)
            {
                return NotFound();
            }
            return Ok(statusZalbe);
        }

        /// <summary>
        /// Endpoint for creating statusZalbe
        /// </summary>
        /// <param name="statusZalbeDto"></param>
        /// <returns code="200">statusZalbe entity</returns>
        /// <returns code="400">statusZalbe already exists</returns>
        /// <returns code="500">server error</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddStatusZalbe(StatusZalbeDto statusZalbeDto)
        {
            if (statusZalbeRepository.GetStatusZalbeIdByStatusZalbe(statusZalbeDto.StatusZalbe) != 0)
            {
                return BadRequest("StatusZalbe already exists.");
            }
       
            statusZalbeRepository.AddStatusZalbe(statusZalbeDto);

            try
            {
                if (!statusZalbeRepository.SaveChanges())
                {
                    throw new Exception("StatusZalbe hasn't been created successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            // not returning Created because that would require a redundant endpoint
            return Ok("StatusZalbe has been created.");
        }

        /// <summary>
        /// Endpoint for updating StatusZalbe
        /// </summary>
        /// <param name="statusZalbe"></param>
        /// <returns code="200">statusZalbe entity</returns>
        /// <returns code="400">statusZalbe already exists</returns>
        /// <returns code="500">server error</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateStatusZalbe(StatusZalbe statusZalbe)
        {
            // If there is no entity in db, it can't be updated
            if(!statusZalbeRepository.Exists(statusZalbe.StatusZalbeId))
            {
                return NotFound();
            }

            // Check if that statusZalbe already exists
            if (statusZalbeRepository.GetStatusZalbeIdByStatusZalbe(statusZalbe.StatusZalbe1) != 0)
            {
                return BadRequest("StatusZalbe already exists.");
            }

            statusZalbeRepository.UpdateStatusZalbe(statusZalbe);

            try
            {
                if (!statusZalbeRepository.SaveChanges())
                {
                    throw new Exception("StatusZalbe hasn't been updated successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("StatusZalbe has been updated.");
        }

        /// <summary>
        /// Endpoint for deleting StatusZalbe
        /// </summary>
        /// <param name="statusZalbeId"></param>
        /// <returns code="404">entity not found</returns>
        /// <returns code="500">server error</returns>
        [HttpDelete("{statusZalbeId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteStatusZalbe(int statusZalbeId)
        {
            try
            {
                StatusZalbe statusZalbe = statusZalbeRepository.GetStatusZalbeById(statusZalbeId);

                if (statusZalbe == null)
                {
                    return NotFound();
                }

                statusZalbeRepository.DeleteStatusZalbe(statusZalbe);

                if (!statusZalbeRepository.SaveChanges())
                {
                    throw new Exception("StatusZalbe hasn't been deleted successfully.");
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }
        }

        /// <summary>
        /// Returns options for manipulating StatusZalbe
        /// </summary>
        /// <returns>options for manipulating StatusZalbe</returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetStatusZalbeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
