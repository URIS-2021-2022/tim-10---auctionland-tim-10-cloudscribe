using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class LoggerDtos
    {
        public DateTime DateTime { get; set; }
        public string Response { get; set; }
        public string HttpMethod { get; set; }

        public string ServiceName { get; set; }

        public string Level { get; set; }
    }
}
