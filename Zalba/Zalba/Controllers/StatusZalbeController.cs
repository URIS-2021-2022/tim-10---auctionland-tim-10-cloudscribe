using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZalbaService.Data;
using ZalbaService.Entities;

namespace ZalbaService.Controllers
{
    /// <summary>
    /// Controller class for StatusZalbe
    /// </summary>
    [Authorize]
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
