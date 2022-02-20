using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Data
{
    public interface IUserRepository
    {
        public bool UserWithCredentialExists(string username, string password);
    }
}
