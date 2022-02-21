using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models.TipDokumentaModel
{
    public class TipDokumentaUpdateDto
    {
        /// <summary>
        /// Id tipa dokumenta
        /// </summary>
        public Guid TipDokumentaID { get; set; }
        [Required (ErrorMessage ="Odabrati tip dokumenta!")]
        /// <summary>
        /// Tip dokumenta
        /// </summary>
        public string TipDokumenta { get; set; }
        /// <summary>
        /// Status dokumenta
        /// </summary>
        public string StatusDokumenta { get; set; }
    }
}
