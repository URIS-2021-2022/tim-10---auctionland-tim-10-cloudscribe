using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models.TipDokumentaModel
{
    public class TipDokumentaUpdateDto
    {
        public Guid TipDokumentaID { get; set; }
        [Required (ErrorMessage ="Odabrati tip dokumenta!")]
        public string TipDokumenta { get; set; }
        public string StatusDokumenta { get; set; }
    }
}
