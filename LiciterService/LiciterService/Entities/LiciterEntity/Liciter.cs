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
        [Key]
        public Guid LiciterId { get; set; }
        //public string ImeLicitera { get; set; }
        //public string PrezimeLicitera { get; set; }
        // public Kupac Kupac { get; set; }
        //public Zastupnik Zastupnik { get; set; }

       
        [ForeignKey("Zastupnik")]
        public Guid? ZastupnikId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Zastupnik Zastupnik { get; set; }


        [ForeignKey("Kupac")]
        public Guid? KupacId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Kupac Kupac { get; set; }


    }
}
