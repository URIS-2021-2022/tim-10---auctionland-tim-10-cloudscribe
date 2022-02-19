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
        [Key] 
        public Guid ZastupnikId { get; set; }
        public string Jmbg { get; set; }
        public string BrojPasosa { get; set; }
        public string NazivDrzave { get; set; }
        public int BrojTable { get; set; }

        
        [ForeignKey("Kupac")]
        public Guid KupacId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Kupac Kupac { get; set; }
    }
}
