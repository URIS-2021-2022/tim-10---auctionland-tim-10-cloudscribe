using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using UplataService.Models;
using UplataService.ServiceCalls;

namespace UplataService.Middlewares
{
    /// <summary>
    /// Middleware which will catch outgoing Responses and
    /// log details with Logger.
    /// </summary>
    public class HttpMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// Default constructor which takes RequestDelegate that is needed
        /// for intercepted request to finish.
        /// </summary>
        /// <param name="next"></param>
        public HttpMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Method that gets triggered with every intercepted request.
        /// It will be used to map details for Logger.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="loggerService"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, ILoggerService loggerService)
        {
            // At this moment, HTTP Response is intercepted right
            // before it was sent to client so that details can be used by Logger.
            context.Response.OnStarting((state) =>
            {
                LoggerDto loggerDto = new LoggerDto();
                string level = string.Empty;
                string response = string.Empty;
                switch (context.Response.StatusCode)
                {
                    case int value when (value >= 500):
                        response = value + HttpResponseStruct.HTTP_5XX;
                        level = "ERROR";
                        break;
                    case 404:
                        response = context.Response.StatusCode + HttpResponseStruct.HTTP_404;
                        break;
                    case 403:
                        response = context.Response.StatusCode + HttpResponseStruct.HTTP_403;
                        break;
                    case 401:
                        response = context.Response.StatusCode + HttpResponseStruct.HTTP_401;
                        break;
                    case 400:
                        response = context.Response.StatusCode + HttpResponseStruct.HTTP_400;
                        break;
                    case 200:
                        response = context.Response.StatusCode + HttpResponseStruct.HTTP_200;
                        level = "INFO";
                        break;
                }

                if (string.IsNullOrEmpty(level))
                {
                    level = "ERROR";
                }

                loggerDto.DateTime = DateTime.UtcNow;
                loggerDto.HttpMethod = context.Request.Method;
                loggerDto.Level = level;
                loggerDto.Response = response;
                loggerDto.ServiceName = context.Request.Path;

                loggerService.CreateLog(loggerDto);

                return Task.FromResult(0);
            }, null);

            await _next.Invoke(context);
        }
    }
}