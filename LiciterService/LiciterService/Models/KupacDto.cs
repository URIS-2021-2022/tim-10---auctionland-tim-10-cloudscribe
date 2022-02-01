﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacDto
    {
        public Guid KupacId { get; set; }
        public DateTime? DatumPocetkaZabrane { get; set; }
        public DateTime? DatumPrestankaZabrane { get; set; }
        public int DuzinaTrajanjaZabrane { get; set; }
        public bool ImaZabranu { get; set; }
        public int OstvarenaPovrsina { get; set; }
        //public int Uplate { get; set; }
        //public string Lice { get; set; }
        //public int JavnaNadmetanja { get; set; }

        //Zastupnik moze da ima vise kupaca
        //public virtual ICollection<Zastupnik> Zastupnik { get; set; }
    }
}
