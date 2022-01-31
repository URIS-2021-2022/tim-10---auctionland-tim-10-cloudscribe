using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Models
{
    public class AdresaUpdateDto
    {
        public Guid AdresaId { get; set; }

        //[Required(ErrorMessage = "Obavezno je uneti naziv ulice.")]
        public string Ulica { get; set; }

        public string Broj { get; set; }

        public string Mesto { get; set; }

        //[MaxLength(7)]
        public int PostanskiBroj { get; set; }

        public Guid DrzavaId { get; set; }

        public string NazivDrzave { get; set; }
    }
}
