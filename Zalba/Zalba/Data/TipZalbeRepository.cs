using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    /// <summary>
    /// Repository class for TipZalbe which implements interface ITipZalbeRepository and its methods
    /// </summary>
    public class TipZalbeRepository : ITipZalbeRepository
    {
        private readonly ZalbaDbContext context;

        /// <summary>
        /// Constructor which takes DbContext instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public TipZalbeRepository(ZalbaDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method that applies local changes to database 
        /// </summary>
        /// <returns>true if number of affected entities is greater than 0 and false otherwise</returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// Method that checks if entity with given id exists in the database
        /// </summary>
        /// <param name="id">Id of TipZalbe</param>
        /// <returns>true if it exists in db and false otherwise</returns>
        public bool Exists(int id)
        {
            return context.TipZalbe.Any(x => x.TipZalbeId == id);
        }

        /// <summary>
        /// Method that returns all TipZalbe 
        /// </summary>
        /// <returns>List of TipZalbe</returns>
        public IEnumerable<TipZalbe> GetAllTipZalbe()
        {
            return context.TipZalbe.Include("Zalba").ToList();
        }

        /// <summary>
        /// Method that returns TipZalbe by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TipZalbe entity if it exists and null otherwise</returns>
        public TipZalbe GetTipZalbeById(int id)
        {
            return context.TipZalbe.Where(x => x.TipZalbeId == id).FirstOrDefault();
        }

        /// <summary>
        /// Method that returns TipZalbe by tipZalbe string
        /// </summary>
        /// <param name="tipZalbe">Type of zalba</param>
        /// <returns>0 if tipZalbe doesn't exist and tipZalbeId otherwise</returns>
        public int GetTipZalbeIdByTipZalbe(string tipZalbe)
        {
            TipZalbe tipZalbeFromDb = context.TipZalbe.Where(x => x.TipZalbe1.Equals(tipZalbe)).FirstOrDefault();
            if (tipZalbeFromDb != null)
            {
                return tipZalbeFromDb.TipZalbeId;
            }

            return 0;
        }


        /// <summary>
        /// Method that gets all TipZalbe and maps them to IdNameDto list
        /// </summary>
        /// <returns>List of IdNameDtos</returns>
        public IEnumerable<IdNameDto> GetIdNameDropdownItemsForTipZalbe()
        {
            return context.TipZalbe.Select(x => new IdNameDto(x)).ToList();
        }
    }
}
