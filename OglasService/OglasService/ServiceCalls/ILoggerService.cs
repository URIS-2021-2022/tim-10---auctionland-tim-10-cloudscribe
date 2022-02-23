using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.ServiceCalls
{
    public interface ILoggerService
    {
        public bool CreateLog(LoggerDtos loggerDto);
    }
}
