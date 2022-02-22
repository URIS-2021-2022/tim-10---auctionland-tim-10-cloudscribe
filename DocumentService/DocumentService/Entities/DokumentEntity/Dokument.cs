using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Entities
{
    public class Dokument
    {
        /// <summary>
        /// Id dokumenta
        /// </summary>
        public Guid DokumentID { get; set; }
        /// <summary>
        /// Zavodni broj dokumenta
        /// </summary>
        public string ZavodniBroj { get; set; }
        /// <summary>
        /// Naziv dokumenta
        /// </summary>
        public string NazivDokumenta { get; set; }
        /// <summary>
        /// Datum 
        /// </summary>
        public DateTime Datum { get; set; }
        /// <summary>
        /// Datum donosenja odluke za dokument
        /// </summary>
        public DateTime DatumDonosenjaOdluke { get; set; }
        /// <summary>
        /// Sablon dokumenta
        /// </summary>
        public bool Sablon { get; set; }

        
        public Guid TipId { get; set; }
    }
}
