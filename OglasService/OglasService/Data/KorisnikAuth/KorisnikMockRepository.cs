using OglasService.Entities;
using OglasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace OglasService.Data
{
    public class KorisnikMockRepository : IKorisnikRepository
    {
        public static List<Korisnik> Korisnici { get; set; } = new List<Korisnik>();
        private readonly static int iterations = 1000;

        public KorisnikMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            var korisnik1 = HashPassword("testpassword");

            Korisnici.AddRange(new List<Korisnik>
            {
                new Korisnik
                {
                    Id = Guid.Parse("CFD7FA84-8A27-4119-B6DB-5CFC1B0C94E1"),
                    ImeKorisnika = "Petar",
                    PrezimeKorisnika = "Petrovic",
                    UserName = "petar.petrovic",
                    Email = "petar.petrovic@testmail.com",
                    Lozinka = korisnik1.Item1,
                    Salt = korisnik1.Item2
                }
            });

        }

        public bool UserWithCredentialsExists(string username, string password)
        {
            //Ukoliko je username jedinstveno ovo je uredu
            Korisnik korisnik = Korisnici.FirstOrDefault(u => u.UserName == username);

            if (korisnik == null)
            {
                return false;
            }

            //Ako smo našli korisnika sa tim korisničkim imenom proveravamo lozinku
            if (VerifyPassword(password, korisnik.Lozinka, korisnik.Salt))
            {
                return true;
            }
            return false;
        }

        private bool VerifyPassword(string password, string savedHash, string savedSalt)
        {
            var saltBytes = Convert.FromBase64String(savedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, iterations);
            if (Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == savedHash)
            {
                return true;
            }
            return false;
        }

        private Tuple<string, string> HashPassword(string password)
        {
            var sBytes = new byte[password.Length];
            new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);
            var salt = Convert.ToBase64String(sBytes);

            var derivedBytes = new Rfc2898DeriveBytes(password, sBytes, iterations);

            return new Tuple<string, string>
            (
                Convert.ToBase64String(derivedBytes.GetBytes(256)),
                salt
            );
        }
    }
}
