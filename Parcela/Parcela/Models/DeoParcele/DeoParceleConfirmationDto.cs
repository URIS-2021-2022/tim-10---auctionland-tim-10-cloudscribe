using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models.DeoParcele
{
    public class DeoParceleConfirmationDto
    {
        /// <summary>
        /// ID Dela parcele
        /// </summary>
        public Guid DeoParceleId { get; set; }
        /// <summary>
        /// Površina dela parcele
        /// </summary>
        public int Povrsina { get; set; }

    }
}
