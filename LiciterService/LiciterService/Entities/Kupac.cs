using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class Kupac
    {
        public Guid KupacId { get; set; }
        public DateTime? DatumPocetkaZabrane { get; set; }
        public DateTime? DatumPrestankaZabrane { get; set; }
        public bool ImaZabranu { get; set; }
        public int OstvarenaPovrsina { get; set; }
        public int Uplate { get; set; }
        public string Prioritet { get; set; }
        public string Lice { get; set; }
        public int JavnaNadmetanja { get; set; }
    }
}
