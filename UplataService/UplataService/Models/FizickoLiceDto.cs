using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Models
{
    /// <summary>
    /// DTO class for FizickoLice entity
    /// </summary>
    public class FizickoLiceDto
    {

        /// <summary>
        /// Prvi broj telefona lica
        /// </summary>
        public string brojTelefona1 { get; set; }

        /// <summary>
        /// Drugi broj telefona lica
        /// </summary>
        public string brojTelefona2 { get; set; }

        /// <summary>
        /// Email adresa lica
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Opis prioriteta lica
        /// </summary>
        public string opisPrioriteta { get; set; }

        /// <summary>
        /// Broj racuna lica
        /// </summary>
        public string brojRacuna { get; set; }

        /// <summary>
        /// Ime i prezime fizickog lica
        /// </summary>
        public string ImePrezime { get; set; }

        /// <summary>
        /// JMBG lica
        /// </summary>
        public string JMBG { get; set; }

    }
}
