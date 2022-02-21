using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UplataService.Entities
{
    /// <summary>
    /// Entity class for Kurs
    /// </summary>
    public partial class Kurs
    {
        /// <summary>
        /// Id of currency
        /// </summary>
        public int KursId { get; set; }

        /// <summary>
        /// Related date
        /// </summary>
        public DateTime? Datum { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Valuta { get; set; }

        /// <summary>
        /// Currency value
        /// </summary>
        public decimal? Vrednost { get; set; }
    }
}
