using DocumentService.Entities.TipDokumentaEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Entities
{
    public class DokumentContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DokumentContext(DbContextOptions options): base(options)
        { }

        public DbSet<Dokument> Dokument { get; set; }
        public DbSet<TipDokumentaE> tipDokumenta { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dokument>().HasData(new
            {
                DokumentID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3975a3"),
                ZavodniBroj = "1",
                NazivDokumenta = "Dokument1",
                Datum = DateTime.Parse("2020-12-20T10:00:00"),
                DatumDonosenjaOdluke = DateTime.Parse("2021-10-11T12:00:00"),
                Sablon = true
            });
            builder.Entity<Dokument>().HasData(new
            {
                DokumentID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3972b2"),
                ZavodniBroj = "2",
                NazivDokumenta = "Dokument2",
                Datum = DateTime.Parse("2019-06-05T10:00:00"),
                DatumDonosenjaOdluke = DateTime.Parse("2021-05-30T12:00:00"),
                Sablon = false
            });

            builder.Entity<TipDokumentaE>().HasData(
                new
                {
                    TipDokumentaID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3975b2"),
                    TipDokumenta = "Sablon",
                    StatusDokumenta = "Usvojen"
                }) ;
            builder.Entity<TipDokumentaE>().HasData(
                new
                {
                    TipDokumentaID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3975b1"),
                    TipDokumenta = "Negenericki",
                    StatusDokumenta = "Odbijen"
                });
            builder.Entity<TipDokumentaE>().HasData(
             new
             {
                 TipDokumentaID = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974a2"),
                 TipDokumenta = "Sablon",
                 StatusDokumenta = "Otvoren"
             });

        }
    }
}
