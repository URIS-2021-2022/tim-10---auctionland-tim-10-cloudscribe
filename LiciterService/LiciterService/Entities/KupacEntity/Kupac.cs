using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class Kupac 
    {
        public Kupac()
        {
            Zastupnici = new HashSet<Zastupnik>();
        }
        public Guid KupacId { get; set; }
        public string ImeKupca { get; set; }
        public string PrezimeKupca { get; set; }
        public DateTime? DatumPocetkaZabrane { get; set; }
        public DateTime? DatumPrestankaZabrane { get; set; }
        public int DuzinaTrajanjaZabrane { get; set; }
        public bool ImaZabranu { get; set; }
        public int OstvarenaPovrsina { get; set; }
        //public int Uplata { get; set; }
        //public string Lice { get; set; }
        //public int JavnaNadmetanja { get; set; }

        //Jedan kupac moze da ima vise zastupnika
        public virtual ICollection<Zastupnik> Zastupnici { get; set; }

    }
}
