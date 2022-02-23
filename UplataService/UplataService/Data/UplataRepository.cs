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
        /// <param name="bankaUplatas"></param>
        /// <param name="fizickoLiceDtos"></param>
        /// <param name="pravnoLiceDtos"></param>
        /// <param name="brojNadmetanja"></param>
        public List<Uplata> RecordUplatas(List<BankaUplata> bankaUplatas, List<FizickoLiceDto> fizickoLiceDtos, List<PravnoLiceDto> pravnoLiceDtos, int brojNadmetanja)
        {
            List<Uplata> newUplatas = new List<Uplata>(bankaUplatas.Count);

            // New Uplata entity which will be constantly changed within the Foreach loop
            Uplata newUplata;
            // JMBG/maticniBroj which will be constantly changed within the Foreach loop
            string unqiueIdentifier = string.Empty;
            FizickoLiceDto fizickoLiceDto = new FizickoLiceDto();
            PravnoLiceDto pravnoLiceDto = new PravnoLiceDto();

            // Iterating through all bankaUplatas and creating new Uplata entity and storing it into a list of new Uplatas
            foreach (BankaUplata bankaUplata in bankaUplatas)
            {
                unqiueIdentifier = bankaUplata.PozivNaBroj.Split('-')[1];
                newUplata = new Uplata(bankaUplata, brojNadmetanja);

                // If unqiueIdentifier's characters is 13, we're using the identifier as JMBG to find FizickoLice
                if (unqiueIdentifier.Length == 13)
                {
                    fizickoLiceDto = fizickoLiceDtos.Where(x => x.JMBG.Equals(unqiueIdentifier)).FirstOrDefault();
                    // If no FizickoLice with given JMBG was found, uplata will be Viseca and won't have UplatilacId set.
                    // Otherwise, UplatilacID will be set
                    if (fizickoLiceDto != null)
                    {
                        newUplata.UplatilacId = 1;
                    }
                }
                // If unqiueIdentifier's characters is 10, we're using the identifier as maticniBroj to find PravnoLice
                else if (unqiueIdentifier.Length == 10)
                {
                    pravnoLiceDto = pravnoLiceDtos.Where(x => x.maticniBroj.Equals(unqiueIdentifier)).FirstOrDefault();
                    // If no PravnoLice with given maticniBroj was found, uplata will be Viseca and won't have UplatilacId set.
                    // Otherwise, UplatilacID will be set
                    if (pravnoLiceDto != null)
                    {
                        newUplata.UplatilacId = 1;
                    }
                }

                unqiueIdentifier = string.Empty;
                newUplatas.Add(newUplata);
            }

            return newUplatas;
        }

        /// <summary>
        /// Method that adds passed list of Uplata entities into the Database
        /// </summary>
        /// <param name="uplatas">List of Uplata entities which will be added to the Database</param>
        public void AddUplatas(List<Uplata> uplatas)
        {
            context.AddRange(uplatas);
        }


        /// <summary>
        /// Method that returns all uplatas which are visece
        /// </summary>
        /// <param name="brojNadmetanja"></param>
        public List<UplataDto> GetAllViseceUplate(int brojNadmetanja)
        {
            return context.Uplata.Where(x => !x.UplatilacId.HasValue).Select(x => new UplataDto(x)).ToList();
        }
    }
}
