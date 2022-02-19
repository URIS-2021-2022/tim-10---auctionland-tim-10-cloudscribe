using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UplataService.Entities;

namespace UplataService.Data
{
    /// <summary>
    /// Repository class for Kurs which implements interface IKursRepository and its methods
    /// </summary>
    public class KursRepository : IKursRepository
    {
        private readonly UplataDbContext context;

        /// <summary>
        /// Constructor which takes DbContext instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public KursRepository(UplataDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method that checks if entity with given id exists in the database
        /// </summary>
        /// <param name="id">Id of Kurs</param>
        /// <returns>true if it exists in db and false otherwise</returns>
        public bool Exists(int id)
        {
            return context.Kurs.Any(x => x.KursId== id);
        }

        /// <summary>
        /// Method that returns all Kurses 
        /// </summary>
        /// <returns>List of Kurses</returns>
        public IEnumerable<Kurs> GetAllKurses()
        {
            return context.Kurs.ToList();
        }

        /// <summary>
        /// Method that returns Kurs by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Kurs entity if it exists and null otherwise</returns>
        public Kurs GetKursById(int id)
        {
            return context.Kurs.Where(x => x.KursId == id).FirstOrDefault();
        }
    }
}
