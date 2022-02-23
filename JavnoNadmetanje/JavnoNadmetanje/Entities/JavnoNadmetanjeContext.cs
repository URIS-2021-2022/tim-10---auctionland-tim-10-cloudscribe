using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Entities
{
    public class JavnoNadmetanjeContext :DbContext
    {

        public JavnoNadmetanjeContext(DbContextOptions<JavnoNadmetanjeContext> options) : base(options)
        {

        }

        public DbSet<JavnoNadmetanjeEntity> JavnoNadmetanje { get; set; }
        public DbSet<JavnaLicitacijaEntity> JavnaLicitacija { get; set; }
        public DbSet<JzopEntity> JZOP{ get; set; }
        public DbSet<EtapaEntity> Etapa { get; set; }
        public DbSet<KorakCeneEntity> KorakCene { get; set; }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KorakCeneEntity>()
               .HasData(new
               {
                   korakCeneID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e961b"),
                   brojKoraka = 1

               });
            modelBuilder.Entity<KorakCeneEntity>()
               .HasData(new
               {
                   korakCeneID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e938b"),
                   brojKoraka = 2

               });
            modelBuilder.Entity<EtapaEntity>()
               .HasData(new
               {
                   etapaID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e968b"),
                   brojEtape = 1

               });
            modelBuilder.Entity<EtapaEntity>()
               .HasData(new
               {
                   etapaID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5873e968b"),
                   brojEtape = 2

               });
            modelBuilder.Entity<JzopEntity>()
               .HasData(new
               {
                   javnoNadmetanjeID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3573c0"),
                   datum = DateTime.Parse("2021-06-11T09:00:00"),
                   vremePocetka = DateTime.Parse("2021-06-11T09:00:00"),
                   vremeKraja = DateTime.Parse("2021-06-11T13:59:00"),
                   pocetnaCena = 55000,
                   izuzeto = false,
                   tip = 1,
                   izlicitiranaCena = 205000,
                   katastarskaOpstina = "Novi Grad",
                   periodZakupa = 5,
                   brojUcesnika = 15,
                   dopunaDepozita = 5000,
                   krug = 1,
                   status = "Prvi krug",
                   etapaID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e968b"),
                   brojJZOP = 2,
                   opisJZOP = "Drugi tip javnog nadmetanja",
                   adresaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                   liciterId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                   parcelaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0")

               });
            modelBuilder.Entity<JzopEntity>()
               .HasData(new
               {
                   javnoNadmetanjeID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c4973c0"),
                   datum = DateTime.Parse("2021-06-11T09:00:00"),
                   vremePocetka = DateTime.Parse("2021-06-11T09:00:00"),
                   vremeKraja = DateTime.Parse("2021-06-11T13:59:00"),
                   pocetnaCena = 55000,
                   izuzeto = false,
                   tip = 1,
                   izlicitiranaCena = 205000,
                   katastarskaOpstina = "Novi Grad",
                   periodZakupa = 5,
                   brojUcesnika = 45,
                   dopunaDepozita = 5000,
                   krug = 1,
                   status = "Prvi krug",
                   etapaID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5873e968b"),
                   brojJZOP = 2,
                   opisJZOP = "Drugi tip javnog nadmetanja",
                   adresaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                   liciterId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                   parcelaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0")

               });
            modelBuilder.Entity<JavnaLicitacijaEntity>()
               .HasData(new
               {
                   javnoNadmetanjeID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3973c0"),
                   datum = DateTime.Parse("2021-06-11T09:00:00"),
                   vremePocetka = DateTime.Parse("2021-06-11T09:00:00"),
                   vremeKraja = DateTime.Parse("2021-06-11T13:59:00"),
                   pocetnaCena = 55000,
                   izuzeto = false,
                   tip = 1,
                   izlicitiranaCena = 205000,
                   katastarskaOpstina = "Novi Grad",
                   periodZakupa = 5,
                   brojUcesnika = 15,
                   dopunaDepozita = 5000,
                   krug = 1,
                   status = "Prvi krug",
                   etapaID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5873e968b"),
                   brojJavneLicitacije = 1,
                   opisJavneLicitacije = "Prvi tip javnog nadmetanja",
                   korakCeneID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e961b"),
                   adresaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                   liciterId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                   parcelaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0")

               });
            modelBuilder.Entity<JavnaLicitacijaEntity>()
                .HasData(new
                {
                    javnoNadmetanjeID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    datum = DateTime.Parse("2021-06-01T09:00:00"),
                    vremePocetka = DateTime.Parse("2021-06-01T09:00:00"),
                    vremeKraja = DateTime.Parse("2021-06-01T13:59:00"),
                    pocetnaCena = 50000,
                    izuzeto = false,
                    tip = 1,
                    izlicitiranaCena = 200000,
                    katastarskaOpstina = "Novi Grad",
                    periodZakupa = 5,
                    brojUcesnika = 25,
                    dopunaDepozita = 5000,
                    krug = 1,
                    status = "Prvi krug",
                    etapaID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e968b"),
                    brojJavneLicitacije = 2,
                    opisJavneLicitacije = "Prvi tip javnog nadmetanja",
                    korakCeneID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e938b"),
                    adresaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    liciterId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    parcelaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0")
                });

            
            
            
        }
    }
}
