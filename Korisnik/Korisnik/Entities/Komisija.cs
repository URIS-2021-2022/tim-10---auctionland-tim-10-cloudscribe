using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Entities
{
    public class Komisija
    {
        [Key]
        public Guid KomisijaId { get; set; }
        public string Opis { get; set; }
        
        
    }
}
