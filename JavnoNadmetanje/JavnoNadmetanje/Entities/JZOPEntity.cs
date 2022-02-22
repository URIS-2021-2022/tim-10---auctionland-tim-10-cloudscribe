using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Entities
{
    public class JzopEntity : JavnoNadmetanjeEntity
    {

        /// <summary>
        /// Oznaka javnog zatvaranja otvorenih ponuda
        /// </summary>
        public int brojJZOP { get; set; }
        // <summary>
        /// Opis javnog zatvaranja otvorenih ponuda
        /// </summary>
        public string opisJZOP { get; set; }
    }
}
