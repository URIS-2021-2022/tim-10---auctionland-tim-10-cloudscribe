using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zalba.Entities
{
    public partial class Zalba
    {
        public int ZalbaId { get; set; }
        public string RazlogZalbe { get; set; }
        public string Obrazlozenje { get; set; }
        public DateTime? DatumPodnosenja { get; set; }
        public DateTime? DatumResenja { get; set; }
        public string BrojResenja { get; set; }
        public string BrojOdluke { get; set; }
        public int? TipZalbeId { get; set; }
        public int? StatusZalbeId { get; set; }
        public int? RadnjaNaOsnovuZalbeId { get; set; }

        public virtual RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }
        public virtual StatusZalbe StatusZalbe { get; set; }
        public virtual TipZalbe TipZalbe { get; set; }
    }
}
