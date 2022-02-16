using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Models
{
    public class AdresaCreationDto
    {
        /// <summary>
        /// Naziv ulice
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv ulice.")]
        public string Ulica { get; set; }

        /// <summary>
        /// Broj adrese u ulici
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj.")]
        public string Broj { get; set; }

        /// <summary>
        /// Mesto adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti mesto.")]
        public string Mesto { get; set; }

        /// <summary>
        /// Poštanski broj adrese
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti poštanski broj.")]
        public int PostanskiBroj { get; set; }

        /// <summary>
        /// ID države
        /// </summary>
        public Guid DrzavaId { get; set; }
        
        //public string NazivDrzave { get; set; }

      
    }
}
