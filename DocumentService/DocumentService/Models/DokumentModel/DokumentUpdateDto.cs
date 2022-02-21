using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models.DokumentModel
{
    public class DokumentUpdateDto
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
        [Required(ErrorMessage = "Obavezno je uneti naziv dokumenta.")] 
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
    }
}
