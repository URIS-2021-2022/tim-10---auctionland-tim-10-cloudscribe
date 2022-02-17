using Adresa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Data
{
    public interface IDrzavaRepository
    {
        List<DrzavaEntity> GetDrzave();
        DrzavaEntity GetDrzavaById(Guid drzavaId);
    }
}
