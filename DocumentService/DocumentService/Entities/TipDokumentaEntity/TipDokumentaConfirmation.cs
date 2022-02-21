using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Entities.TipDokumentaEntity
{
    public class TipDokumentaConfirmation
    {
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
