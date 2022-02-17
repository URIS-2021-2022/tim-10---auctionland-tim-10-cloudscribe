﻿// <auto-generated />
using System;
using Lice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lice.Migrations
{
    [DbContext(typeof(LiceContext))]
    partial class LiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lice.Entities.LiceEntity", b =>
                {
                    b.Property<Guid>("liceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brojTelefona1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brojTelefona2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("prioritetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("liceId");

                    b.HasIndex("prioritetId");

                    b.ToTable("Lica");

                    b.HasDiscriminator<string>("Discriminator").HasValue("LiceEntity");
                });

            modelBuilder.Entity("Lice.Entities.Prioritet.PrioritetEntity", b =>
                {
                    b.Property<Guid>("prioritetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("opisPrioriteta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("prioritetId");

                    b.ToTable("Prioriteti");

                    b.HasData(
                        new
                        {
                            prioritetId = new Guid("26797103-3a18-4750-9f27-33416e6e30d4"),
                            opisPrioriteta = "Vlasnik sistema za navodnjavanje"
                        },
                        new
                        {
                            prioritetId = new Guid("00cdf29d-e0d0-4207-87b2-16486eda55ab"),
                            opisPrioriteta = ". Vlasnik zemljišta koje se graniči sa zemljištem koje se daje u zakup"
                        },
                        new
                        {
                            prioritetId = new Guid("08062c01-9bfd-4c85-8501-f5ab8c026f2a"),
                            opisPrioriteta = "Poljoprivrednik koji je upisan u Registar"
                        },
                        new
                        {
                            prioritetId = new Guid("7c9752fc-86a9-41e6-b4b8-c22b1c9a6ab9"),
                            opisPrioriteta = "Vlasnik zemljišta koje je najbliže zemljištu koje se daje u zakup"
                        });
                });

            modelBuilder.Entity("Lice.Entities.FizickoLiceEntity", b =>
                {
                    b.HasBaseType("Lice.Entities.LiceEntity");

                    b.Property<string>("ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FizickoLiceEntity");

                    b.HasData(
                        new
                        {
                            liceId = new Guid("71b99b68-8e8f-4cc3-b8d2-d6badc704221"),
                            brojRacuna = "brRac1",
                            brojTelefona1 = "123456",
                            brojTelefona2 = "789456",
                            email = "email1",
                            prioritetId = new Guid("26797103-3a18-4750-9f27-33416e6e30d4"),
                            ime = "Ime1",
                            prezime = "Prezime1"
                        });
                });

            modelBuilder.Entity("Lice.Entities.PravnoLiceEntity", b =>
                {
                    b.HasBaseType("Lice.Entities.LiceEntity");

                    b.Property<int>("faks")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PravnoLiceEntity");

                    b.HasData(
                        new
                        {
                            liceId = new Guid("25499084-4d50-412b-9640-1ab07af33d4d"),
                            brojRacuna = "brRac2",
                            brojTelefona1 = "456123",
                            brojTelefona2 = "45214",
                            email = "email2",
                            prioritetId = new Guid("26797103-3a18-4750-9f27-33416e6e30d4"),
                            faks = 125,
                            naziv = "PravnoLice1"
                        });
                });

            modelBuilder.Entity("Lice.Entities.LiceEntity", b =>
                {
                    b.HasOne("Lice.Entities.Prioritet.PrioritetEntity", "Prioritet")
                        .WithMany()
                        .HasForeignKey("prioritetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prioritet");
                });
#pragma warning restore 612, 618
        }
    }
}
