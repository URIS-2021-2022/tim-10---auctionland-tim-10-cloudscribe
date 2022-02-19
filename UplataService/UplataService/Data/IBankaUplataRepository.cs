using System.Collections.Generic;
using UplataService.Entities;

namespace UplataService.Data
{
    /// <summary>
    /// Interface which defines methods for BankaUplataRepository
    /// </summary>
    public interface IBankaUplataRepository
    {
        /// <summary>
        /// Definition for GetAllUplatasByBrojNadmetanja
        /// </summary>
        /// <returns></returns>
        public List<BankaUplata> GetAllUplatasByBrojNadmetanja(int brojNadmetanja);
    }
}
