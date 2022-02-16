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
        ///  Definition for SaveChanges
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges();

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

        /// <summary>
        /// Definition for AddTipZalbe
        /// </summary>
        /// <param name="tipZalbeDto"></param>
        public void AddTipZalbe(TipZalbeDto tipZalbeDto);

        /// <summary>
        /// Definition for UpdateTipZalbe
        /// </summary>
        /// <param name="tipZalbe"></param>
        public void UpdateTipZalbe(TipZalbe tipZalbe);


        /// <summary>
        /// Definition for DeleteTipZalbe
        /// </summary>
        /// <param name="tipZalbe"></param>
        public void DeleteTipZalbe(TipZalbe tipZalbe);
    }
}
