using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Entities
{
    public class LicitacijaContext : DbContext
    {


        public LicitacijaContext(DbContextOptions<LicitacijaContext> options) : base(options)
        {

        }

        public DbSet<LicitacijaModel> Licitacija { get; set; }


        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LicitacijaModel>()
                .HasData(new
                {
                    licitacijaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    brojLicitacije = 1,
                    godinaLicitacije = 2021,
                    datumRaspisivanja = DateTime.Parse("2021-06-01T09:00:00"),
                    ogranicenje = 0,
                    krugLicitacije = 1,
                    rokZaPrijave = DateTime.Parse("2021-07-01T23:59:00")
                });

            modelBuilder.Entity<LicitacijaModel>()
                .HasData(new
                {
                    licitacijaId = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                    brojLicitacije = 2,
                    godinaLicitacije = 2022,
                    datumRaspisivanja = DateTime.Parse("2021-11-15T09:00:00"),
                    ogranicenje = 1,
                    krugLicitacije = 1,
                    rokZaPrijave = DateTime.Parse("2021-11-25T09:00:00")
                });
        }



    }
}
