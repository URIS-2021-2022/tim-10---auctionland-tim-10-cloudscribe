using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Entities
{
    public class AdresaEntity
    {
        /// <summary>
        /// ID adrese
        /// </summary>
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Ulica adrese
        /// </summary>
        public string Ulica { get; set; }

        /// <summary>
        /// Broj adrese
        /// </summary>
        public string Broj { get; set; }

        /// <summary>
        /// Mesto adrese
        /// </summary>
        public string Mesto { get; set; }

        /// <summary>
        /// Poštanski broj adrese
        /// </summary>
        public int PostanskiBroj { get; set; }

        /// <summary>
        /// ID države
        /// </summary>
        public Guid DrzavaId { get; set; }

        /// <summary>
        /// Naziv države
        /// </summary>
        public string NazivDrzave { get; set; }
    }
}
