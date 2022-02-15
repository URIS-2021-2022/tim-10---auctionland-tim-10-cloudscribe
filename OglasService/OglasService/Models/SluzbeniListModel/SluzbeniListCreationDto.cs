using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class SluzbeniListCreationDto
    {
        public string Opstina { get; set; }
        public int BrojSluzbenogLista { get; set; }
        public DateTime? DatumIzdavanja { get; set; }
    }
}
