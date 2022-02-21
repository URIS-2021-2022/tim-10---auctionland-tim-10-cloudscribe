using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Entities.TipDokumentaEntity
{
    public class TipDokumentaE
    {
        [Key]
        /// <summary>
        /// Id tipa dokumenta
        /// </summary>
        public Guid TipDokumentaID { get; set; }
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
