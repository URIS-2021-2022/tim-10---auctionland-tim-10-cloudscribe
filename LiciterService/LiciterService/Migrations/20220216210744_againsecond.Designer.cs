﻿// <auto-generated />
using System;
using LiciterService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LiciterService.Migrations
{
    [DbContext(typeof(LiciterContext))]
    [Migration("20220216210744_againsecond")]
    partial class againsecond
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiciterService.Entities.Kupac", b =>
                {
                    b.Property<Guid>("KupacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DatumPocetkaZabrane")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumPrestankaZabrane")
                        .HasColumnType("datetime2");

                    b.Property<int>("DuzinaTrajanjaZabrane")
                        .HasColumnType("int");

                    b.Property<bool>("ImaZabranu")
                        .HasColumnType("bit");

                    b.Property<int>("OstvarenaPovrsina")
                        .HasColumnType("int");

                    b.HasKey("KupacId");

                    b.ToTable("Kupci");

                    b.HasData(
                        new
                        {
                            KupacId = new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a36"),
                            DatumPocetkaZabrane = new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            DatumPrestankaZabrane = new DateTime(2021, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            DuzinaTrajanjaZabrane = 365,
                            ImaZabranu = true,
                            OstvarenaPovrsina = 1500000
                        },
                        new
                        {
                            KupacId = new Guid("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                            DatumPocetkaZabrane = new DateTime(2021, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            DatumPrestankaZabrane = new DateTime(2022, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            DuzinaTrajanjaZabrane = 365,
                            ImaZabranu = true,
                            OstvarenaPovrsina = 15500
                        });
                });

            modelBuilder.Entity("LiciterService.Entities.Liciter", b =>
                {
                    b.Property<Guid>("LiciterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImeLicitera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrezimeLicitera")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LiciterId");

                    b.ToTable("Liciteri");

                    b.HasData(
                        new
                        {
                            LiciterId = new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                            ImeLicitera = "Nikola",
                            PrezimeLicitera = "Tesla"
                        },
                        new
                        {
                            LiciterId = new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                            ImeLicitera = "Mihajlo",
                            PrezimeLicitera = "Pupin"
                        });
                });

            modelBuilder.Entity("LiciterService.Entities.Zastupnik", b =>
                {
                    b.Property<Guid>("ZastupnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojPasosa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrojTable")
                        .HasColumnType("int");

                    b.Property<string>("Jmbg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KupacId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivDrzave")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZastupnikId");

                    b.HasIndex("KupacId");

                    b.ToTable("Zastupnici");

                    b.HasData(
                        new
                        {
                            ZastupnikId = new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a66"),
                            BrojPasosa = "987654321",
                            BrojTable = 255,
                            Jmbg = "1635889629999",
                            KupacId = new Guid("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                            NazivDrzave = "Srbija"
                        },
                        new
                        {
                            ZastupnikId = new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a52"),
                            BrojPasosa = "123456789",
                            BrojTable = 365,
                            Jmbg = "5896634547231",
                            KupacId = new Guid("044f3de0-a9dd-4c2e-b745-89976a1b2a36"),
                            NazivDrzave = "Srbija"
                        });
                });

            modelBuilder.Entity("LiciterService.Entities.Zastupnik", b =>
                {
                    b.HasOne("LiciterService.Entities.Kupac", "Kupac")
                        .WithMany("Zastupnici")
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("LiciterService.Entities.Kupac", b =>
                {
                    b.Navigation("Zastupnici");
                });
#pragma warning restore 612, 618
        }
    }
}
