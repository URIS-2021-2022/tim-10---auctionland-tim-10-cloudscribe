using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Models
{
    public class JavnoNadmetanjeDto
    {
        public Guid javnoNadmetanjeID { get; set; }
        public string tipJavnogNadmetanja { get; set; }
        public DateTime datum { get; set; }
        public DateTime vremePocetka { get; set; }
        public DateTime vremeKraja { get; set; }
        public int pocetnaCena { get; set; }
        public bool izuzetno { get; set; }
        public int izlicitiranaCena { get; set; }
        public string najboljiPonudjac { get; set; }
        public string adresa { get; set; }
        public string periodZakupa { get; set; }
        public int brojUcesnika { get; set; }
        public int visinaDopuneDepozita { get; set; }
        public int krug { get; set; }

    }
}
