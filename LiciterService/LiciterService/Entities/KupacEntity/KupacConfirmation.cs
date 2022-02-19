using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class KupacConfirmation
    {
        public Guid KupacId { get; set; }

        public DateTime? DatumPocetkaZabrane { get; set; }

        public DateTime? DatumPrestankaZabrane { get; set; }

    }
}
