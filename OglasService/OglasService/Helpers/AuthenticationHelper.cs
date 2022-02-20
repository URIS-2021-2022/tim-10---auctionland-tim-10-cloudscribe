using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OglasService.Data;
using OglasService.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasService.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private IConfiguration configuration;
        private IKorisnikRepository korisnikRepository;

        public AuthenticationHelper(IConfiguration configuration, IKorisnikRepository korisnikRepository)
        {
            this.configuration = configuration;
            this.korisnikRepository = korisnikRepository;

        }
        public bool AuthenticatePrincipal(Principal principal)
        {
            if (korisnikRepository.UserWithCredentialsExists(principal.Username, principal.Password))
            {
                return true;
            }

            return false;
        }

        public string GenerateJwt(Principal principal)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                                             configuration["Jwt:Issuer"],
                                             null,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
