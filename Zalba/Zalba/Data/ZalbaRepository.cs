using System;
using System.Collections.Generic;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    public class ZalbaRepository : IZalbaRepository
    {
        private readonly ZalbaDbContext context;

        public ZalbaRepository(ZalbaDbContext context)
        {
            this.context = context;
        }

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

        public IEnumerable<Zalba> GetAllZalbas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipZalbe> GetTipoviZalbi()
        {
            throw new NotImplementedException();
        }

        public Zalba GetZalbaById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
