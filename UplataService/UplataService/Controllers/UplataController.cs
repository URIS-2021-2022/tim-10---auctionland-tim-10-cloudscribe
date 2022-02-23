using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using UplataService.Data;
using UplataService.Entities;
using UplataService.Models;
using UplataService.ServiceCalls;

namespace UplataService.Controllers
{
    /// <summary>
    /// Controller class for Uplata
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository uplataRepository;
        private readonly IBankaUplataRepository bankaUplataRepository;
        private readonly ILiceService liceService;

        /// <summary>
        /// Constructor which takes uplataRepository instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="uplataRepository">uplataRepository instance</param>
        /// <param name="bankaUplataRepository">bankaUplataRepository instance</param>
        /// <param name="liceService">LiceService instance</param>
        public UplataController(IUplataRepository uplataRepository, IBankaUplataRepository bankaUplataRepository, ILiceService liceService)
        {
            this.uplataRepository = uplataRepository;
            this.bankaUplataRepository = bankaUplataRepository;
            this.liceService = liceService;

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
        /// <param name="brojNadmetanja">brojNadmetanja</param>
        /// <returns code="200">Uplata entity</returns>
        /// <returns code="500">server error</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RecordUplatas(int brojNadmetanja)
        {
            List<BankaUplata> bankaUplatas = bankaUplataRepository.GetAllUplatasByBrojNadmetanja(brojNadmetanja);

            // List of FizickoLiceDtos retrieved from LiceService
            List<FizickoLiceDto> fizickoLiceDtos = liceService.GetFizickaLica().Result;

            // List of PravnoLiceDtos retrieved from LiceService
            List<PravnoLiceDto> pravnoLiceDtos = liceService.GetPravnaLica().Result;

            // List of new Uplata entities which will be added to the database
            List<Uplata> newUplatas = uplataRepository.RecordUplatas(bankaUplatas, fizickoLiceDtos, pravnoLiceDtos, brojNadmetanja);

            uplataRepository.AddUplatas(newUplatas);

            try
            {
                uplataRepository.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");

            }

            // not returning Created because that would require a redundant endpoint
            return Ok("Uplatas have been recorded.");

        }
    }
}
