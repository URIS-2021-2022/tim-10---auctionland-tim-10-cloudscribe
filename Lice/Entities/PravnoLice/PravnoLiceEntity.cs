﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Entities
{
    //[Table("PravnoLice")]
    public class PravnoLiceEntity : LiceEntity
    {
        /// <summary>
        /// ID pravnog lica
        /// </summary>
       // public Guid pravnoLiceId { get; set; }

        /// <summary>
        /// Naziv pravog lica
        /// </summary>
        public string naziv { get; set; }

        /// <summary>
        /// Broj faksa
        /// </summary>
        public int faks { get; set; }

       
    }
}
