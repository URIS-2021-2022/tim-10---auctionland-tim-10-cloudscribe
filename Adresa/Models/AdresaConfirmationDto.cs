using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Models
{
    public class AdresaConfirmationDto
    {
        public Guid AdresaId { get; set; }

        public string UlicaBroj { get; set; }

        public string Mesto { get; set; }

        public int PostanskiBroj { get; set; }

        //public Guid DrzavaId { get; set; }

        public string NazivDrzave { get; set; }

    }
}
