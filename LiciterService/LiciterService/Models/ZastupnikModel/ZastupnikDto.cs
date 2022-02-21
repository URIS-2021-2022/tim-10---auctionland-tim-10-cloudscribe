using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class ZastupnikDto
    {
        /// <summary>
        /// Zastupnik id
        /// </summary>
        public Guid ZastupnikId { get; set; }

        /// <summary>
        /// Jmbg zastupnika
        /// </summary>
        public string Jmbg { get; set; }

        /// <summary>
        /// Broj pasosa
        /// </summary>
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Naziv drzave
        /// </summary>
        public string NazivDrzave { get; set; }

        /// <summary>
        /// Broj table za licitaciju
        /// </summary>
        public int BrojTable { get; set; }

        /// <summary>
        /// Zastupnik moze da ima vise kupaca
        /// </summary>
        public virtual List<Kupac> Kupci { get; set; }


    }
}
