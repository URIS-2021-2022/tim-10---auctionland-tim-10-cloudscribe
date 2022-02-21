﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcela.Entities;

namespace Parcela.Migrations
{
    [DbContext(typeof(ParcelaContext))]
    [Migration("20220221193301_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Parcela.Entities.DeoParcele.DeoParceleEntity", b =>
                {
                    b.Property<Guid>("DeoParceleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Dodeljena")
                        .HasColumnType("bit");

                    b.Property<Guid>("ParcelaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Povrsina")
                        .HasColumnType("int");

                    b.Property<int>("RedniBroj")
                        .HasColumnType("int");

                    b.HasKey("DeoParceleId");

                    b.HasIndex("ParcelaId");

                    b.ToTable("DeoParceleEntity");

                    b.HasData(
                        new
                        {
                            DeoParceleId = new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                            Dodeljena = false,
                            ParcelaId = new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                            Povrsina = 100,
                            RedniBroj = 1
                        });
                });

            modelBuilder.Entity("Parcela.Entities.KatastarskaOpstina.KatastarskaOpstinaEntity", b =>
                {
                    b.Property<Guid>("KatastarskaOpstinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImeKatastarskeOpstine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KatastarskaOpstinaId");

                    b.ToTable("KatastarskaOpstina");

                    b.HasData(
                        new
                        {
                            KatastarskaOpstinaId = new Guid("1807a208-3bca-49de-a159-293e14393909"),
                            ImeKatastarskeOpstine = "Cantavir"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("b438a02a-d1b7-479a-85ce-65fd6d9601aa"),
                            ImeKatastarskeOpstine = "Backi Vinogradi"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("eb74f014-1169-44fc-bf89-0abe0a0db7d7"),
                            ImeKatastarskeOpstine = "Bikovo"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("7242001a-b2e2-4513-8117-d797dfcf417b"),
                            ImeKatastarskeOpstine = "Bajmok"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("c763afda-7346-4fca-82e1-2e5d6416fb71"),
                            ImeKatastarskeOpstine = "Djudjin"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("2736f15a-8ead-4c5e-8eff-2b9d7add73e0"),
                            ImeKatastarskeOpstine = "Zednik"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("6e7d325e-5f90-4d96-8277-0c924d5e0223"),
                            ImeKatastarskeOpstine = "Tavankut"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("529a1c5b-e0aa-4561-8298-756ca2d6c000"),
                            ImeKatastarskeOpstine = "Donji Grad"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("779341c2-3b97-4598-9329-09bc0c7dd3a4"),
                            ImeKatastarskeOpstine = "Stari Grad"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("f5cc25e4-ee78-4c8c-9986-1d80cf4bc225"),
                            ImeKatastarskeOpstine = "Novi Grad"
                        },
                        new
                        {
                            KatastarskaOpstinaId = new Guid("d3dcc333-2106-4f1a-8ed0-255be4d9ebb9"),
                            ImeKatastarskeOpstine = "Palic"
                        });
                });

            modelBuilder.Entity("Parcela.Entities.Parcela.ParcelaEntity", b =>
                {
                    b.Property<Guid>("ParcelaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojListaNepokretnosti")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojParcele")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DeoParceleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KatastarskaOpstinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Klasa")
                        .HasColumnType("int");

                    b.Property<Guid>("KorisnikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Kultura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OblikSvojine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Obradivost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Odvodnjavanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Povrsina")
                        .HasColumnType("int");

                    b.Property<Guid>("ZasticenaZonaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ParcelaId");

                    b.HasIndex("KatastarskaOpstinaId");

                    b.HasIndex("ZasticenaZonaId");

                    b.ToTable("Parcela");

                    b.HasData(
                        new
                        {
                            ParcelaId = new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                            BrojListaNepokretnosti = "5",
                            BrojParcele = "1",
                            DeoParceleId = new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                            KatastarskaOpstinaId = new Guid("1807a208-3bca-49de-a159-293e14393909"),
                            Klasa = 1,
                            KorisnikId = new Guid("6a411c13-a295-48f7-8dbd-67596c3974c0"),
                            Kultura = "Njive",
                            OblikSvojine = "Drzavno",
                            Obradivost = "Obradivo",
                            Odvodnjavanje = "Podvnodno",
                            Povrsina = 100,
                            ZasticenaZonaId = new Guid("af2d6f85-d341-4433-8f21-3f28f816a79e")
                        });
                });

            modelBuilder.Entity("Parcela.Entities.ZasticenaZona.ZasticenaZonaEntity", b =>
                {
                    b.Property<Guid>("ZasticenZonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrojZone")
                        .HasColumnType("int");

                    b.HasKey("ZasticenZonaId");

                    b.ToTable("ZasticenaZona");

                    b.HasData(
                        new
                        {
                            ZasticenZonaId = new Guid("af2d6f85-d341-4433-8f21-3f28f816a79e"),
                            BrojZone = 1
                        },
                        new
                        {
                            ZasticenZonaId = new Guid("66e5ce4a-453b-4d21-91d6-c533617778d3"),
                            BrojZone = 2
                        },
                        new
                        {
                            ZasticenZonaId = new Guid("2b605587-1ccd-4b2f-b988-957724c04ffa"),
                            BrojZone = 3
                        },
                        new
                        {
                            ZasticenZonaId = new Guid("b5ca4235-c02c-4020-a6a6-cb7146ca5fb8"),
                            BrojZone = 4
                        });
                });

            modelBuilder.Entity("Parcela.Entities.DeoParcele.DeoParceleEntity", b =>
                {
                    b.HasOne("Parcela.Entities.Parcela.ParcelaEntity", "Parcela")
                        .WithMany("DeoParcele")
                        .HasForeignKey("ParcelaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parcela");
                });

            modelBuilder.Entity("Parcela.Entities.Parcela.ParcelaEntity", b =>
                {
                    b.HasOne("Parcela.Entities.KatastarskaOpstina.KatastarskaOpstinaEntity", "KatastarskaOpstinaEntity")
                        .WithMany("parcelaEntity")
                        .HasForeignKey("KatastarskaOpstinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parcela.Entities.ZasticenaZona.ZasticenaZonaEntity", "ZasticenaZonaEntity")
                        .WithMany()
                        .HasForeignKey("ZasticenaZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KatastarskaOpstinaEntity");

                    b.Navigation("ZasticenaZonaEntity");
                });

            modelBuilder.Entity("Parcela.Entities.KatastarskaOpstina.KatastarskaOpstinaEntity", b =>
                {
                    b.Navigation("parcelaEntity");
                });

            modelBuilder.Entity("Parcela.Entities.Parcela.ParcelaEntity", b =>
                {
                    b.Navigation("DeoParcele");
                });
#pragma warning restore 612, 618
        }
    }
}
