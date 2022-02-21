using System.Collections.Generic;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    /// <summary>
    /// Interface which defines methods for TipZalbeRepository
    /// </summary>
    public interface ITipZalbeRepository
    {
        /// <summary>
        /// Definition for Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id);

        /// <summary>
        /// Definition for GetAllTipZalbe
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TipZalbe> GetAllTipZalbe();

        /// <summary>
        /// Definition for GetTipZalbeById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TipZalbe GetTipZalbeById(int id);

        /// <summary>
        /// Definition for GetSTipZalbeIdByTipZalbe
        /// </summary>
        /// <param name="tipZalbe"></param>
        /// <returns></returns>
        public int GetTipZalbeIdByTipZalbe(string tipZalbe);

        /// <summary>
        /// Definition for GetIdNameDropdownItemsForTipZalbe
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IdNameDto> GetIdNameDropdownItemsForTipZalbe();
    }
}
