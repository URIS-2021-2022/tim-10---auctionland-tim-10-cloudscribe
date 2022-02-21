using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UplataService.Entities
{
    /// <summary>
    /// Project's DB Context class which inherits DbContext class
    /// </summary>
    public partial class UplataDbContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UplataDbContext()
        {
        }

        /// <summary>
        /// Constructor which takes DbContextOptions.
        /// </summary>
        /// <param name="options">DbContextOptions object</param>
        public UplataDbContext(DbContextOptions<UplataDbContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// DbSet for table called BankaIzvod
        /// </summary>
        public virtual DbSet<BankaIzvod> BankaIzvod { get; set; }

        /// <summary>
        /// DbSet for table called BankaUplata
        /// </summary>
        public virtual DbSet<BankaUplata> BankaUplata { get; set; }

        /// <summary>
        /// DbSet for table called Kurs
        /// </summary>
        public virtual DbSet<Kurs> Kurs { get; set; }

        /// <summary>
        /// DbSet for table called Uplata
        /// </summary>
        public virtual DbSet<Uplata> Uplata { get; set; }

        // <summary>
        /// Overriden method which defines the configuration options used for database connectivity
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder object</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=147.91.175.176;Database=it45g2018; User ID=it45g2018; Password=ftnftn2018; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;");
            }
        }

        /// <summary>
        /// Method for configuring models
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder object</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankaIzvod>(entity =>
            {
                entity.HasKey(e => e.IzvodId)
                    .HasName("PK__BankaIzv__B08730A0B710B046");

                entity.ToTable("BankaIzvod", "UplataScheme");

                entity.Property(e => e.IzvodId).HasColumnName("izvodID");

                entity.Property(e => e.BankaUplataId).HasColumnName("bankaUplataID");

                entity.Property(e => e.Jmbg)
                    .HasColumnName("JMBG")
                    .HasMaxLength(13);

                entity.Property(e => e.Pib)
                    .HasColumnName("PIB")
                    .HasMaxLength(10);

                entity.HasOne(d => d.BankaUplata)
                    .WithMany(p => p.BankaIzvod)
                    .HasForeignKey(d => d.BankaUplataId)
                    .HasConstraintName("FK_BankaIzvod_BankaUplata");
            });

            modelBuilder.Entity<BankaUplata>(entity =>
            {
                entity.ToTable("BankaUplata", "UplataScheme");

                entity.Property(e => e.BankaUplataId).HasColumnName("bankaUplataID");

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

            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.ToTable("Kurs", "UplataScheme");

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

            modelBuilder.Entity<Uplata>(entity =>
            {
                entity.ToTable("Uplata", "UplataScheme");

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

                entity.Property(e => e.JavnoNadmetanjeId).HasColumnName("javnoNadmetanjeId");

                entity.Property(e => e.PozivNaBroj)
                    .HasColumnName("pozivNaBroj")
                    .HasMaxLength(50);

                entity.Property(e => e.SvrhaUplate)
                    .HasColumnName("svrhaUplate")
                    .HasMaxLength(50);

                entity.Property(e => e.UplatilacId).HasColumnName("uplatilacId");

                entity.Property(e => e.VisecaUplata).HasColumnName("visecaUplata");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
