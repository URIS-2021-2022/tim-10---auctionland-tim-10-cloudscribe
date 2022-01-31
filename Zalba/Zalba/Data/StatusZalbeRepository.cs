using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities;

namespace ZalbaService.Data
{
    public class StatusZalbeRepository : IStatusZalbeRepository
    {
        private readonly ZalbaDbContext context;

        public StatusZalbeRepository(ZalbaDbContext context)
        {
            this.context = context;
        }

        public int GetStatusZalbeIdByStatusZalbe(string statusZalbe)
        {
            StatusZalbe statusZalbeFromDb = context.StatusZalbe.Where(x => x.StatusZalbe1.Equals(statusZalbe)).FirstOrDefault();
            if (statusZalbeFromDb != null)
            {
                return statusZalbeFromDb.StatusZalbeId;
            }

            return 0;
        }
    }
}
