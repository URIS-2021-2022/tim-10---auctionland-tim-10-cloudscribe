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
    /// Controller class for TipZalbe
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TipZalbeController : ControllerBase
    {
        private readonly ITipZalbeRepository tipZalbeRepository;

        /// <summary>
        /// Constructor which takes tipZalbeRepository instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="tipZalbeRepository"></param>
        public TipZalbeController(ITipZalbeRepository tipZalbeRepository)
        {
            this.tipZalbeRepository = tipZalbeRepository;
        }

        /// <summary>
        /// Endpoint for retrieving all TipZalbe from the Database    
        /// </summary>
        /// <returns code="200">List of TipZalbe</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllTipZalbe()
        {
            return Ok(tipZalbeRepository.GetAllTipZalbe());
        }

        /// <summary>
        /// Method that returns a list of IdNameDtos for TipZalbe
        /// </summary>
        /// <returns code="200">list of IdNameDtos for TipZalbe</returns>
        [HttpGet("dropdown")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetIdNameDropdownItemsForTipZalbe()
        {
            return Ok(tipZalbeRepository.GetIdNameDropdownItemsForTipZalbe());
        }

        /// <summary>
        /// Method that returns tipZalbe by its id
        /// </summary>
        /// <param name="tipZalbeId">Id of tipZalbe</param>
        /// <returns code="200">tipZalbe entity</returns>
        /// <returns code="404">entity not found</returns>
        [HttpGet("{tipZalbeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTipZalbeById(int tipZalbeId)
        {
            TipZalbe tipZalbe = tipZalbeRepository.GetTipZalbeById(tipZalbeId);
            if (tipZalbe == null)
            {
                return NotFound();
            }
            return Ok(tipZalbe);
        }

        /// <summary>
        /// Endpoint for creating tipZalbe
        /// </summary>
        /// <param name="tipZalbeDto"></param>
        /// <returns code="200">tipZalbe entity</returns>
        /// <returns code="400">tipZalbe already exists</returns>
        /// <returns code="500">server error</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddTipZalbe(TipZalbeDto tipZalbeDto)
        {
            if (tipZalbeRepository.GetTipZalbeIdByTipZalbe(tipZalbeDto.TipZalbe) != 0)
            {
                return BadRequest("tipZalbe already exists.");
            }

            tipZalbeRepository.AddTipZalbe(tipZalbeDto);

            try
            {
                if (!tipZalbeRepository.SaveChanges())
                {
                    throw new Exception("TipZalbe hasn't been created successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            // not returning Created because that would require a redundant endpoint
            return Ok("TipZalbe has been created.");
        }

        /// <summary>
        /// Endpoint for updating TipZalbe
        /// </summary>
        /// <param name="tipZalbe"></param>
        /// <returns code="200">tipZalbe entity</returns>
        /// <returns code="400">tipZalbe already exists</returns>
        /// <returns code="500">server error</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateTipZalbe(TipZalbe tipZalbe)
        {
            // If there is no entity in db, it can't be updated
            if (!tipZalbeRepository.Exists(tipZalbe.TipZalbeId))
            {
                return NotFound();
            }

            // Check if that tipZalbe already exists
            if (tipZalbeRepository.GetTipZalbeIdByTipZalbe(tipZalbe.TipZalbe1) != 0)
            {
                return BadRequest("TipZalbe already exists.");
            }

            tipZalbeRepository.UpdateTipZalbe(tipZalbe);

            try
            {
                if (!tipZalbeRepository.SaveChanges())
                {
                    throw new Exception("TipZalbe hasn't been updated successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("TipZalbe has been updated.");
        }

        /// <summary>
        /// Endpoint for deleting TipZalbe
        /// </summary>
        /// <param name="tipZalbeId"></param>
        /// <returns code="404">entity not found</returns>
        /// <returns code="500">server error</returns>
        [HttpDelete("{tipZalbeId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteTipZalbe(int tipZalbeId)
        {
            try
            {
                TipZalbe tipZalbe = tipZalbeRepository.GetTipZalbeById(tipZalbeId);

                if (tipZalbe == null)
                {
                    return NotFound();
                }

                tipZalbeRepository.DeleteTipZalbe(tipZalbe);

                if (!tipZalbeRepository.SaveChanges())
                {
                    throw new Exception("TipZalbe hasn't been deleted successfully.");
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }
        }


        /// <summary>
        /// Returns options for manipulating TipZalbe
        /// </summary>
        /// <returns>options for manipulating TipZalbe</returns>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetTipZalbeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
