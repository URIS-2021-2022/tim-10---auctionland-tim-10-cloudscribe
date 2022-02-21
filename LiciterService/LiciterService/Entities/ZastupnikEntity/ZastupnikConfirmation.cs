using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class ZastupnikConfirmation
    {
        /// <summary>
        /// ID zastupnika
        /// </summary>
        public Guid ZastupnikId { get; set; }

        /// <summary>
        /// Jmbg zastupnika
        /// </summary>
        public string Jmbg { get; set; }

        /// <summary>
        /// Borj pasosa
        /// </summary>
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Naziv drzave
        /// </summary>
        public string NazivDrzave { get; set; }
    }
}
