using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Entities
{
    public class AdresaContext : DbContext
    {
        public AdresaContext(DbContextOptions<AdresaContext> options) : base(options)
        {

        }

        public DbSet<DrzavaEntity> Drzave { get; set; }

        public DbSet<AdresaEntity> Adrese { get; set; }


        /// <summary>
        /// Popunjava bazu inicijalnim podacima
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DrzavaEntity>()
                .HasData(new
                {
                    DrzavaId = Guid.Parse("170960f3-f8e0-4614-aff2-653aadf5c720"),
                    NazivDrzave = "Drzava1"
                });

            builder.Entity<DrzavaEntity>()
                .HasData(new
                {
                    DrzavaId = Guid.Parse("c8a9ffbc-db56-46ff-a54a-948c91550189"),
                    NazivDrzave = "Drzava2"
                });


            builder.Entity<AdresaEntity>().HasData(
                new
                {
                    AdresaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    Ulica = "Ulica1",
                    Broj = "1",
                    Mesto = "Mesto1",
                    PostanskiBroj = 123,
                    DrzavaId = Guid.Parse("170960f3-f8e0-4614-aff2-653aadf5c720")
                });
            builder.Entity<AdresaEntity>().HasData(
                new AdresaEntity
                {
                    AdresaId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                    Ulica = "Ulica2",
                    Broj = "2",
                    Mesto = "Mesto2",
                    PostanskiBroj = 123456,
                    DrzavaId = Guid.Parse("c8a9ffbc-db56-46ff-a54a-948c91550189"),
                });
        }

    }

}
