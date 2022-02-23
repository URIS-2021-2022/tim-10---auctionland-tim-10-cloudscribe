using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Models
{
    public class DokumentDto
    {
        /// <summary>
        /// Id dokumenta
        /// </summary>
        public Guid DokumentID { get; set; }

        /// <summary>
        /// Naziv dokumenta
        /// </summary>
        public string NazivDokumenta { get; set; }
        /// <summary>
        /// Datum 
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Sablon dokumenta
        /// </summary>
        public bool Sablon { get; set; }

    }
}
