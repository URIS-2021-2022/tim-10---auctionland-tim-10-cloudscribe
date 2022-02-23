using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Entities
{
    //[Table("FizickoLice")]
    public class FizickoLiceEntity : LiceEntity
    {
        /// <summary>
        /// Ime fizickog lica
        /// </summary>
        public string ime { get; set; }

        /// <summary>
        /// Prezime fizickog lica
        /// </summary>
        /// 
        public string prezime { get; set; }

        /// <summary>
        /// JMBG lica
        /// </summary>
        public string JMBG { get; set; }


    }
}
