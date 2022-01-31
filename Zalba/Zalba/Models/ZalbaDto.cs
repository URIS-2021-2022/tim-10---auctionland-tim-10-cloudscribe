using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Models
{
    public class ZalbaDto
    {
        [Required(ErrorMessage ="RazlogZalbe has to be populated.")]
        public string RazlogZalbe { get; set; }
        [Required(ErrorMessage = "Obrazlozenje has to be populated.")]
        public string Obrazlozenje { get; set; }
        public DateTime DatumResenja { get; set; }
        public string BrojResenja { get; set; }
        public string BrojOdluke { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="TipZalbeId has to be greater than 0.")]
        public int TipZalbeId { get; set; }
    }
}
