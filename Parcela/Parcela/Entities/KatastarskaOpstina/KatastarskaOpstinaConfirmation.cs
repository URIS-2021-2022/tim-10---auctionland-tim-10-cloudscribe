using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities.KatastarskaOpstina
{
    public class KatastarskaOpstinaConfirmation
    {
        /// <summary>
        /// ID katastarske opštine
        /// </summary>
        public Guid KatastarskaOpstinaId { get; set; }
        /// <summary>
        /// Ime katastarske opštine
        /// </summary>
        public string ImeKatastarskeOpstine { get; set; }
    }
}
