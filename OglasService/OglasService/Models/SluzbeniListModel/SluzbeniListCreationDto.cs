using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class SluzbeniListCreationDto
    {
        /// <summary>
        /// Opstina
        /// </summary>
        public string Opstina { get; set; }

        /// <summary>
        /// Broj sluzbenog lista
        /// </summary>
        public int BrojSluzbenogLista { get; set; }

        /// <summary>
        /// Datum izdavanja sluzbenog lista
        /// </summary>
        public DateTime? DatumIzdavanja { get; set; }
    }
}
