using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Models;

namespace ZalbaService.ServiceCalls
{
    /// <summary>
    /// Interface for LoggerService
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Definition of Logger's CreateLog method
        /// </summary>
        /// <param name="loggerDto">LoggerDto instance</param>
        /// <returns></returns>
        public bool CreateLog(LoggerDto loggerDto);
    }
}
