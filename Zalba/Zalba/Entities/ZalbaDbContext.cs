using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zalba.Entities
{
    public partial class ZalbaDbContext : DbContext
    {
        public ZalbaDbContext()
        {
        }

        public ZalbaDbContext(DbContextOptions<ZalbaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kurs> Kurs { get; set; }
        public virtual DbSet<RadnjaNaOsnovuZalbe> RadnjaNaOsnovuZalbe { get; set; }
        public virtual DbSet<StatusZalbe> StatusZalbe { get; set; }
        public virtual DbSet<TipZalbe> TipZalbe { get; set; }
        public virtual DbSet<Uplata> Uplata { get; set; }
        public virtual DbSet<Zalba> Zalba { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=147.91.175.176;Database=it45g2018; User ID=it45g2018; Password=ftnftn2018; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.ToTable("Kurs", "auctionLand");

                entity.Property(e => e.KursId).HasColumnName("kursID");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Valuta)
                    .HasColumnName("valuta")
                    .HasMaxLength(5);

                entity.Property(e => e.Vrednost)
                    .HasColumnName("vrednost")
                    .HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<RadnjaNaOsnovuZalbe>(entity =>
            {
                entity.ToTable("RadnjaNaOsnovuZalbe", "auctionLand");

                entity.Property(e => e.RadnjaNaOsnovuZalbeId).HasColumnName("radnjaNaOsnovuZalbeID");

                entity.Property(e => e.RadnjaNaOsnovuZalbe1)
                    .HasColumnName("radnjaNaOsnovuZalbe")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<StatusZalbe>(entity =>
            {
                entity.ToTable("StatusZalbe", "auctionLand");

                entity.Property(e => e.StatusZalbeId).HasColumnName("statusZalbeID");

                entity.Property(e => e.StatusZalbe1)
                    .HasColumnName("statusZalbe")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TipZalbe>(entity =>
            {
                entity.ToTable("TipZalbe", "auctionLand");

                entity.Property(e => e.TipZalbeId).HasColumnName("tipZalbeID");

                entity.Property(e => e.TipZalbe1)
                    .HasColumnName("tipZalbe")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Uplata>(entity =>
            {
                entity.ToTable("Uplata", "auctionLand");

                entity.Property(e => e.UplataId).HasColumnName("uplataID");

                entity.Property(e => e.BrojRacuna)
                    .HasColumnName("brojRacuna")
                    .HasMaxLength(30);

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iznos)
                    .HasColumnName("iznos")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PozivNaBroj)
                    .HasColumnName("pozivNaBroj")
                    .HasMaxLength(50);

                entity.Property(e => e.SvrhaUplate)
                    .HasColumnName("svrhaUplate")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Zalba>(entity =>
            {
                entity.ToTable("Zalba", "auctionLand");

                entity.Property(e => e.ZalbaId).HasColumnName("zalbaID");

                entity.Property(e => e.BrojOdluke)
                    .HasColumnName("brojOdluke")
                    .HasMaxLength(50);

                entity.Property(e => e.BrojResenja)
                    .HasColumnName("brojResenja")
                    .HasMaxLength(50);

                entity.Property(e => e.DatumPodnosenja)
                    .HasColumnName("datumPodnosenja")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatumResenja)
                    .HasColumnName("datumResenja")
                    .HasColumnType("datetime");

                entity.Property(e => e.Obrazlozenje)
                    .HasColumnName("obrazlozenje")
                    .HasMaxLength(200);

                entity.Property(e => e.RadnjaNaOsnovuZalbeId).HasColumnName("radnjaNaOsnovuZalbeID");

                entity.Property(e => e.RazlogZalbe)
                    .HasColumnName("razlogZalbe")
                    .HasMaxLength(200);

                entity.Property(e => e.StatusZalbeId).HasColumnName("statusZalbeID");

                entity.Property(e => e.TipZalbeId).HasColumnName("tipZalbeID");

                entity.HasOne(d => d.RadnjaNaOsnovuZalbe)
                    .WithMany(p => p.Zalba)
                    .HasForeignKey(d => d.RadnjaNaOsnovuZalbeId)
                    .HasConstraintName("FK_Radnja_radnjaNaOsnovuZalbeID");

                entity.HasOne(d => d.StatusZalbe)
                    .WithMany(p => p.Zalba)
                    .HasForeignKey(d => d.StatusZalbeId)
                    .HasConstraintName("FK_Status_statusZalbeID");

                entity.HasOne(d => d.TipZalbe)
                    .WithMany(p => p.Zalba)
                    .HasForeignKey(d => d.TipZalbeId)
                    .HasConstraintName("FK_Tip_tipZalbeID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
