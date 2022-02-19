using System;
using System.Collections.Generic;
using System.Linq;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Data
{
    /// <summary>
    /// Repository class for Uplata which implements interface IUplataRepository and its methods
    /// </summary>
    public class UplataRepository : IUplataRepository
    {
        private readonly UplataDbContext context;

        /// <summary>
        /// Constructor which takes DbContext instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public UplataRepository(UplataDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method that checks if entity with given id exists in the database
        /// </summary>
        /// <param name="id">Id of Uplata</param>
        /// <returns>true if it exists in db and false otherwise</returns>
        public bool Exists(int id)
        {
            return context.Uplata.Any(x => x.UplataId == id);
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
        /// Method that returns all Uplatas 
        /// </summary>
        /// <returns>List of Uplatas</returns>
        public IEnumerable<Uplata> GetAllUplatas()
        {
            return context.Uplata.ToList();
        }

        /// <summary>
        /// Method that returns Uplata by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uplata entity if it exists and null otherwise</returns>
        public Uplata GetUplataById(int id)
        {
            return context.Uplata.Where(x => x.UplataId == id).FirstOrDefault();
        }

        /// <summary>
        /// Method that saves new entity to the database
        /// </summary>
        /// <param name="brojNadmetanja"></param>
        public void RecordUplatas(int brojNadmetanja)
        {

            context.Add(uplata);
        }
    }
}
