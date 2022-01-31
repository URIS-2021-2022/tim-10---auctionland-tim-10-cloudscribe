using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Data
{
    public interface ITipZalbeRepository
    {
        public bool Exists(int id);
    }
}
