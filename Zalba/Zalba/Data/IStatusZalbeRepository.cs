using System.Collections.Generic;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    /// <summary>
    /// Interface which defines methods for StatusZalbeRepository
    /// </summary>
    public interface IStatusZalbeRepository
    {
        /// <summary>
        /// Definition for Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id);

        /// <summary>
        /// Definition for GetAllStatusZalbe
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StatusZalbe> GetAllStatusZalbe();

        /// <summary>
        /// Definition for GetStatusZalbeById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StatusZalbe GetStatusZalbeById(int id);

        /// <summary>
        /// Definition for GetStatusZalbeIdByStatusZalbe
        /// </summary>
        /// <param name="statusZalbe"></param>
        /// <returns></returns>
        public int GetStatusZalbeIdByStatusZalbe(string statusZalbe);


        /// <summary>
        /// Definition for GetIdNameDropdownItemsForStatusZalbe
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IdNameDto> GetIdNameDropdownItemsForStatusZalbe();
    }
}
