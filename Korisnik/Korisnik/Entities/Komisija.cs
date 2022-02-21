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
        /// <summary>
        /// ID komisije
        /// </summary>
        [Key]
        public Guid KomisijaId { get; set; }
        /// <summary>
        /// Opis
        /// </summary>
        public string Opis { get; set; }
        
        
    }
}
