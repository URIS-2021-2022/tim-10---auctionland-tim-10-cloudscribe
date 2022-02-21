using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UplataService.Entities
{
    /// <summary>
    /// Entity class for BankaUplata
    /// </summary>
    public partial class BankaUplata
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BankaUplata()
        {
            BankaIzvod = new HashSet<BankaIzvod>();
        }

        /// <summary>
        /// Id of BankaUplata
        /// </summary>
        public int BankaUplataId { get; set; }

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
        /// List of BankaIzvod's which are connected to BankaUplata entity
        /// </summary>
        public virtual ICollection<BankaIzvod> BankaIzvod { get; set; }
    }
}
