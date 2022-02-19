using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models.TipDokumentaModel
{
    public class TipDokumentaConfirmationDto
    {
        public Guid TipDokumentaID { get; set; }
        public string TipDokumenta { get; set; }
        public string StatusDokumenta { get; set; }
    }
}
