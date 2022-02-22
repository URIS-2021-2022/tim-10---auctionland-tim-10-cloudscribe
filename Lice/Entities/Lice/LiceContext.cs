using Lice.Entities.Prioritet;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrioritetEntity>()
                .HasData(new
                {
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    opisPrioriteta = "Vlasnik sistema za navodnjavanje"
                });
            modelBuilder.Entity<PrioritetEntity>()
                .HasData(new
                {
                    prioritetId = Guid.Parse("00cdf29d-e0d0-4207-87b2-16486eda55ab"),
                    opisPrioriteta = ". Vlasnik zemljišta koje se graniči sa zemljištem koje se daje u zakup"
                });
            modelBuilder.Entity<PrioritetEntity>()
                .HasData(new
                {
                    prioritetId = Guid.Parse("08062c01-9bfd-4c85-8501-f5ab8c026f2a"),
                    opisPrioriteta = "Poljoprivrednik koji je upisan u Registar"
                });
            modelBuilder.Entity<PrioritetEntity>()
                .HasData(new
                {
                    prioritetId = Guid.Parse("7c9752fc-86a9-41e6-b4b8-c22b1c9a6ab9"),
                    opisPrioriteta = "Vlasnik zemljišta koje je najbliže zemljištu koje se daje u zakup"
                });
            modelBuilder.Entity<FizickoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("65f1a8da-433f-42d1-82f6-6b771ddde854"),
                    brojTelefona1 = "062586654",
                    brojTelefona2 = "061582236",
                    email = "mmarkovic@gmail.com",
                    brojRacuna = "80045875687",
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    ime = "Marko",
                    prezime = "Marković"
                });
            modelBuilder.Entity<FizickoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("8bb61e16-0c5c-4ea1-8e2b-9c48719c7aab"),
                    brojTelefona1 = "0665826695",
                    brojTelefona2 = "0656258965",
                    email = "nnikolic@gmail.com",
                    brojRacuna = "8008465687",
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    ime = "Nikola",
                    prezime = "Nikolić"
                });
            modelBuilder.Entity<PravnoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("529351b3-2c8c-41c6-abba-aa5feb564d06"),
                    brojTelefona1 = "0695784105",
                    brojTelefona2 = "0625486214",
                    email = "masterplast@gmail.com",
                    brojRacuna = "800458757",
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    naziv = "Masterplast",
                    faks = 024601785
                });
            modelBuilder.Entity<PravnoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("d05f182d-7ef0-484b-9045-3f0451605cdb"),
                    brojTelefona1 = "0645289956",
                    brojTelefona2 = "0625482685",
                    email = "pannonglobal@gmail.com",
                    brojRacuna = "8004574587",
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    naziv = "Pannonglobal",
                    faks = 024601785
                });

        }
    }
}
