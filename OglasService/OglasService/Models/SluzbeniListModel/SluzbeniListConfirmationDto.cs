using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class SluzbeniListConfirmationDto
    {
        /// <summary>
        /// ID sluzbeni list
        /// </summary>
        public Guid SluzbeniListId { get; set; }

        /// <summary>
        /// Opstina
        /// </summary>
        public string Opstina { get; set; }

        /// <summary>
        /// Broj sluzbenog lista
        /// </summary>
        public int BrojSluzbenogLista { get; set; }

        /// <summary>
        /// Datum izdavanja
        /// </summary>
        public DateTime? DatumIzdavanja { get; set; }
    }
}
