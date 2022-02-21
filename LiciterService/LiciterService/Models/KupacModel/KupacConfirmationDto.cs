using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacConfirmationDto
    {
        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid KupacId { get; set; }

        /// <summary>
        /// Datum pocetka zabrane
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        public DateTime? DatumPrestankaZabrane { get; set; }

    }
}
