using Adresa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.ServiceCalls
{
    public interface ILoggerService
    {
        public bool CreateLog(LoggerDto loggerDto);
    }
}
