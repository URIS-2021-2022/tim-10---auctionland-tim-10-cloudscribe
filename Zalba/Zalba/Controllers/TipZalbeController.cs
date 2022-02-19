using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZalbaService.Data;
using ZalbaService.Entities;

namespace ZalbaService.Controllers
{
    /// <summary>
    /// Controller class for TipZalbe
    /// </summary>
    [Authorize]
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
