
using Microsoft.Extensions.Configuration;
using Parcela.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
namespace Parcela.ServiceCalls
{
    public class AdresaService : IAdresaService
    {
        private readonly IConfiguration configuration;

        public AdresaService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool AdresaInParcela(AdresaDto adresaDto)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = configuration["Services:AdresaService"];
                Uri url = new Uri($"{ configuration["Services:AdresaService"] }api/adrese");

                HttpContent content = new StringContent(JsonConvert.SerializeObject(adresaDto));
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
