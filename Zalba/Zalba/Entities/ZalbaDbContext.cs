using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ZalbaService.Entities
{
    /// <summary>
    /// Project's DB Context class which inherits DbContext class
    /// </summary>
    public partial class ZalbaDbContext : DbContext
    {
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Default constructor
        /// </summary>
        public ZalbaDbContext()
        {
        }

        /// <summary>
        /// Constructor which takes DbContextOptions.
        /// </summary>
        /// <param name="options">DbContextOptions object</param>
        /// <param name="configuration">configuration</param>

        public ZalbaDbContext(DbContextOptions<ZalbaDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// DbSet for table called RadnjaNaOsnovuZalbe
        /// </summary>
        public virtual DbSet<RadnjaNaOsnovuZalbe> RadnjaNaOsnovuZalbe { get; set; }

        /// <summary>
        /// DbSet for table called StatusZalbe
        /// </summary>
        public virtual DbSet<StatusZalbe> StatusZalbe { get; set; }

        /// <summary>
        /// DbSet for table called TipZalbe
        /// </summary>
        public virtual DbSet<TipZalbe> TipZalbe { get; set; }

        /// <summary>
        /// DbSet for table called Zalba
        /// </summary>
        public virtual DbSet<Zalba> Zalba { get; set; }

        /// <summary>
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