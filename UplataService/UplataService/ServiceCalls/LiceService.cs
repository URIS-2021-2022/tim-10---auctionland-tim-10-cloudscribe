using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UplataService.Models;

namespace UplataService.ServiceCalls
{
    /// <summary>
    /// Class which will implement calls to LiceService for relevant methods.
    /// </summary>
    public class LiceService : ILiceService
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Default constructor which will get configuration instance by DI.
        /// </summary>
        /// <param name="configuration"></param>
        public LiceService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Method which will call LiceService to get all FizickaLica.
        /// </summary>
        /// <returns>Task whose result will be a list of FizickoLiceDtos.</returns>
        public async Task<List<FizickoLiceDto>> GetFizickaLica()
        {
            using HttpClient client = new HttpClient();
            Uri url = new Uri($"{ configuration["Services:LiceService"] }api/fizickalica");
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(content))
                {
                    return default;
                }
                return JsonConvert.DeserializeObject<List<FizickoLiceDto>>(content);
            }
            return default;
        }

        /// <summary>
        /// Method which will call LiceService to get all PravnaLica.
        /// </summary>
        /// <returns>Task whose result will be a list of PravnoLiceDtos.</returns>
        public async Task<List<PravnoLiceDto>> GetPravnaLica()
        {
            using HttpClient client = new HttpClient();
            Uri url = new Uri($"{ configuration["Services:LiceService"] }api/pravnalica");
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(content))
                {
                    return default;
                }
                return JsonConvert.DeserializeObject<List<PravnoLiceDto>>(content);
            }
            return default;
        }
    }
}
