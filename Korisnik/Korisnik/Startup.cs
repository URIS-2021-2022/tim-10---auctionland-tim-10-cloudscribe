﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korisnik.Data;
using Korisnik.Helpers;
using System.Reflection;
using System.IO;
using Korisnik.Entities;
using Microsoft.EntityFrameworkCore;
using Korisnik.ServiceCalls;

namespace Korisnik
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
            // Definise da ce kontroleri biti pristupna tacka ovog mikroservisu/projektu.
            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;
            }
            ).AddXmlDataContractSerializerFormatters() //Dodajemo podršku za XML tako da ukoliko klijent to traži u Accept header-u zahteva možemo da serializujemo payload u XML u odgovoru.
            .ConfigureApiBehaviorOptions(setupAction => //Deo koji se odnosi na podržavanje Problem Details for HTTP APIs
             {
            setupAction.InvalidModelStateResponseFactory = context =>
                {
                    //Kreiramo problem details objekat
                    ProblemDetailsFactory problemDetailsFactory = context.HttpContext.RequestServices
                            .GetRequiredService<ProblemDetailsFactory>();

                    //Prosleđujemo trenutni kontekst i ModelState, ovo prevodi validacione greške iz ModelState-a u RFC format
                    ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                            context.HttpContext,
                            context.ModelState);

                    //Ubacujemo dodatne podatke
                    problemDetails.Detail = "Pogledajte polje errors za detalje.";
                    problemDetails.Instance = context.HttpContext.Request.Path;

                    //po defaultu se sve vraća kao status 400 BadRequest, to je ok kada nisu u pitanju validacione greške,
                    //ako jesu hoćemo da koristimo status 422 UnprocessibleEntity
                    //tražimo info koji status kod da koristimo
                    var actionExecutiongContext = context as ActionExecutingContext;

                    //proveravamo da li postoji neka greška u ModelState-u, a takođe proveravamo da li su svi prosleđeni parametri dobro parsirani
                    //ako je sve ok parsirano ali postoje greške u validaciji hoćemo da vratimo status 422
                    if ((context.ModelState.ErrorCount > 0) &&
                            (actionExecutiongContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                    {
                        problemDetails.Type = "https://google.com"; //inače treba da stoji link ka stranici sa detaljima greške
                        problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                        problemDetails.Title = "Došlo je do greške prilikom validacije.";

                        //sve vraćamo kao UnprocessibleEntity objekat
                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    }

                    //ukoliko postoji nešto što nije moglo da se parsira hoćemo da vraćamo status 400 kao i do sada
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Došlo je do greške prilikom parsiranja poslatog sadržaja.";
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
        });

            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//konfiguracija po kojoj cemo mapirati 
            

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



            // Znaci da cim se napravi objekat ExamRegistrationController-a i inject-uje IExamRegistrationRepository, kreira se jedna instanca objekta klase ExamRegistrationRepository
            // Kada se radi sa konkretnom bazom, umesto AddSingleton treba koristiti AddScopped
            services.AddScoped<IKorisnikRepository, KorisnikRepository>();
            services.AddScoped<IUserRepository, UserMockRepository>();
            services.AddScoped<ITipRepository, TipRepository>();
            services.AddScoped<IKomisijaRepository, KomisijaRepository>();
            services.AddScoped<IAuthenticationHelper, AuthenticationHelper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc("KorisnikOpenApiSpecification",
                   new Microsoft.OpenApi.Models.OpenApiInfo()
                   {
                       Title = "Student Exam Registration API",
                       Version = "1",
                        //Često treba da dodamo neke dodatne informacije
                        Description = "Pomoću ovog API-ja može da se vrši prijava ispita, modifikacija prijava ispita kao i pregled kreiranih prijava ispita.",
                       Contact = new Microsoft.OpenApi.Models.OpenApiContact
                       {
                           Name = "Teodora Jovanovic",
                           Email = "teajovanovic92@yahoo.com",
                            # pragma warning disable S1075
                           Url = new Uri($"http://www.ftn.uns.ac.rs/")
                            #pragma warning restore S1075
                       },
                       License = new Microsoft.OpenApi.Models.OpenApiLicense
                       {
                           Name = "FTN licence",
                            #pragma warning disable S1075
                           Url = new Uri("http://www.ftn.uns.ac.rs/")
                            #pragma warning restore S1075
                       },
                            #pragma warning disable S1075
                       TermsOfService = new Uri("http://www.ftn.uns.ac.rs/examRegistrationTermsOfService")
                            #pragma warning restore S1075
                   });

                //Pomocu refleksije dobijamo ime XML fajla sa komentarima (ovako smo ga nazvali u Project -> Properties)
                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";

                //Pravimo putanju do XML fajla sa komentarima
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                //Govorimo swagger-u gde se nalazi dati xml fajl sa komentarima
                setupAction.IncludeXmlComments(xmlCommentsPath);


            });

            string connectionString = Configuration.GetConnectionString("KorisnikDB");
            services.AddDbContextPool<KorisnikContext>(options => options.UseSqlServer(connectionString));
            

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else //Ukoliko se nalazimo u Production modu postavljamo default poruku za greške koje nastaju na servisu
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Došlo je do neočekivane greške. Molimo pokušajte kasnije.");
                    });
                });
            }
            app.UseAuthentication();
           
            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                //Podesavamo endpoint gde Swagger UI moze da pronadje OpenAPI specifikaciju
                setupAction.SwaggerEndpoint("/swagger/KorisnikOpenApiSpecification/swagger.json", "Korisnik API");
                setupAction.RoutePrefix = ""; //Dokumentacija ce sada biti dostupna na root-u (ne mora da se pise /swagger)
            });

            app.UseRouting();

           app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
