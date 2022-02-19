using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Entities.TipDokumentaEntity
{
    public class TipDokumentaConfirmation
    {
        public Guid TipDokumentaID { get; set; }
        public string TipDokumenta { get; set; }
        public string StatusDokumenta { get; set; }
    }
}
