using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models.Zastupnik
{
    public class ZastupnikCreationDto
    {
        public Guid ZastupnikId { get; set; }
        public string ImeZastupnika { get; set; }
        public string PrezimeZastupnika { get; set; }
        public int Jmbg { get; set; }
        public string Adresa { get; set; }
        public string NazivDrzave { get; set; }
        public int BrojTable { get; set; }
    }
}
