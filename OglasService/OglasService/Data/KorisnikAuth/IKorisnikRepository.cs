using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Data
{ 
    public interface IKorisnikRepository
    {
        public bool UserWithCredentialsExists(string username, string password);
    }
}
