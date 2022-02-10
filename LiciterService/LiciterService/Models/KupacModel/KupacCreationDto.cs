using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacCreationDto
    {
        public Guid KupacId { get; set; }
        public string ImeKupca { get; set; }
        public string PrezimeKupca { get; set; }
        public DateTime? DatumPocetkaZabrane { get; set; }
        public DateTime? DatumPrestankaZabrane { get; set; }
        public int DuzinaTrajanjaZabrane { get; set; }
        public bool ImaZabranu { get; set; }
        public int OstvarenaPovrsina { get; set; }
    }
}
