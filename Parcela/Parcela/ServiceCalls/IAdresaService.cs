﻿using Parcela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.ServiceCalls
{
    interface IAdresaService
    {
        public bool AdresaInParcela(AdresaDto adresaDto);
    }
}
