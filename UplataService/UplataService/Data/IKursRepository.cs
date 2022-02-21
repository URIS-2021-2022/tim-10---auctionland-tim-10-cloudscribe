using System.Collections.Generic;
using UplataService.Entities;

namespace UplataService.Data
{
    /// <summary>
    /// Interface which defines methods for KursRepository
    /// </summary>
    public interface IKursRepository
    {
        /// <summary>
        /// Definition for Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id);

        /// <summary>
        /// Definition for GetAllKurses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Kurs> GetAllKurses();

        /// <summary>
        /// Definition for GetKursById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Kurs GetKursById(int id);
    }
}
