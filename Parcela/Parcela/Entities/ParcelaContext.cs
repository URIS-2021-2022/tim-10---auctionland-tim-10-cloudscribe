using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Parcela.Entities.DeoParcele;
using Parcela.Entities.KatastarskaOpstina;
using Parcela.Entities.Parcela;
using Parcela.Entities.ZasticenaZona;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

            modelBuilder.Entity<ParcelaEntity>().HasMany<DeoParceleEntity>(i => i.DeoParcele).WithOne(c => c.Parcela).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ParcelaEntity>()
            .HasData(new
            {
                ParcelaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                Povrsina = 100,
                KorisnikId = Guid.Parse("6a411c13-a295-48f7-8dbd-67596c3974c0"),
                BrojParcele = "1",
                KatastarskaOpstinaId = Guid.Parse("1807A208-3BCA-49DE-A159-293E14393909"),
                BrojListaNepokretnosti = "5",
                Kultura = "Njive",
                Klasa = 1,
                Obradivost = "Obradivo",
                ZasticenaZonaId = Guid.Parse("AF2D6F85-D341-4433-8F21-3F28F816A79E"),
                OblikSvojine = "Drzavno",
                Odvodnjavanje = "Podvnodno",
                DeoParceleId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0")

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
                    KatastarskaOpstinaId = Guid.Parse("1807A208-3BCA-49DE-A159-293E14393909"),
                    ImeKatastarskeOpstine = "Cantavir"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("B438A02A-D1B7-479A-85CE-65FD6D9601AA"),
                    ImeKatastarskeOpstine = "Backi Vinogradi"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("EB74F014-1169-44FC-BF89-0ABE0A0DB7D7"),
                    ImeKatastarskeOpstine = "Bikovo"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("7242001A-B2E2-4513-8117-D797DFCF417B"),
                    ImeKatastarskeOpstine = "Bajmok"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("C763AFDA-7346-4FCA-82E1-2E5D6416FB71"),
                    ImeKatastarskeOpstine = "Djudjin"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("2736F15A-8EAD-4C5E-8EFF-2B9D7ADD73E0"),
                    ImeKatastarskeOpstine = "Zednik"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("6E7D325E-5F90-4D96-8277-0C924D5E0223"),
                    ImeKatastarskeOpstine = "Tavankut"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("529A1C5B-E0AA-4561-8298-756CA2D6C000"),
                    ImeKatastarskeOpstine = "Donji Grad"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("779341C2-3B97-4598-9329-09BC0C7DD3A4"),
                    ImeKatastarskeOpstine = "Stari Grad"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("F5CC25E4-EE78-4C8C-9986-1D80CF4BC225"),
                    ImeKatastarskeOpstine = "Novi Grad"
                });

            modelBuilder.Entity<KatastarskaOpstinaEntity>()
                .HasData(new
                {
                    KatastarskaOpstinaId = Guid.Parse("D3DCC333-2106-4F1A-8ED0-255BE4D9EBB9"),
                    ImeKatastarskeOpstine = "Palic"
                });


            modelBuilder.Entity<ZasticenaZonaEntity>()
                .HasData(new
                {
                    ZasticenZonaId = Guid.Parse("AF2D6F85-D341-4433-8F21-3F28F816A79E"),
                    BrojZone = 1
                });
            modelBuilder.Entity<ZasticenaZonaEntity>()
                .HasData(new
                {
                    ZasticenZonaId = Guid.Parse("66E5CE4A-453B-4D21-91D6-C533617778D3"),
                    BrojZone = 2
                });
            modelBuilder.Entity<ZasticenaZonaEntity>()
                .HasData(new
                {
                    ZasticenZonaId = Guid.Parse("2B605587-1CCD-4B2F-B988-957724C04FFA"),
                    BrojZone = 3
                });
            modelBuilder.Entity<ZasticenaZonaEntity>()
                .HasData(new
                {
                    ZasticenZonaId = Guid.Parse("B5CA4235-C02C-4020-A6A6-CB7146CA5FB8"),
                    BrojZone = 4
                });
        }
    }

    

}

