using System;

namespace UplataService.Models
{
    /// <summary>
    /// DTO class which will be used for creation of Uplata entity
    /// </summary>
    public class UplataDto
    {
        /// <summary>
        /// Account number
        /// </summary>
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Reference number
        /// </summary>
        public string PozivNaBroj { get; set; }

        /// <summary>
        /// Amount of Uplata
        /// </summary>
        public decimal? Iznos { get; set; }

        /// <summary>
        /// Purpose of Uplata
        /// </summary>
        public string SvrhaUplate { get; set; }

        /// <summary>
        /// Date of Uplata
        /// </summary>
        public DateTime? Datum { get; set; }
    }
}
