using DocumentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Helpers
{
    public interface IAuthenticationHelper
    {
        public bool AuthenticateParcipal(Principal principal);
        public string GenerateJwt(Principal principal);

    }
}
