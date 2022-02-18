﻿// <auto-generated />
using System;
using Korisnik.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Korisnik.Migrations
{
    [DbContext(typeof(KorisnikContext))]
    partial class KorisnikContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Korisnik.Entities.Komisija", b =>
                {
                    b.Property<Guid>("KomisijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KomisijaId");

                    b.ToTable("Komisije");

                    b.HasData(
                        new
                        {
                            KomisijaId = new Guid("617b029a-a949-44d2-b7d2-366a9058e016")
                        });
                });

            modelBuilder.Entity("Korisnik.Entities.Korisnikk", b =>
                {
                    b.Property<Guid>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KomisijaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KorisnikIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnikKorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnikLozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnikPrezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("KorisnikId");

                    b.HasIndex("TipId");

                    b.ToTable("Korisnici");

                    b.HasData(
                        new
                        {
                            KorisnikId = new Guid("850da794-6460-424d-bd01-731e2f54a8c8"),
                            KomisijaId = new Guid("617b029a-a949-44d2-b7d2-366a9058e016"),
                            KorisnikIme = "Teodora",
                            KorisnikKorisnickoIme = "teajovanovic92",
                            KorisnikLozinka = "pera",
                            KorisnikPrezime = "Jovanovic",
                            TipId = new Guid("10d3f482-9538-448f-9399-bbbade1bc504")
                        });
                });

            modelBuilder.Entity("Korisnik.Entities.Tip", b =>
                {
                    b.Property<Guid>("TipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipKorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipId");

                    b.ToTable("Tipovi");

                    b.HasData(
                        new
                        {
                            TipId = new Guid("5b3dbaa4-60d0-4081-b848-752d8a2ab74e"),
                            TipKorisnika = "Operater"
                        },
                        new
                        {
                            TipId = new Guid("719cbcae-ba05-4bdf-b0f8-636d79b70180"),
                            TipKorisnika = "Tehnicki sekretar"
                        },
                        new
                        {
                            TipId = new Guid("4915ab80-5233-45a7-a7d2-b8c636fa934d"),
                            TipKorisnika = "Superuser"
                        },
                        new
                        {
                            TipId = new Guid("f4ae8300-84cd-488f-90c7-d5b1d871bd9e"),
                            TipKorisnika = "Operator nadmetanja"
                        },
                        new
                        {
                            TipId = new Guid("d2a484a7-e975-43c6-9604-21ac9459456f"),
                            TipKorisnika = "Administrator"
                        },
                        new
                        {
                            TipId = new Guid("61643c5a-da3e-4388-86f8-4e0934de0e86"),
                            TipKorisnika = "Licitant"
                        },
                        new
                        {
                            TipId = new Guid("9ddfc708-5a68-40ba-b76c-95b27e63ba9a"),
                            TipKorisnika = "Menadzer"
                        },
                        new
                        {
                            TipId = new Guid("10d3f482-9538-448f-9399-bbbade1bc504"),
                            TipKorisnika = "Prva komisija"
                        });
                });

            modelBuilder.Entity("Korisnik.Entities.Korisnikk", b =>
                {
                    b.HasOne("Korisnik.Entities.Tip", "Tip")
                        .WithMany()
                        .HasForeignKey("TipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tip");
                });
#pragma warning restore 612, 618
        }
    }
}
