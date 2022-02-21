using OglasService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Data
{
    public interface IOglasRepository
    {
        List<Oglas> GetOglasi();
        Oglas GetOglasById(Guid oglasId);
        OglasConfirmation CreateOglas(Oglas oglas);
        void UpdateOglas(Oglas oglas);
        void DeleteOglas(Guid oglasId);
        bool SaveChanges();
    }
}
