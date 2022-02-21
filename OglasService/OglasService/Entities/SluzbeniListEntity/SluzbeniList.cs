using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Entities
{
    public class SluzbeniList
    {
        /// <summary>
        /// ID sluzbeni list 
        /// </summary>
        [Key]
        public Guid SluzbeniListId { get; set; }

        /// <summary>
        /// Naziv opstine
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
