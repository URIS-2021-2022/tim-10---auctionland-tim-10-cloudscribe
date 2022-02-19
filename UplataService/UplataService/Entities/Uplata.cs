using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UplataService.Entities
{
    public partial class Uplata
    {
        public int UplataId { get; set; }
        public string BrojRacuna { get; set; }
        public string PozivNaBroj { get; set; }
        public decimal? Iznos { get; set; }
        public string SvrhaUplate { get; set; }
        public DateTime? Datum { get; set; }
    }
}
