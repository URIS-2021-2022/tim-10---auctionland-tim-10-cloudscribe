using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UplataService.Entities
{
    public partial class BankaIzvod
    {
        public int IzvodId { get; set; }
        public string Jmbg { get; set; }
        public string Pib { get; set; }
        public int? BankaUplataId { get; set; }

        public virtual BankaUplata BankaUplata { get; set; }
    }
}
