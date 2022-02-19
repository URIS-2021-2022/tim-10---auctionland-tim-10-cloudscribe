﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class Liciter
    {
        [Key]
        public Guid LiciterId { get; set; }
        public string ImeLicitera { get; set; }
        public string PrezimeLicitera { get; set; }
       // public Kupac Kupac { get; set; }
        //public Zastupnik Zastupnik { get; set; }
    }
}
