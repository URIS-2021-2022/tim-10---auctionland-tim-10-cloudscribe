using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models.Parcela
{
    public class ParcelaConfirmationDto
    {
        /// <summary>
        /// ID Parcele
        /// </summary>
        public Guid ParcelaId { get; set; }
        /// <summary>
        /// Broj parcele
        /// </summary>
        public string BrojParcele { get; set; }
    }
}
