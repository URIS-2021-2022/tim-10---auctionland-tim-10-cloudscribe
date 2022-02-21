using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class Zastupnik

    {
        /// <summary>
        /// Id zastupnika
        /// </summary>
        [Key]
        public Guid ZastupnikId { get; set; }

        /// <summary>
        /// Jmbg zastupnika
        /// </summary>
        public string Jmbg { get; set; }

        /// <summary>
        /// Broj pasosa
        /// </summary>
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Naziv drzave
        /// </summary>
        public string NazivDrzave { get; set; }

        /// <summary>
        /// Broj table za licitiranje
        /// </summary>
        public int BrojTable { get; set; }

        
        [ForeignKey("Kupac")]
        public Guid KupacId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<Kupac> Kupci { get; set; }
    }
}
