using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities;

namespace ZalbaService.Data
{
    public class TipZalbeRepository : ITipZalbeRepository
    {
        private readonly ZalbaDbContext context;

        public TipZalbeRepository(ZalbaDbContext context)
        {
            this.context = context;
        }

        public bool Exists(int id)
        {
            return context.TipZalbe.Any(x => x.TipZalbeId == id);
        }
    }
}
