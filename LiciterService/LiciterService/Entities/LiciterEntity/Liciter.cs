using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class Liciter
    {
        /// <summary>
        /// ID licitera
        /// </summary>
        [Key]
        public Guid LiciterId { get; set; }

        /// <summary>
        /// ID zastupnika 
        /// </summary>

        [ForeignKey("Zastupnik")]
        public Guid? ZastupnikId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Zastupnik Zastupnik { get; set; }

        public Guid liceId { get; set; }

        /// <summary>
        /// ID kupca
        /// </summary>
        [ForeignKey("Kupac")]
        public Guid? KupacId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Kupac Kupac { get; set; }


    }
}
