using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models
{
    public class DokumentConfirmationDto
    {
        public Guid DokumentID { get; set; }
        public string ZavodniBroj { get; set; }
        public string NazivDokumenta { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumDonosenjaOdluke { get; set; }
        public bool Sablon { get; set; }

      
    }
}
