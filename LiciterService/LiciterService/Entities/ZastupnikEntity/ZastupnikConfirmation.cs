using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class ZastupnikConfirmation
    {
        public Guid ZastupnikId { get; set; }
        public string Jmbg { get; set; }
        public string BrojPasosa { get; set; }
        public string NazivDrzave { get; set; }
    }
}
