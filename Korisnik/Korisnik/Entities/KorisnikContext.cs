using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Entities
{
    public class KorisnikContext : DbContext
    {
        private readonly IConfiguration configuration;

   
        public KorisnikContext(DbContextOptions<KorisnikContext> options) : base(options)
        {
            
        }

        public DbSet<Tip> Tipovi { get; set; }
        public DbSet<Korisnikk> Korisnici { get; set; }
        public DbSet<Komisija> Komisije { get; set; }


        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tip>()
                .HasData(new
                {
                    TipId = Guid.Parse("5b3dbaa4-60d0-4081-b848-752d8a2ab74e"),
                    TipKorisnika = "Operater"
                });

            builder.Entity<Tip>()
                .HasData(new
                {
                    TipId = Guid.Parse("719cbcae-ba05-4bdf-b0f8-636d79b70180"),
                    TipKorisnika = "Tehnicki sekretar"
                });
            builder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("4915ab80-5233-45a7-a7d2-b8c636fa934d"),
                   TipKorisnika = "Superuser"
               });
            builder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("f4ae8300-84cd-488f-90c7-d5b1d871bd9e"),
                   TipKorisnika = "Operator nadmetanja"
               });
            builder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("d2a484a7-e975-43c6-9604-21ac9459456f"),
                   TipKorisnika = "Administrator"
               });
            builder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("61643c5a-da3e-4388-86f8-4e0934de0e86"),
                   TipKorisnika = "Licitant"
               });
            builder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("9ddfc708-5a68-40ba-b76c-95b27e63ba9a"),
                   TipKorisnika = "Menadzer"
               });
            builder.Entity<Tip>()
                .HasData(new
                {
                    TipId = Guid.Parse("10d3f482-9538-448f-9399-bbbade1bc504"),
                    TipKorisnika = "Prva komisija"
                }
                );
            builder.Entity<Komisija>()
                .HasData(new
                {
                    KomisijaId = Guid.Parse("617b029a-a949-44d2-b7d2-366a9058e016")
                });
            builder.Entity<Korisnikk>()
                .HasData(new
                {
                    KorisnikId = Guid.Parse("850da794-6460-424d-bd01-731e2f54a8c8"),
                    KorisnikIme = "Teodora",
                    KorisnikPrezime = "Jovanovic",
                    KorisnikKorisnickoIme = "teajovanovic92",
                    KorisnikLozinka = "pera",
                    TipId = Guid.Parse("10d3f482-9538-448f-9399-bbbade1bc504"),
                    KomisijaId = Guid.Parse("617b029a-a949-44d2-b7d2-366a9058e016")

                }
                ) ;

        }
    }
}
