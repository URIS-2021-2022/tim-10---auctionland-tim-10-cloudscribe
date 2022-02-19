using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UplataService.Data;
using UplataService.Entities;

namespace UplataService.Controllers
{
    /// <summary>
    /// Controller class for Kurs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class KursController : ControllerBase
    {
        private readonly IKursRepository kursRepository;

        /// <summary>
        /// Constructor which takes kursRepository instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="kursRepository">kursRepository instance</param>
        public KursController(IKursRepository kursRepository)
        {
            this.kursRepository = kursRepository;
        }

        /// <summary>
        /// Endpoint for retrieving all Kurses from the Database
        /// </summary>
        /// <response code="200">List of Kurses</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllKurses()
        {
            return Ok(kursRepository.GetAllKurses());
        }

        /// <summary>
        /// Method that returns Kurs by its id
        /// </summary>
        /// <param name="kursId">Id of Kurs</param>
        /// <returns code="200">Kurs entity</returns>
        /// <returns code="404">entity not found</returns>
        [HttpGet("{kursId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetKursById(int kursId)
        {
            Kurs kurs = kursRepository.GetKursById(kursId);
            if (kurs == null)
            {
                return NotFound();
            }
            return Ok(kurs);
        }
    }
}
