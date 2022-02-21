using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Entities
{
    public class OglasContext: DbContext
    {
        private readonly IConfiguration configuration;
        public OglasContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Oglas> Oglasi { get; set; }
        public DbSet<SluzbeniList> SluzbeniList { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           /*builder.Entity<Oglas>()
          .HasOne(i => i.SluzbeniList)
          .WithOne(c => c.Oglas)
          .IsRequired()
          .OnDelete(DeleteBehavior.NoAction);*/

            builder.Entity<SluzbeniList>().HasData(new
            {
                SluzbeniListId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c397475"),
                Opstina = "Novi Beograd",
                BrojSluzbenogLista = 12,
                DatumIzdavanja = DateTime.Parse("2020-11-15T09:00:00"),

            });

            builder.Entity<SluzbeniList>().HasData(new
            {
                SluzbeniListId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c397411"),
                Opstina = "Novi Sad",
                BrojSluzbenogLista = 5,
                DatumIzdavanja = DateTime.Parse("2021-05-15T09:00:00")
            });

            builder.Entity<Oglas>().HasData(new
            {
                OglasId= Guid.Parse("6a411c13-a195-48f7-8dbd-67596c397444"),
                TekstOglasa= "Javni oglas za davanje u zakup poljoprivrednog zemljišta u državnoj svojini",
                SluzbeniListId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c397475")
            });
            builder.Entity<Oglas>().HasData(new
            {
                OglasId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c397498"),
                TekstOglasa = "Javni oglas za davanje u zakup poljoprivrednog zemljišta u državnoj svojini",
                SluzbeniListId= Guid.Parse("6a411c13-a195-48f7-8dbd-67596c397411")
            });

     

        }
    }
}
