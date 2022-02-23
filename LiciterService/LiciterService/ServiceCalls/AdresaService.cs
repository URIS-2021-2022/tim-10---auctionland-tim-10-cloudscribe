using LiciterService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiciterService.ServiceCalls
{
    public class AdresaService : IAdresaService
    {
        private readonly IConfiguration configuration;

        public AdresaService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool AdresaInLiciter(Guid adresaId)
        {
      
            using (HttpClient client = new HttpClient()) 
            { 
       
                var x = configuration["Services:AdresaService"]; 
                Uri url = new Uri($"{ configuration["Services:AdresaService"] }api/adrese");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(adresaId)); 
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
