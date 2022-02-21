using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacDto 
    {
        /// <summary>
        /// KupacId
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

        /// <summary>
        /// Duzina trajanja zabrane
        /// </summary>
        public int DuzinaTrajanjaZabrane { get; set; }

        /// <summary>
        /// Ima zabranu 
        /// </summary>
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Ostvarena povrsina
        /// </summary>
        public int OstvarenaPovrsina { get; set; }   

        /// <summary>
        /// ID zastupnika
        /// </summary>
        public Guid ZastupnikId { get; set; }
        


    }
}
