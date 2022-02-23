using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class LiciterContext: DbContext
    {
        

        public LiciterContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Liciter> Liciteri { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Zastupnik> Zastupnici { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Zastupnik>()
           .HasMany<Kupac>(i => i.Kupci)
           .WithOne(c => c.Zastupnik)
           .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Liciter>().HasData(new
            {
                LiciterId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                KupacId= Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523055"),
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a66"),
                liceId = Guid.Parse("d05f182d-7ef0-484b-9045-3f0451605cdb")
            });
            modelBuilder.Entity<Liciter>().HasData(new
            {
                LiciterId = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                KupacId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a36"),
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a52"),
                liceId = Guid.Parse("8bb61e16-0c5c-4ea1-8e2b-9c48719c7aab")
            });

            modelBuilder.Entity<Kupac>().HasData(new
            {
                KupacId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a36"),
                DatumPocetkaZabrane = DateTime.Parse("2020-11-15T09:00:00"),
                DatumPrestankaZabrane = DateTime.Parse("2021-11-15T09:00:00"),
                DuzinaTrajanjaZabrane = 365,
                ImaZabranu = true,
                OstvarenaPovrsina = 1500000,
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a52")
            });

            modelBuilder.Entity<Kupac>().HasData(new
            {
                KupacId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523055"),
                DatumPocetkaZabrane = DateTime.Parse("2021-12-15T09:00:00"),
                DatumPrestankaZabrane = DateTime.Parse("2022-5-15T09:00:00"),
                DuzinaTrajanjaZabrane = 365,
                ImaZabranu = true,
                OstvarenaPovrsina = 15500,
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a52")
            });
            modelBuilder.Entity<Zastupnik>().HasData(new
            {
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a66"),
                Jmbg = "1635889629999",
                BrojPasosa = "987654321",
                NazivDrzave = "Srbija",
                BrojTable = 255,
                AdresaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                KupacId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523077")
            });
            modelBuilder.Entity<Zastupnik>().HasData(new
            {
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a52"),
                Jmbg = "5896634547231",
                BrojPasosa="123456789",
                NazivDrzave = "Srbija",
                BrojTable = 365,
                AdresaId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                KupacId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a36")  
            });
        }
    }
}
