using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class Kupac 
    {
        /// <summary>
        /// Id kupca
        /// </summary>
        [Key]
        public Guid KupacId { get; set; }

        /// <summary>
        /// Datum pocetka zabrane kupca
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Datum prestanka zabrane kupca
        /// </summary>
        public DateTime? DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Duzina trajanja zabrane
        /// </summary>
        public int DuzinaTrajanjaZabrane { get; set; }

        /// <summary>
        /// Da li kupac ima zabranu
        /// </summary>
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Koliku povrsinu je ostvario kupac
        /// </summary>
        public int OstvarenaPovrsina { get; set; }

        /// <summary>
        /// Jedan kupac moze da ima vise zastupnika
        /// </summary>

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<Zastupnik> Zastupnici { get; set; }

    }
}
