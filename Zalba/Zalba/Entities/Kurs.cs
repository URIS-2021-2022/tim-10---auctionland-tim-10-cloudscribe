using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zalba.Entities
{
    public partial class Kurs
    {
        public int KursId { get; set; }
        public DateTime? Datum { get; set; }
        public string Valuta { get; set; }
        public decimal? Vrednost { get; set; }
    }
}
