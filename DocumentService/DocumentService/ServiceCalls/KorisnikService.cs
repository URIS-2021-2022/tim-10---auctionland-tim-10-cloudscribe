using DocumentService.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DocumentService.ServiceCalls
{
    public class KorisnikService : IKorisnikService
    {
        private readonly IConfiguration configuration;

        public KorisnikService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool KorisnikDokument(Guid tipID)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = configuration["Services:KorisnikService"];
                Uri url = new Uri($"{ configuration["Services:KorisnikService"] }api/korisnik");

                HttpContent content = new StringContent(JsonConvert.SerializeObject(tipID));
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
