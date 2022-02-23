﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OglasService.ServiceCalls
{
    public class LoggerService : ILoggerService
    {
        private readonly IConfiguration configuration;

        public LoggerService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool CreateLog(LoggerDtos loggerDto)
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
