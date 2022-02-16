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
