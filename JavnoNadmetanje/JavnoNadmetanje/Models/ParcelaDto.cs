using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Models
{
    public class ParcelaDto
    {
        /// <summary>
        /// ID Parcele
        /// </summary>

        public Guid ParcelaId { get; set; }

        /// <summary>
        /// Površina parcele
        /// </summary>
        public int Povrsina { get; set; }

        /// <summary>
        /// ID Korisnika
        /// </summary>
        public Guid KorisnikId { get; set; }

        /// <summary>
        /// Broj Parcele
        /// </summary>
        public string BrojParcele { get; set; }

        /// <summary>
        /// ID Katastarske Opštine
        /// </summary>
        public Guid KatastarskaOpstinaId { get; set; }

        /// <summary>
        /// Ime Katastarske Opštine
        /// </summary>
        public string KatastarskaOpstina { get; set; }


    }
}
