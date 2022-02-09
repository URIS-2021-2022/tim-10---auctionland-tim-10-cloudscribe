using Adresa.Data;
using Adresa.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Adresa
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

            services.AddControllers(setup => {
                setup.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();//podrzavanje xml-a

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//adresaEntity se mapira na adresaDto

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("AdresaOpenApiSpecification", new Microsoft.OpenApi.Models.OpenApiInfo() 
                { 
                    Title = "Adresa API", 
                    Version = "v1", 
                    Description = "Pomoću ovog API-ja može da se vrši dodavanje, modifikacija, brisanje i pregled adresa.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Andrijana Dragićević",
                        Email = "andrijana.dragicevic@uns.ac.rs"
                    }
                });

                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
                setupAction.IncludeXmlComments(xmlCommentsPath);
            });


            //services.AddSingleton<IAdresaRepository, AdresaMockRepository>();
            services.AddScoped<IAdresaRepository, AdresaRepository>();

            services.AddDbContextPool<AdresaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AdresaDB")));

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Došlo je do neočekivane greške. Pokušajte kasnije.");
                    });

                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction => {
                setupAction.SwaggerEndpoint("/swagger/AdresaOpenApiSpecification/swagger.json", "Adresa API");
                setupAction.RoutePrefix = "";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
