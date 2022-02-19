using DocumentService.Data;
using DocumentService.Data.TipDokumenta;
using DocumentService.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(setup =>
            setup.ReturnHttpNotAcceptable = true
            ).AddXmlDataContractSerializerFormatters();
            //ako to nije zahtev koji ocekujemo,d a vrati 404

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IDokumentRepository, DokumentRepository>();
            services.AddScoped<ITipDokumentaRepository, TipDokumentaRepository>();

            services.AddDbContextPool<DokumentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DokumentDB")));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "DocumentService", 
                    Version = "v1",
                    Description= "Pomoću ovog API-ja može da se vrši dodavanje, brisanje, modifikacija i pregled dokumenta.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact {
                        Name ="Mina Lazić",
                        Email = "m.lazic@uns.ac.rs"
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "FTN licence",
                        Url = new Uri("http://www.ftn.ac.rs/")
                    }
                });
            });
        }
        //singleton je za jednu instancu, uvek radimo samo sa njom
        //scoped je za bazu

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocumentService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
