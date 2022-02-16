using System;
using System.Collections.Generic;
using System.Linq;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    /// <summary>
    /// Repository class for ZalbaRepository which implements interface ITipZalbeRepository and its methods
    /// </summary>
    public class ZalbaRepository : IZalbaRepository
    {
        private readonly ZalbaDbContext context;

        /// <summary>
        /// Constructor which takes DbContext instance as parameter through Dependency Injection
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public ZalbaRepository(ZalbaDbContext context)
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
        /// <param name="id">Id of Zalba</param>
        /// <returns>true if it exists in db and false otherwise</returns>
        public bool Exists(int id)
        {
            return context.Zalba.Any(x => x.ZalbaId == id);
        }

        /// <summary>
        /// Method that performs validation for creating and updating Zalba
        /// </summary>
        /// <param name="BrojOdluke"></param>
        /// <param name="BrojResenja"></param>
        /// <param name="DatumResenja"></param>
        /// <param name="TipZalbeId"></param>
        /// <returns>message</returns>
        public string ValidateZalba(string BrojOdluke, string BrojResenja, DateTime DatumResenja, int TipZalbeId)
        {
            if ((BrojOdluke == null && BrojResenja == null) || (BrojOdluke != null && BrojResenja != null))
            {
                return "Either brojOdluke or brojResenja have to be populated.";
            }

            if (BrojResenja != null && DatumResenja == DateTime.MinValue)
            {
                return "If brojResenja is populated, datumResenja has to be populated as well.";
            }

            if (!Exists(TipZalbeId))
            {
                return "There is no TipZalbe with given TipZalbeId";
            }
            return string.Empty;
        }

        /// <summary>
        /// Method that returns all Zalbas 
        /// </summary>
        /// <returns>List of Zalbas</returns>
        public IEnumerable<Zalba> GetAllZalbas()
        {
            return context.Zalba.ToList();
        }

        /// <summary>
        /// Method that returns Zalba by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Zalba entity if it exists and null otherwise</returns>
        public Zalba GetZalbaById(int id)
        {
            return context.Zalba.Where(x => x.ZalbaId == id).FirstOrDefault();
        }

        /// <summary>
        /// Method that saves new entity to the database
        /// </summary>
        /// <param name="zalbaDto"></param>
        /// <param name="statusZalbeId"></param>
        public void AddZalba(ZalbaDto zalbaDto, int statusZalbeId)
        {
            Zalba zalba = new Zalba
            {
                BrojOdluke = zalbaDto.BrojOdluke,
                BrojResenja = zalbaDto.BrojResenja,
                DatumPodnosenja = DateTime.Now,
                DatumResenja = zalbaDto.DatumResenja,
                Obrazlozenje = zalbaDto.Obrazlozenje,
                RazlogZalbe = zalbaDto.RazlogZalbe,
                TipZalbeId = zalbaDto.TipZalbeId,
                StatusZalbeId = statusZalbeId
            };

            context.Add(zalba);
        }

        /// <summary>
        /// Method that updates statusZalbeId field on given Zalba entity
        /// </summary>
        /// <param name="zalba">Zalba entity which will be updated</param>
        /// <param name="resolveZalbaDto">Dto object containing statusZalbeId which will be used to update entity</param>
        public void ResolveZalba(Zalba zalba, ResolveZalbaDto resolveZalbaDto)
        {
            // Update statusZalbeId field and saveChanges is called in controller
            zalba.StatusZalbeId = resolveZalbaDto.StatusZalbeId;
        }

        /// <summary>
        /// Method that updates fields on given Zalba entity
        /// </summary>
        /// <param name="zalba">Zalba entity which will be updated</param>
        /// <param name="updateZalbaDto">Dto object which will be used to update entity</param>
        public void UpdateZalba(Zalba zalba, UpdateZalbaDto updateZalbaDto)
        {
            // Update fields and saveChanges is called in controller
            zalba.RazlogZalbe = updateZalbaDto.RazlogZalbe;
            zalba.Obrazlozenje = updateZalbaDto.Obrazlozenje;
            zalba.DatumResenja = updateZalbaDto.DatumResenja;
            zalba.BrojResenja = updateZalbaDto.BrojResenja;
            zalba.BrojOdluke = updateZalbaDto.BrojOdluke;
            zalba.TipZalbeId = updateZalbaDto.TipZalbeId;
        }

        /// <summary>
        /// Method that deletes Zalba entity
        /// </summary>
        /// <param name="zalba"></param>
        public void DeleteZalba(Zalba zalba)
        {
            context.Remove(zalba);
        }
    }
}
