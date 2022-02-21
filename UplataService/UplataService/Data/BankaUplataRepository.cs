using System.Collections.Generic;
using System.Linq;
using UplataService.Entities;

namespace UplataService.Data
{
    /// <summary>
    /// Repository class for Kurs which implements interface IBankaUplataRepository and its methods
    /// </summary>
    public class BankaUplataRepository : IBankaUplataRepository
    {
        private readonly UplataDbContext context;

        /// <summary>
        /// Constructor which takes DbContext instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public BankaUplataRepository(UplataDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method that returns all BankaUplatas 
        /// </summary>
        /// <returns>List of BankaUplatas which have brojNadmetanja in pozivNaBroj</returns>
        public List<BankaUplata> GetAllUplatasByBrojNadmetanja(int brojNadmetanja)
        {
            // pozivNaBroj is either broj_nadmetanja-JMBG or broj_nadmetanja-matični_broj_preduzeća
            return context.BankaUplata.Where(x => x.PozivNaBroj.StartsWith(brojNadmetanja.ToString())).ToList();
        }
    }
}
