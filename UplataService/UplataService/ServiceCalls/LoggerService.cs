using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using UplataService.Models;

namespace UplataService.ServiceCalls
{
    /// <summary>
    /// Class which will be used to call LoggerService from another endpoint
    /// </summary>
    public class LoggerService : ILoggerService
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Default constructor in which Configuration instance will be injected
        /// </summary>
        /// <param name="configuration"></param>
        public LoggerService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Method that will call LoggerService which is on another endpoint
        /// </summary>
        /// <param name="loggerDto"></param>
        /// <returns>True if calling LoggerService was successful, false otherwise.</returns>
        public bool CreateLog(LoggerDto loggerDto)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri url = new Uri($"{ configuration["Services:LoggerService"] }api/logger");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(loggerDto));
                content.Headers.ContentType.MediaType = "application/json";

                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
        }
    }
}