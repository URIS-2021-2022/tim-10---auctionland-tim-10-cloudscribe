﻿using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class LiciterConfirmationDto
    {
        /// <summary>
        /// ID licitera
        /// </summary>
        public Guid LiciterId { get; set; }

        public Kupac Kupac { get; set; }
        public Zastupnik Zastupnik { get; set; }

        public Guid liceId { get; set; }

        [NotMapped]
        public LiceLiciterDto lice { get; set; }

    }
}
