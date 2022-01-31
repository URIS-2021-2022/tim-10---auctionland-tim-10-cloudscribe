using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    public interface IZalbaRepository 
    {
        public IEnumerable<Zalba> GetAllZalbas();

        public Zalba GetZalbaById(int id);

        public void AddZalba(ZalbaDto zalbaDto, int statusZalbeId);

        // For example, dropdown on frontend
        public IEnumerable<TipZalbe> GetTipoviZalbi();

        public bool SaveChanges();
    }
}
