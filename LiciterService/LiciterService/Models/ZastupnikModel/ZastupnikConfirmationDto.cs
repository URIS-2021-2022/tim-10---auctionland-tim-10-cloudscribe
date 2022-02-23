using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class ZastupnikConfirmationDto
    {
        /// <summary>
        /// ID zastupnika
        /// </summary>
        public Guid ZastupnikId { get; set; }

        /// <summary>
        /// JMBG zastupnika
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

        public Guid AdresaId { get; set; }

        [NotMapped]
        public AdresaZastupnikDto Adresa { get; set; }
    }
}
