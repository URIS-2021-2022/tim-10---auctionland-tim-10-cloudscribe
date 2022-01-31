using Adresa.Data;
using Adresa.Entities;
using Adresa.Models;
using AutoMapper;
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
        private readonly IMapper mapper;

        public AdresaController(IAdresaRepository adresaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.adresaRepository = adresaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<List<AdresaDto>> GetAdrese()
        {
            var adrese = adresaRepository.GetAdrese();
            if(adrese == null || adrese.Count == 0)
            {
                return NoContent();
            }
                return Ok(mapper.Map<List<AdresaDto>>(adrese));
                 
        }

        [HttpGet("{adresaId}")]
        public ActionResult<AdresaDto> GetAdresa(Guid adresaId)
        {
            var adresa = adresaRepository.GetAdresaById(adresaId);

            if(adresa == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AdresaConfirmationDto>(adresa));
        }

        [HttpPost]
        public ActionResult<AdresaConfirmationDto> CreateAdresa([FromBody] AdresaCreationDto adresa) 
        {
            try
            {
                AdresaEntity adresaEntity = mapper.Map<AdresaEntity>(adresa);

                var conf = adresaRepository.CreateAdresa(adresaEntity);

                string location = linkGenerator.GetPathByAction("GetAdresa", "Adresa", new { AdresaId = conf.AdresaId });
                return Created(location, mapper.Map<AdresaConfirmationDto>(conf));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");

            }
        }

        [HttpPut]
        public ActionResult<AdresaConfirmationDto> UpdateAdresa([FromBody] AdresaUpdateDto adresa)
        {
            try
            {
                if(adresaRepository.GetAdresaById(adresa.AdresaId) == null)
                {
                    return NotFound();
                }

                AdresaEntity adresaEntity = mapper.Map<AdresaEntity>(adresa);
                Console.WriteLine(adresaEntity.Broj);
                var conf = adresaRepository.UpdateAdresa(adresaEntity);
                return Ok(mapper.Map<AdresaConfirmationDto>(conf));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");

            }
        }


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

        [HttpOptions]
        public IActionResult GetAdresaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
