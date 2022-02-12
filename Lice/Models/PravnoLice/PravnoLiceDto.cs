﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Models.PravnoLice
{
    public class PravnoLiceDto
    {

        /// <summary>
        /// Prvi broj telefona lica
        /// </summary>
        public string brojTelefona1 { get; set; }

        /// <summary>
        /// Drugi broj telefona lica
        /// </summary>
        public string brojTelefona2 { get; set; }

        /// <summary>
        /// Email adresa lica
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Broj racuna lica
        /// </summary>
        public string brojRacuna { get; set; }
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
