using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Entities
{
    //[Table("PravnoLice")]
    public class PravnoLiceEntity : LiceEntity
    {
        /// <summary>
        /// Naziv pravog lica
        /// </summary>
        public string naziv { get; set; }

        /// <summary>
        /// Broj faksa
        /// </summary>
        public int faks { get; set; }

        /// <summary>
        /// Matični broj pravnog lica
        /// </summary>
        public string maticniBroj { get; set; }

       
    }
}
