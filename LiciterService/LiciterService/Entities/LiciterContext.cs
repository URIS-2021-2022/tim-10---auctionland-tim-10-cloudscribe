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
        private readonly IConfiguration configuration;

        public LiciterContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Liciter> Liciteri { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Zastupnik> Zastupnici { get; set; }

       protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<Zastupnik>()
           .HasOne<Kupac>(i => i.Kupac)
           .WithMany(c => c.Zastupnici)
           .IsRequired()
           .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Liciter>().HasData(new
            {
                LiciterId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                KupacId= Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a66")
                //ImeLicitera="Nikola",
                //PrezimeLicitera="Tesla"
            });
            builder.Entity<Liciter>().HasData(new
            {
                LiciterId = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                KupacId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a36"),
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a52")
                //ImeLicitera = "Mihajlo",
                //PrezimeLicitera = "Pupin"
            });

            builder.Entity<Kupac>().HasData(new
            {
                KupacId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a36"),
                DatumPocetkaZabrane = DateTime.Parse("2020-11-15T09:00:00"),
                DatumPrestankaZabrane = DateTime.Parse("2021-11-15T09:00:00"),
                DuzinaTrajanjaZabrane = 365,
                ImaZabranu = true,
                OstvarenaPovrsina = 1500000
            });

            builder.Entity<Kupac>().HasData(new
            {
                KupacId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                DatumPocetkaZabrane = DateTime.Parse("2021-12-15T09:00:00"),
                DatumPrestankaZabrane = DateTime.Parse("2022-5-15T09:00:00"),
                DuzinaTrajanjaZabrane = 365,
                ImaZabranu = true,
                OstvarenaPovrsina = 15500
            });
            builder.Entity<Zastupnik>().HasData(new
            {
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a66"),
                Jmbg = "1635889629999",
                BrojPasosa = "987654321",
                NazivDrzave = "Srbija",
                BrojTable = 255,
                KupacId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029")
            });
            builder.Entity<Zastupnik>().HasData(new
            {
                ZastupnikId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a52"),
                Jmbg = "5896634547231",
                BrojPasosa="123456789",
                NazivDrzave = "Srbija",
                BrojTable = 365,
                KupacId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a36")
            });
        }
    }
}
