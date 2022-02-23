using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public virtual LiceLiciterDto lice { get; set; }

    }
}
