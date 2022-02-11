﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class LiciterContext: DbContext
    {
        private readonly IConfiguration configuration;

        public LiciterContext(DbContextOptions options, IConfiguration configuration): base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Liciter> Liciteri { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Zastupnik> Zastupnici { get; set; }

       protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Liciter>().HasData(new
            {
                LiciterId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0")
            });
            builder.Entity<Liciter>().HasData(new
            {
                LiciterId = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b")
            });

            builder.Entity<Kupac>()
                .HasMany<Zastupnik>(k => k.Zastupnici)
                .WithOne(z => z.Kupac)
                .HasForeignKey(z => z.KupacId);
                
                            
            /*builder.Entity<Kupac>().HasData(new
            {
                KupacId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                ImeKupca = "Dzejn",
                PrezimeKupca = "Ostin",
                DatumPocetkaZabrane = DateTime.Parse("2021-12-15T09:00:00"),
                DatumPrestankaZabrane = DateTime.Parse("2022-5-15T09:00:00"),
                DuzinaTrajanjaZabrane = 365,
                ImaZabranu = true,
                OstvarenaPovrsina = 15500
            });
            builder.Entity<Zastupnik>().HasData(new
            {
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a66"),
                ImeZastupnika = "Novak",
                PrezimeZastupnika = "Djokovic",
                Jmbg = 163588962,
                Adresa = "Beogradska 25",
                NazivDrzave = "Srbija",
                BrojTable = 255
            });
            builder.Entity<Zastupnik>().HasData(new
            {
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a52"),
                ImeZastupnika = "Petar",
                PrezimeZastupnika = "Petrovic",
                Jmbg = 58966345,
                Adresa = "Narodnog Fronta 13",
                NazivDrzave = "Srbija",
                BrojTable = 365
            });*/
        }
    }
}
