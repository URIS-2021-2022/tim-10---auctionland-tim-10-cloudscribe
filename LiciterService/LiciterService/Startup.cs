using LiciterService.Data;
using LiciterService.Data.KupacData;
using LiciterService.Data.LiciterData;
using LiciterService.Entities;
using LiciterService.ServiceCalls;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiciterService
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
               setup.ReturnHttpNotAcceptable = true //ako to nije zahtev koji ocekujemo vrati status 406, jedini zahtev koji mozemo da obradimo je json
           ).AddXmlDataContractSerializerFormatters();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
          
            services.AddScoped<ILiciterRepository, LiciterRepository>();
            services.AddScoped<IKupacRepository, KupacRepository>();
            services.AddScoped<IZastupnikRepository, ZastupnikRepository>();
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddSingleton<IAdresaService, AdresaService>();
            services.AddSingleton<ILiceService, LiceService>();

            services.AddDbContextPool<LiciterContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LiciterDB")).UseLazyLoadingProxies());

            //services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "LiciterService", 
                    Version = "v1" , 
                    Description= "Pomoću ovog API-ja može da se vrši dodavanje, modifikacija, brisanje i pregled licitera.",
                Contact=new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Irina Kuzmanović",
                    Email ="irinakuzmanovic@uns.ac.rs"
                }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiciterService v1"));
                
            }
            //app.UseSession
            app.UseHttpsRedirection();

            // app.UseRouting();
            //app.UseMvc();
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
