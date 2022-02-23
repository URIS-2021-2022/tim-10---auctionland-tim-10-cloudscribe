using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UplataService.Models;

namespace UplataService.ServiceCalls
{
    /// <summary>
    /// Interface for calls to LiceService
    /// </summary>
    public interface ILiceService
    {
        /// <summary>
        /// Definition of method which will call LiceService and get all FizickaLica
        /// </summary>
        /// <returns>Task whose result will be a list of FizickoLiceDtos.</returns>
        public Task<List<FizickoLiceDto>> GetFizickaLica();
        /// <summary>
        /// Definition of method which will call LiceService and get all PravnaLica
        /// </summary>
        /// <returns>Task whose result will be a list of PravnoLiceDtos.</returns>
        public Task<List<PravnoLiceDto>> GetPravnaLica();
    }
}
