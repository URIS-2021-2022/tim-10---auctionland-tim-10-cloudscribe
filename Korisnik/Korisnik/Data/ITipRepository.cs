using Korisnik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Data
{
    public interface ITipRepository
    {
        List<Tip> GetTip();
        Tip GetTipById(Guid tipId);
        
        


    }
}
