using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    /// <summary>
    /// Repository class for StatusZalbe which implements interface IStatusZalbeRepository and its methods
    /// </summary>
    public class StatusZalbeRepository : IStatusZalbeRepository
    {
        private readonly ZalbaDbContext context;

        /// <summary>
        /// Constructor which takes DbContext instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public StatusZalbeRepository(ZalbaDbContext context)
        {
            this.context = context; 
        }

        /// <summary>
        /// Method that checks if entity with given id exists in the database
        /// </summary>
        /// <param name="id">Id of StatusZalbe</param>
        /// <returns>true if it exists in db and false otherwise</returns>
        public bool Exists(int id)
        {
            return context.StatusZalbe.Any(x => x.StatusZalbeId == id);
        }

        /// <summary>
        /// Method that returns all StatusZalbe 
        /// </summary>
        /// <returns>List of StatusZalbe</returns>
        public IEnumerable<StatusZalbe> GetAllStatusZalbe()
        {
            return context.StatusZalbe.Include("Zalba").ToList();
        }

        /// <summary>
        /// Method that returns StatusZalbe by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StatusZalbe entity if it exists and null otherwise</returns>
        public StatusZalbe GetStatusZalbeById(int id)
        {
            return context.StatusZalbe.Where(x => x.StatusZalbeId == id).FirstOrDefault();
        }

        /// <summary>
        /// Method that returns StatusZalbe by statusZalbe string
        /// </summary>
        /// <param name="statusZalbe">Status of zalba</param>
        /// <returns>0 if status zalbe doesn't exist and statusZalbeId otherwise</returns>
        public int GetStatusZalbeIdByStatusZalbe(string statusZalbe)
        {
            StatusZalbe statusZalbeFromDb = context.StatusZalbe.Where(x => x.StatusZalbe1.Equals(statusZalbe)).FirstOrDefault();
            if (statusZalbeFromDb != null)
            {
                return statusZalbeFromDb.StatusZalbeId;
            }

            return 0;
        }

        /// <summary>
        /// Method that gets all StatusZalbe and maps them to IdNameDto list
        /// </summary>
        /// <returns>List of IdNameDtos</returns>
        public IEnumerable<IdNameDto> GetIdNameDropdownItemsForStatusZalbe()
        {
            return context.StatusZalbe.Select(x => new IdNameDto(x)).ToList();
        }

    }
}
