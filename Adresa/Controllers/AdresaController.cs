using Adresa.Data;
using Adresa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Controllers
{
    [ApiController]
    [Route("api/adrese")]
    public class AdresaController : ControllerBase
    {
        private readonly IAdresaRepository adresaRepository;
        private readonly LinkGenerator linkGenerator;

        public AdresaController(IAdresaRepository adresaRepository, LinkGenerator linkGenerator)
        {
            this.adresaRepository = adresaRepository;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<AdresaModel>> GetAdrese()
        {
            var adrese = adresaRepository.GetAdrese();
            if(adrese == null || adrese.Count == 0)
            {
                return NoContent();
            }
                return Ok(adrese);
                 
        }

        [HttpGet("{adresaId}")]
        public ActionResult<AdresaModel> GetAdresa(Guid adresaId)
        {
            var adresa = adresaRepository.GetAdresaById(adresaId);

            if(adresa == null)
            {
                return NotFound();
            }
            return Ok(adresa);
        }

        [HttpPost]
        public ActionResult<AdresaModel> CreateAdresa([FromBody] AdresaModel adresa) 
        {
            try
            {
                AdresaModel a = adresaRepository.CreateAdresa(adresa);
                string location = linkGenerator.GetPathByAction("GetAdresa", "Adresa", new { AdresaId = a.AdresaId });
                return Created(location, a);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");

            }
        }

        [HttpPut]


        [HttpDelete("{adresaId}")]
        public IActionResult DeleteAdresa(Guid adresaId)
        {
            try
            {
                var adresa = adresaRepository.GetAdresaById(adresaId);

                if(adresa == null)
                {
                    return NotFound();
                }
                adresaRepository.DeleteAdresa(adresaId);
                return NoContent();

            } catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
    }
}
