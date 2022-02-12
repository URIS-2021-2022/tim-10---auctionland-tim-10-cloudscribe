using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Models.FizickoLice
{
    public class FizickoLiceCreationDto
    {
        [Required(ErrorMessage = "Obavezno je uneti broj telefona.")]
        /// <summary>
        /// Prvi broj telefona lica
        /// </summary>
        public string brojTelefona1 { get; set; }

        /// <summary>
        /// Drugi broj telefona lica
        /// </summary>
        public string brojTelefona2 { get; set; }

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


        [Required(ErrorMessage = "Obavezno je uneti ime.")]
        /// <summary>
        /// Ime fizickog lica
        /// </summary>
        public string ime { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti prezime.")]
        /// <summary>
        /// Prezime fizickog lica
        /// </summary>
        /// 
        public string prezime { get; set; }
    }
}
