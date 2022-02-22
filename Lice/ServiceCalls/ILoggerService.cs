using Lice.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.ServiceCalls
{
    public interface ILoggerService
    {
        public bool CreateLog(LoggerDto loggerDto);
    }
}
