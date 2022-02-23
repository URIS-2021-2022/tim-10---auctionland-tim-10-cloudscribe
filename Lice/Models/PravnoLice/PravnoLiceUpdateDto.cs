using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Models.PravnoLice
{
    public class PravnoLiceUpdateDto
    {
        /// <summary>
        /// ID Lica
        /// </summary>
        public Guid liceId { get; set; }
        
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
        /// Naziv pravog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv.")]
        public string naziv { get; set; }

        /// <summary>
        /// Broj faksa
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj faksa.")]
        public int faks { get; set; }

        /// <summary>
        /// Matični broj pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti matični broj.")]
        public string maticniBroj { get; set; }
    }
}
