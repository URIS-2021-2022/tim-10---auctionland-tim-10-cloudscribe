﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OglasService.Entities;

namespace OglasService.Migrations
{
    [DbContext(typeof(OglasContext))]
    partial class OglasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OglasService.Entities.Oglas", b =>
                {
                    b.Property<Guid>("OglasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SluzbeniListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TekstOglasa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OglasId");

                    b.HasIndex("SluzbeniListId");

                    b.ToTable("Oglasi");

                    b.HasData(
                        new
                        {
                            OglasId = new Guid("6a411c13-a195-48f7-8dbd-67596c397444"),
                            SluzbeniListId = new Guid("6a411c13-a195-48f7-8dbd-67596c397475"),
                            TekstOglasa = "Javni oglas za davanje u zakup poljoprivrednog zemljišta u državnoj svojini"
                        },
                        new
                        {
                            OglasId = new Guid("6a411c13-a195-48f7-8dbd-67596c397498"),
                            SluzbeniListId = new Guid("6a411c13-a195-48f7-8dbd-67596c397411"),
                            TekstOglasa = "Javni oglas za davanje u zakup poljoprivrednog zemljišta u državnoj svojini"
                        });
                });

            modelBuilder.Entity("OglasService.Entities.SluzbeniList", b =>
                {
                    b.Property<Guid>("SluzbeniListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrojSluzbenogLista")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opstina")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SluzbeniListId");

                    b.ToTable("SluzbeniList");

                    b.HasData(
                        new
                        {
                            SluzbeniListId = new Guid("6a411c13-a195-48f7-8dbd-67596c397475"),
                            BrojSluzbenogLista = 12,
                            DatumIzdavanja = new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Opstina = "Novi Beograd"
                        },
                        new
                        {
                            SluzbeniListId = new Guid("6a411c13-a195-48f7-8dbd-67596c397411"),
                            BrojSluzbenogLista = 5,
                            DatumIzdavanja = new DateTime(2021, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Opstina = "Novi Sad"
                        });
                });

            modelBuilder.Entity("OglasService.Entities.Oglas", b =>
                {
                    b.HasOne("OglasService.Entities.SluzbeniList", "SluzbeniList")
                        .WithMany()
                        .HasForeignKey("SluzbeniListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SluzbeniList");
                });
#pragma warning restore 612, 618
        }
    }
}