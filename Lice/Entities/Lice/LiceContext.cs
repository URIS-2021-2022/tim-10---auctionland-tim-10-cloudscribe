﻿using Lice.Entities.Prioritet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Entities
{
    public class LiceContext : DbContext
    {
        public LiceContext(DbContextOptions<LiceContext> options) : base(options)
        {

        }

        public DbSet<LiceEntity> Lica { get; set; }

        public DbSet<FizickoLiceEntity> FizickaLica { get; set; }

        public DbSet<PravnoLiceEntity> PravnaLica { get; set; }

        public DbSet<PrioritetEntity> Prioriteti { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PrioritetEntity>()
                .HasData(new
                {
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    opisPrioriteta = "Vlasnik sistema za navodnjavanje"
                });
            builder.Entity<FizickoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("71b99b68-8e8f-4cc3-b8d2-d6badc704221"),
                    brojTelefona1 = "123456",
                    brojTelefona2 = "789456",
                    email = "email1",
                    brojRacuna = "brRac1",
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    ime = "Ime1",
                    prezime = "Prezime1"
                });
            builder.Entity<PravnoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("25499084-4d50-412b-9640-1ab07af33d4d"),
                    brojTelefona1 = "456123",
                    brojTelefona2 = "45214",
                    email = "email2",
                    brojRacuna = "brRac2",
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    naziv = "PravnoLice1",
                    faks = 125
                });

        }
    }
}
