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
        public KorisnikContext(DbContextOptions<KorisnikContext> options) : base(options)
        {
            
        }

        public DbSet<Tip> Tipovi { get; set; }
        public DbSet<Korisnikk> Korisnici { get; set; }
        public DbSet<Komisija> Komisije { get; set; }


        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tip>()
              .HasData(new
              {
                  TipId = Guid.Parse("bda80420-444e-40d4-a97f-2d8be0df7c0c"),
                  TipKorisnika = "Operater"
              });
            modelBuilder.Entity<Tip>()
                .HasData(new
                {
                    TipId = Guid.Parse("719cbcae-ba05-4bdf-b0f8-636d79b70180"),
                    TipKorisnika = "Tehnicki sekretar"
                });
            modelBuilder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("4915ab80-5233-45a7-a7d2-b8c636fa934d"),
                   TipKorisnika = "Superuser"
               });
            modelBuilder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("f4ae8300-84cd-488f-90c7-d5b1d871bd9e"),
                   TipKorisnika = "Operator nadmetanja"
               });
            modelBuilder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("d2a484a7-e975-43c6-9604-21ac9459456f"),
                   TipKorisnika = "Administrator"
               });
            modelBuilder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("61643c5a-da3e-4388-86f8-4e0934de0e86"),
                   TipKorisnika = "Licitant"
               });
            modelBuilder.Entity<Tip>()
               .HasData(new
               {
                   TipId = Guid.Parse("9ddfc708-5a68-40ba-b76c-95b27e63ba9a"),
                   TipKorisnika = "Menadzer"
               });
            modelBuilder.Entity<Tip>()
                .HasData(new
                {
                    TipId = Guid.Parse("10d3f482-9538-448f-9399-bbbade1bc504"),
                    TipKorisnika = "Prva komisija"
                }
                );
            modelBuilder.Entity<Komisija>()
                .HasData(new
                {
                    KomisijaId = Guid.Parse("617b029a-a949-44d2-b7d2-366a9058e016")
                });
            modelBuilder.Entity<Korisnikk>()
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
