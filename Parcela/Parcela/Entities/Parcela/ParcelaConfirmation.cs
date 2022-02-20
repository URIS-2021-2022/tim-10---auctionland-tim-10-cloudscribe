using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities.Parcela
{
    public class ParcelaConfirmation
    {
        /// <summary>
        /// ID parcele
        /// </summary>
        public Guid ParcelaId { get; set; }

        /// <summary>
        /// Broj parcele
        /// </summary>
        public string BrojParcele { get; set; }
    }
}
