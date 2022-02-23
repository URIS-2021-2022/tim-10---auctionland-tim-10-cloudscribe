using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class LiciterUpdateDto 
    {
        /// <summary>
        /// ID licitera
        /// </summary>
        public Guid LiciterId { get; set; }

        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid KupacId { get; set; }

        /// <summary>
        /// ID zastupnika
        /// </summary>
        public Guid ZastupnikId { get; set; }

        public Guid liceId { get; set; }

    }
}
