using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zalba.Entities
{
    public partial class TipZalbe
    {
        public TipZalbe()
        {
            Zalba = new HashSet<Zalba>();
        }

        public int TipZalbeId { get; set; }
        public string TipZalbe1 { get; set; }

        public virtual ICollection<Zalba> Zalba { get; set; }
    }
}
