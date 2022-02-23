using System.Collections.Generic;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Data
{
    /// <summary>
    /// Interface which defines methods for UplataRepository
    /// </summary>
    public interface IUplataRepository
    {
        /// <summary>
        /// Definition for Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id);

        /// <summary>
        /// Definition for SaveChanges
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges();

        /// <summary>
        /// Definition for GetAllUplata
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Uplata> GetAllUplatas();

        /// <summary>
        /// Definition for GetUplataById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Uplata GetUplataById(int id);

        /// <summary>
        /// Definition for RecordUplatas
        /// </summary>
        /// <param name="bankaUplatas"></param>
        /// <param name="fizickoLiceDtos"></param>
        /// <param name="pravnoLiceDtos"></param>
        /// <param name="brojNadmetanja"></param>
        public List<Uplata> RecordUplatas(List<BankaUplata> bankaUplatas, List<FizickoLiceDto> fizickoLiceDtos, List<PravnoLiceDto> pravnoLiceDtos, int brojNadmetanja);

        /// <summary>
        /// Definition for AddUplatas method
        /// </summary>
        /// <param name="uplatas"></param>
        public void AddUplatas(List<Uplata> uplatas);

        /// <summary>
        /// Definition for GetAllViseceUplate
        /// </summary>
        /// <param name="brojNadmetanja"></param>
        public List<UplataDto> GetAllViseceUplate(int brojNadmetanja);
    }
}
