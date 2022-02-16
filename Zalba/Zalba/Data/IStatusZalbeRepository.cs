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

        /// <summary>
        /// Definition for AddStatusZalbe
        /// </summary>
        /// <param name="statusZalbeDto"></param>
        public void AddStatusZalbe(StatusZalbeDto statusZalbeDto);

        /// <summary>
        /// Definition for UpdateStatusZalbe
        /// </summary>
        /// <param name="statusZalbe"></param>
        public void UpdateStatusZalbe(StatusZalbe statusZalbe);

        /// <summary>
        /// Definition for DeleteStatusZalbe
        /// </summary>
        /// <param name="statusZalbe"></param>
        public void DeleteStatusZalbe(StatusZalbe statusZalbe);
    }
}
