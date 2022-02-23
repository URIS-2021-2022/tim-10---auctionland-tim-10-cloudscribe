using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiciterService.ServiceCalls
{
    public class LiceService : ILiceService
    {
        private readonly IConfiguration configuration;

        public LiceService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public bool LiceInLiciter(Guid liceId)
        {
            using (HttpClient client = new HttpClient())
            {

                var x = configuration["Services:LiceService"];
                Uri url = new Uri($"{ configuration["Services:LiceService"] }api/pravnaLica");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(liceId));
                content.Headers.ContentType.MediaType = "application/json";
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
