using System;
using System.Collections.Generic;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    /// <summary>
    /// Interface which defines methods for ZalbaRepository
    /// </summary>
    public interface IZalbaRepository 
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
        /// Definition for ValidateZalba
        /// </summary>
        /// <param name="BrojOdluke"></param>
        /// <param name="BrojResenja"></param>
        /// <param name="DatumResenja"></param>
        /// <param name="TipZalbeId"></param>
        /// <returns></returns>
        public string ValidateZalba(string BrojOdluke, string BrojResenja, DateTime DatumResenja, int TipZalbeId);

        /// <summary>
        /// Definition for GetAllZalbas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Zalba> GetAllZalbas();

        /// <summary>
        /// Definition for GetZalbaById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Zalba GetZalbaById(int id);

        /// <summary>
        /// Definition for AddZalba
        /// </summary>
        /// <param name="zalbaDto"></param>
        /// <param name="statusZalbeId"></param>
        public void AddZalba(ZalbaDto zalbaDto, int statusZalbeId);

        /// <summary>
        /// Definition for ResolveZalba
        /// </summary>
        /// <param name="zalba"></param>
        /// <param name="resolveZalbaDto"></param>
        public void ResolveZalba(Zalba zalba, ResolveZalbaDto resolveZalbaDto);

        /// <summary>
        /// Definition for UpdateZalba
        /// </summary>
        /// <param name="zalba"></param>
        /// <param name="updateZalbaDto"></param>
        public void UpdateZalba(Zalba zalba, UpdateZalbaDto updateZalbaDto);

        /// <summary>
        /// Definition for DeleteZalba
        /// </summary>
        /// <param name="zalba"></param>
        public void DeleteZalba(Zalba zalba);
    }
}
