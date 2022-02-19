using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UplataService.Data;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Controllers
{
    /// <summary>
    /// Controller class for Uplata
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository uplataRepository;

        /// <summary>
        /// Constructor which takes uplataRepository instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="uplataRepository">uplataRepository instance</param>
        public UplataController(IUplataRepository uplataRepository)
        {
            this.uplataRepository = uplataRepository;
        }

        /// <summary>
        /// Endpoint for retrieving all Uplatas from the Database
        /// </summary>
        /// <response code="200">List of Uplatas</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllUplatas()
        {
            return Ok(uplataRepository.GetAllUplatas());
        }

        /// <summary>
        /// Method that returns Uplata by its id
        /// </summary>
        /// <param name="uplataId">Id of Uplata</param>
        /// <returns code="200">Uplata entity</returns>
        /// <returns code="404">entity not found</returns>
        [HttpGet("{uplataId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUplataById(int uplataId)
        {
            Uplata uplata= uplataRepository.GetUplataById(uplataId);
            if (uplata == null)
            {
                return NotFound();
            }
            return Ok(uplata);
        }

        /// <summary>
        /// Endpoint for creating a Uplata
        /// </summary>
        /// <param name="uplataDto">DTO object containing required properties for Uplata entity</param>
        /// <returns code="200">Uplata entity</returns>
        /// <returns code="400">Uplata already exists</returns>
        /// <returns code="500">server error</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateUplata(UplataDto uplataDto)
        {
            uplataRepository.CreateUplata(uplataDto);

            try
            {
                if (!uplataRepository.SaveChanges())
                {
                    throw new Exception("Uplata hasn't been created successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");

            }

            // not returning Created because that would require a redundant endpoint
            return Ok("Uplata has been created.");

        }
    }
}
