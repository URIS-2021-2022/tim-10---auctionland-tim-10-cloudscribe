using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class KupacConfirmation
    {
        public Guid KupacId { get; set; }
        public string ImeKupca { get; set; }
        public string PrezimeKupca { get; set; }
       // public bool ImaZabranu { get; set; }
    }
}
