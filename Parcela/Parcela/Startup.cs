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
using Parcela.Data.Parcela;
using Parcela.Entities.DeoParcele;
using Parcela.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcela.Data.DeoParcele;
using Parcela.Data.KatastarskaOpstina;
using Parcela.Data.ZasticenaZona;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Parcela
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
            {
                setup.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IParcelaRepository, ParcelaRepository>();
            services.AddScoped<IDeoParceleRepository, DeoParceleRepository>();
            services.AddScoped<IKatastarskaOpstinaRepository, KatastarskaOpstinaRepository>();
            services.AddScoped<IZasticenaZonaRepository, ZasticenaZonaRepository>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            /*
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("ParcelaOpenApiSpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Parcela API",
                    Version = "v1",
                    Description = "Pomoæu ovog API-ja može da se vrši dodavanje, modifikacija, brisanje i pregled parcele.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Kristian Kleèina",
                        Email = "klecina.it43.2015@uns.ac.rs"
                    }
                });

                //var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
                //var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
                //setupAction.IncludeXmlComments(xmlCommentsPath);
            });

            */



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("ParcelaOpenApiSpecification", new OpenApiInfo { 
                    Title = "Parcela", 
                    Version = "v1",
                    Description = "Pomoæu ovog API-ja može da se vrši dodavanje, modifikacija, brisanje i pregled parcele.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Kristian Kleèina",
                        Email = "klecina.it43.2015@uns.ac.rs"
                    }

                    
                });
                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
                c.IncludeXmlComments(xmlCommentsPath);

            });
            
            services.AddDbContextPool<ParcelaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ParcelaDB")).UseLazyLoadingProxies()); //OVO RADI NE DIRAM NIŠTA


            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            
            /*
              services.AddAuthentication(options =>
              {
                  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(options =>
              {
                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])),
                      ValidateAudience = false,
                      ValidateIssuer = false,
                  };
              });
            */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Došlo je do neoèekivane greške. Molimo pokušajte kasnije.");
                    });
                });
            }


            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/ParcelaOpenApiSpecification/swagger.json", "Parcela v1"));

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
