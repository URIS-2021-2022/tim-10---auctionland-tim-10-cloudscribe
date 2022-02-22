using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Models
{
    /// <summary>
    /// DTO class which will be used for LoggerService
    /// </summary>
    public class LoggerDto
    {
        /// <summary>
        /// Date of the log
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// HTTP Method's response
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Exact HTTP Method
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Service name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Log level
        /// </summary>

        public string Level { get; set; }
    }
}
