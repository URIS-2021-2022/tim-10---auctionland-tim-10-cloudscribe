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

        public  Kupac Kupac { get; set; }

        public Zastupnik Zastupnik { get; set; }

    }
}
