using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Models.PravnoLice
{
    public class PravnoLiceCreationDto
    {
        [Required(ErrorMessage = "Obavezno je uneti broj telefona.")]
        /// <summary>
        /// Prvi broj telefona lica
        /// </summary>
        public int brojTelefona1 { get; set; }

        /// <summary>
        /// Drugi broj telefona lica
        /// </summary>
        public int brojTelefona2 { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti email adresu.")]
        /// <summary>
        /// Email adresa lica
        /// </summary>
        public string email { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti broj racuna.")]
        /// <summary>
        /// Broj racuna lica
        /// </summary>
        public string brojRacuna { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv.")]
        /// <summary>
        /// Naziv pravog lica
        /// </summary>
        public string naziv { get; set; }


        [Required(ErrorMessage = "Obavezno je uneti broj faksa.")]
        /// <summary>
        /// Broj faksa
        /// </summary>
        public int faks { get; set; }
    }
}
