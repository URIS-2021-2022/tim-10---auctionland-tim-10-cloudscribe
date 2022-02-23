using Licitacija.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Licitacija.ServiceCalls
{
    public class JavnoNadmetanjeService : IJavnoNadmetanjeService
    {

        private readonly IConfiguration configuration;

        public JavnoNadmetanjeService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<JavnaLicitacijaDto> GetJavnaLicitacijaById(Guid javnoNadmetanjeId)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri url = new Uri($"{ configuration["Services:JavnoNadmetanjeService"] }api/javneLicitacije/" + javnoNadmetanjeId);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbmlzdHJhdG9yIiwiZXhwIjoxNjQ1NjkyMjY3LCJpc3MiOiJVUklTLnVucy5hYy5ycyIsImF1ZCI6IlVSSVMudW5zLmFjLnJzIn0.4mVTn2lU_h9PHq6i0AvN_GeMHG6AssnkUx4hrpSTdYc");
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return default;
                    }
                    return JsonConvert.DeserializeObject<JavnaLicitacijaDto>(content);
                }
                return default;
            }
            catch
            {
                return default;
            }
        }
    }
    
}
