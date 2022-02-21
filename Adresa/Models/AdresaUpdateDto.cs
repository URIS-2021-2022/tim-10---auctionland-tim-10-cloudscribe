using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Models
{
    public class AdresaUpdateDto
    {
        /// <summary>
        /// ID adrese
        /// </summary>
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Ulica adresde
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv ulice.")]
        public string Ulica { get; set; }

        /// <summary>
        /// Broj u ulici
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj adrese.")]
        public string Broj { get; set; }

        /// <summary>
        /// Mesto adreee
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti mesto adrese.")]
        public string Mesto { get; set; }

        /// <summary>
        /// Postanški broj adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti poštanski broj.")]
        public int PostanskiBroj { get; set; }

        /// <summary>
        /// ID drzave
        /// </summary>
        public Guid DrzavaId { get; set; }

        //public string NazivDrzave { get; set; }
    }
}
