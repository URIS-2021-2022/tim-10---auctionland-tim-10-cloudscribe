using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UplataService.Entities
{
    /// <summary>
    /// Entity class for Uplata
    /// </summary>
    public partial class Uplata
    {
        /// <summary>
        /// If of Uplata
        /// </summary>
        public int UplataId { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Reference number
        /// </summary>
        public string PozivNaBroj { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal? Iznos { get; set; }

        /// <summary>
        /// Purpose of payment
        /// </summary>
        public string SvrhaUplate { get; set; }

        /// <summary>
        /// Date of payment
        /// </summary>
        public DateTime? Datum { get; set; }

        /// <summary>
        /// If payment is not connected to person
        /// </summary>
        public bool VisecaUplata { get; set; }

        /// <summary>
        /// Id of JavnoNadmetanje
        /// </summary>
        public int JavnoNadmetanjeId { get; set; }

        /// <summary>
        /// Id of Uplatilac
        /// </summary>
        public int UplatilacId { get; set; }
    }
}
