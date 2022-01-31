using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Entities
{
    public class AdresaEntity
    {
        public Guid AdresaId { get; set; }

        public string Ulica { get; set; }

        public string Broj { get; set; }

        public string Mesto { get; set; }

        public int PostanskiBroj { get; set; }

        public Guid DrzavaId { get; set; }

        public string NazivDrzave { get; set; }
    }
}
