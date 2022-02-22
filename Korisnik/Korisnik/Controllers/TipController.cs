using AutoMapper;
using Korisnik.Data;
using Korisnik.Entities;
using Korisnik.Models;
using Korisnik.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Controllers
{
    [ApiController]
    [Route("api/tip")]
    [Produces("application/json", "application/xml")] //Sve akcije kontrolera mogu da vraćaju definisane formate
    [Authorize(Roles = "Administrator")]
    public class TipController : ControllerBase
    {
        private readonly ITipRepository tipRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;
        private readonly LoggerDto loggerDto;

        private readonly IMapper mapper;
        public TipController(ITipRepository tipRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.tipRepository = tipRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
            loggerDto = new LoggerDto();
            loggerDto.ServiceName = "KORISNIK";
        }

        /// <summary>
        /// Vraća sve tipove
        /// </summary>

        /// <returns>Lista tipova</returns>
        /// <response code="200">Vraća listu tipova</response>
        /// <response code="404">Nije pronan ni jedan tip</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)] //Eksplicitno definišemo šta sve može ova akcija da vrati
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<TipDto>> GetTipovi()
        {
            loggerDto.HttpMethod = "GET";
            List<Tip> tipovi = tipRepository.GetTip();
            if (tipovi == null || tipovi.Count == 0)
            {
                loggerDto.Response = "204 NO CONTENT";
                loggerService.CreateLog(loggerDto);
                return NoContent();

            }
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<List<TipDto>>(tipovi));
        }

        /// <summary>
        /// Vraća jednog tipa na osnovu njegovog ID-ja
        /// </summary>
        /// <param name="tipId">ID tipa</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženi tip</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet("{tipId}")]
        public ActionResult<TipDto> GetTip(Guid tipId)
        {
            loggerDto.HttpMethod = "GET";
            Tip tipModel = tipRepository.GetTipById(tipId);
            if (tipModel == null)
            {
                loggerDto.Response = "404 NOT FOUND";
                loggerService.CreateLog(loggerDto);
                return NotFound();
            }
            loggerDto.Response = "200 OK";
            loggerService.CreateLog(loggerDto);
            return Ok(mapper.Map<TipDto>(tipModel));
        }

       
    }


}
