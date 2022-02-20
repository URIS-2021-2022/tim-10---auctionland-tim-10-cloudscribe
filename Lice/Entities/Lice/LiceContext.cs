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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PrioritetEntity>()
                .HasData(new
                {
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    opisPrioriteta = "Vlasnik sistema za navodnjavanje"
                });
            builder.Entity<PrioritetEntity>()
                .HasData(new
                {
                    prioritetId = Guid.Parse("00cdf29d-e0d0-4207-87b2-16486eda55ab"),
                    opisPrioriteta = ". Vlasnik zemljišta koje se graniči sa zemljištem koje se daje u zakup"
                });
            builder.Entity<PrioritetEntity>()
                .HasData(new
                {
                    prioritetId = Guid.Parse("08062c01-9bfd-4c85-8501-f5ab8c026f2a"),
                    opisPrioriteta = "Poljoprivrednik koji je upisan u Registar"
                });
            builder.Entity<PrioritetEntity>()
                .HasData(new
                {
                    prioritetId = Guid.Parse("7c9752fc-86a9-41e6-b4b8-c22b1c9a6ab9"),
                    opisPrioriteta = "Vlasnik zemljišta koje je najbliže zemljištu koje se daje u zakup"
                });
            builder.Entity<FizickoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("71b99b68-8e8f-4cc3-b8d2-d6badc704221"),
                    brojTelefona1 = "062586654",
                    brojTelefona2 = "061582236",
                    email = "mmarkovic@gmail.com",
                    brojRacuna = "80045875687",
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    ime = "Marko",
                    prezime = "Marković"
                });
            builder.Entity<FizickoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("71b99b68-8e8f-4cc3-b8d2-d6badc704221"),
                    brojTelefona1 = "0665826695",
                    brojTelefona2 = "0656258965",
                    email = "nnikolic@gmail.com",
                    brojRacuna = "8008465687",
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    ime = "Nikola",
                    prezime = "Nikolić"
                });
            builder.Entity<PravnoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("25499084-4d50-412b-9640-1ab07af33d4d"),
                    brojTelefona1 = "0695784105",
                    brojTelefona2 = "0625486214",
                    email = "masterplast@gmail.com",
                    brojRacuna = "800458757",
                    prioritetId = Guid.Parse("26797103-3a18-4750-9f27-33416e6e30d4"),
                    naziv = "Masterplast",
                    faks = 024601785
                });
            builder.Entity<PravnoLiceEntity>()
                .HasData(new
                {
                    liceId = Guid.Parse("25499084-4d50-412b-9640-1ab07af33d4d"),
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
