using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models.DokumentModel
{
    public class DokumentUpdateDto
    {
        
        public Guid DokumentID { get; set; }
        
        public string ZavodniBroj { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv dokumenta.")] 
        public string NazivDokumenta { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumDonosenjaOdluke { get; set; }
        public bool Sablon { get; set; }
    }
}
