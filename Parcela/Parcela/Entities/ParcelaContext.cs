using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Parcela.Entities.DeoParcele;
using Parcela.Entities.KatastarskaOpstina;
using Parcela.Entities.Parcela;
using Parcela.Entities.ZasticenaZona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities
{
    public class ParcelaContext : DbContext
    {
        

        public ParcelaContext(DbContextOptions<ParcelaContext> options) : base(options)
        {
            
        }

        public DbSet<ParcelaEntity> Parcela { get; set; }
        public DbSet<DeoParceleEntity> DeoParceleEntity { get; set; }
        public DbSet<KatastarskaOpstinaEntity> KatastarskaOpstina { get; set; }
        public DbSet<ZasticenaZonaEntity> ZasticenaZona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            

            
            modelBuilder.Entity<ParcelaEntity>()
            .HasData(new
            {
                ParcelaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                
                Povrsina = 100,
                KorisnikId = Guid.Parse("6a411c13-a295-48f7-8dbd-67596c3974c0"),
                BrojParcele = "1",
                KatastarskaOpstina = "Indjija",
                BrojListaNepokretnosti = "BLN",
                Kultura = "K",
                Klasa = "Klasa",
                Obradivost = "O",
                ZasticenaZona = "Z",
                OblikSvojine = "OS",
                Odvodnjavanje = "O",
                KulturaStvarnoStanje = "KSS",
                KlasaStvarnoStanje = "KSS",
                OBradivostStvarnoStanje = "OSS",
                ZasticenZonaStvarnoStanje = "ZZSS",
                OdvodnjavanjeStvarnoStanje = "OSS"

            });

            modelBuilder.Entity<DeoParceleEntity>()
                .HasData(new
                {
                    DeoParceleId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    ParcelaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    Povrsina = 100,
                    RedniBroj = 1,
                    Dodeljena = false
                });


            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    ImeKatastarskeOpstine = "Mladenburg"
                });

            modelBuilder.Entity<ZasticenaZonaEntity>()
                .HasData(new
                {
                    ZasticenZonaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    BrojZone = 1
                });
        }
    }

    

}

