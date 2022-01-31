using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZalbaController : ControllerBase
    {
        private ITipZalbeRepository tipZalbeRepository { get; }

        private IStatusZalbeRepository statusZalbeRepository { get; }
        private IZalbaRepository zalbaRepository { get; }

        public ZalbaController(IStatusZalbeRepository statusZalbeRepository, IZalbaRepository zalbaRepository, ITipZalbeRepository tipZalbeRepository)
        {
            this.statusZalbeRepository = statusZalbeRepository;
            this.zalbaRepository = zalbaRepository;
            this.tipZalbeRepository = tipZalbeRepository;
        }

        [HttpPost]
        public IActionResult CreateZalba(ZalbaDto zalbaDto)
        {
            if ((zalbaDto.BrojOdluke == null && zalbaDto.BrojResenja == null) || (zalbaDto.BrojOdluke != null && zalbaDto.BrojResenja != null))
            {
                return BadRequest("Either brojOdluke or brojResenja have to be populated.");
            }

            if (zalbaDto.BrojResenja != null && zalbaDto.DatumResenja == DateTime.MinValue)
            {
                return BadRequest("If brojResenja is populated, datumResenja has to be populated as well.");
            }

            var test = DateTime.Now;

            if (!tipZalbeRepository.Exists(zalbaDto.TipZalbeId))
            {
                return BadRequest("There is no TipZalbe with given TipZalbeId");
            }

            int statusZalbeId = statusZalbeRepository.GetStatusZalbeIdByStatusZalbe("Otvorena");

            if (statusZalbeId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            zalbaRepository.AddZalba(zalbaDto, statusZalbeId);

            try
            {
                if (!zalbaRepository.SaveChanges())
                {
                    throw new Exception("Error has occured during the creation of Zalba.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            // not returning Created because that would require a redundant endpoint
            return Ok("Zalba has been created.");

        }
    }
}
