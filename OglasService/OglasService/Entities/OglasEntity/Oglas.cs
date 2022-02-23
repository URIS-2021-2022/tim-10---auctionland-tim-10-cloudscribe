using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Entities
{
    public class Oglas
    {
        /// <summary>
        /// ID oglas
        /// </summary>
        [Key]
        public Guid OglasId { get; set; }

        /// <summary>
        /// Tekst oglasa
        /// </summary>
        public string TekstOglasa { get; set; }

        public Guid javnoNadmetanjeID { get; set; }

        /// <summary>
        /// ID sluzbenog lista
        /// </summary>
        [ForeignKey("SluzbeniList")]
        public Guid SluzbeniListId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual SluzbeniList SluzbeniList { get; set; }

    }
}
