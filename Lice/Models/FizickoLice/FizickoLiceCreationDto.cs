using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Models.FizickoLice
{
    public class FizickoLiceCreationDto
    {

        /// <summary>
        /// Prvi broj telefona lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona.")]
        public string brojTelefona1 { get; set; }

        /// <summary>
        /// Drugi broj telefona lica
        /// </summary>
        public string brojTelefona2 { get; set; }

        /// <summary>
        /// Email adresa lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti email adresu.")]
        public string email { get; set; }

        /// <summary>
        /// Broj racuna lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj racuna.")]
        public string brojRacuna { get; set; }

        /// <summary>
        /// ID prioriteta
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID prioriteta.")]
        public Guid prioritetId { get; set; }


        /// <summary>
        /// Ime fizickog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ime.")]
        public string ime { get; set; }

        /// <summary>
        /// Prezime fizickog lica
        /// </summary>
        /// 
        [Required(ErrorMessage = "Obavezno je uneti prezime.")]
        public string prezime { get; set; }
    }
}
