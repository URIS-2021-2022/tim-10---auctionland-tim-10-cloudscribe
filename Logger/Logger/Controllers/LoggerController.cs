
using Logger.Entities;
using Microsoft.AspNetCore.Mvc;

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Controllers
{
    [ApiController]
    [Route("api/logger")]
    public class LoggerController : ControllerBase
    {
        private static readonly ILogger loggerManager = LogManager.GetCurrentClassLogger();


        public LoggerController()
        {
           
           
        }
        [HttpPost]
        public ActionResult<LogMessage> CreateMessage([FromBody] LogMessage message)
        {
            message.DateTime = DateTime.Now;
            loggerManager.Info(message.Level + " "+ message.DateTime + " "+ message.ServiceName + " " + message.HttpMethod + " " + message.About);
            return Created("", message);

        }

    }
}
