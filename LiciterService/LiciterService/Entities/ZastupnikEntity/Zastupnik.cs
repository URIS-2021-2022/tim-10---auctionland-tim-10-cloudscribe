using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class Zastupnik
    {
         
        public Guid ZastupnikId { get; set; }
        public string ImeZastupnika { get; set; }
        public string PrezimeZastupnika { get; set; }
        public int Jmbg { get; set; }
        public string Adresa { get; set; }
        public string NazivDrzave { get; set; }
        public int BrojTable { get; set; }

        
        [ForeignKey("Kupac")]
        public Guid KupacId { get; set; }
        public Kupac Kupac { get; set; }
    }
}
