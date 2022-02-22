using DocumentService.Data;
using DocumentService.Data.TipDokumenta;
using DocumentService.Entities;
using DocumentService.ServiceCalls;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Reflection;
using System.Text;


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
            {
                setup.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
            //ako to nije zahtev koji ocekujemo,d a vrati 404

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IDokumentRepository, DokumentRepository>();
            services.AddScoped<ITipDokumentaRepository, TipDokumentaRepository>();
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddSingleton<IKorisnikService, KorisnikService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("DocumentOpenApiSpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "DocumentService",
                    Version = "v1",
                    Description = "Pomoću ovog API-ja može da se vrši dodavanje, brisanje, modifikacija i pregled dokumenta.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Mina Lazić",
                        Email = "m.lazic@uns.ac.rs"
                    }
                });

                //set the comments path for the Swagger JSON and UI
                 var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
                c.IncludeXmlComments(xmlCommentsPath);
            });

            services.AddDbContextPool<DokumentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DokumentDB")));

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


        }
        //singleton je za jednu instancu, uvek radimo samo sa njom
        //scoped je za bazu

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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint
                ("/swagger/v1/swagger.json",
                "DocumentService v1");
                c.RoutePrefix = string.Empty;
            });


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
    

