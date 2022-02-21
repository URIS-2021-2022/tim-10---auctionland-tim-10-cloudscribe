using Korisnik.Data;
using Korisnik.Entities;
using Korisnik.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Korisnik.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private readonly IConfiguration configuration;
        private readonly IUserRepository userRepository;
        private readonly KorisnikContext context;
       

        public AuthenticationHelper(IConfiguration configuration, IUserRepository userRepository, KorisnikContext context)
        {
            this.configuration = configuration;
            this.userRepository = userRepository;
            this.context = context;
        }

        public bool AuthenticatePrincipal(Principal principal)
        {
            if (userRepository.UserWithCredentialsExists(principal.KorisnikKorisnickoIme, principal.KorisnikLozinka))
            {
                return true;
            }

            return false;
        }

        public void CreateHash(Korisnikk korisnik)
        {
            var userpass=userRepository.HashPassword(korisnik.KorisnikLozinka);
            korisnik.KorisnikLozinka = userpass.Item1;
            korisnik.Salt = userpass.Item2;
        }

        public string GenerateJwt(Principal principal)
        {
            string tip = context.Korisnici.Include(t => t.Tip).First(e => e.KorisnikKorisnickoIme == principal.KorisnikKorisnickoIme).Tip.TipKorisnika;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                                             configuration["Jwt:Issuer"],
                                              new List<Claim>() { new Claim(ClaimTypes.Role, tip) },
                                             expires: DateTime.Now.AddMinutes(600),
                                             signingCredentials: credentials) ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
