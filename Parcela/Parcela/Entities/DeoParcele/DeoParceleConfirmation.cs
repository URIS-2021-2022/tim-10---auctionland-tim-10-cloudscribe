using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities.DeoParcele
{
    public class DeoParceleConfirmation
    {
        /// <summary>
        /// ID dela parcele
        /// </summary>
        public Guid DeoParceleId { get; set; }
        /// <summary>
        /// Površina dela pracele
        /// </summary>
        public int Povrsina { get; set; }
    }
}
