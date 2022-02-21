using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class LiciterDto
    {
        /// <summary>
        /// Liciter id
        /// </summary>
        public Guid LiciterId { get; set; }

        /// <summary>
        /// Ime licitera
        /// </summary>
        //public string ImeLicitera { get; set; }

        /// <summary>
        /// Prezime licitera
        /// </summary>
       //public string PrezimeLicitera { get; set; }

        //public Guid KupacId { get; set; }
        public  Kupac Kupac { get; set; }

       // public Guid ZastupnikId { get; set; }
        public Zastupnik Zastupnik { get; set; }

    }
}
