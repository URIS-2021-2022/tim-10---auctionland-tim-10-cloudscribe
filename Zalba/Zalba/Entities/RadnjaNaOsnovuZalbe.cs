using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ZalbaService.Entities
{
    public partial class RadnjaNaOsnovuZalbe
    {
        public RadnjaNaOsnovuZalbe()
        {
            Zalba = new HashSet<Zalba>();
        }

        public int RadnjaNaOsnovuZalbeId { get; set; }
        public string RadnjaNaOsnovuZalbe1 { get; set; }

        public virtual ICollection<Zalba> Zalba { get; set; }
    }
}
