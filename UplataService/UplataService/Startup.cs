using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using UplataService.Data;
using UplataService.Entities;
using UplataService.ServiceCalls;
using UplataService.Middlewares;

namespace UplataService
{
    /// <summary>
    /// Class used to configure project and its dependencies
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor that acceps Configuration object.
        /// </summary>
        /// <param name="configuration">Configuration object.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration object which will be injected via constructor
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Method which will be called by the runtime and it's used to add services to the container
        /// </summary>
        /// <param name="services">Services object</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<UplataDbContext>();

            /*
             * Singleton objects will be the same for all requests,
             * Scoped objects will be the same during a request,
             * Transient objects will be different every time
             */
            services.AddScoped<IKursRepository, KursRepository>();
            services.AddScoped<IUplataRepository, UplataRepository>();
            services.AddScoped<IBankaUplataRepository, BankaUplataRepository>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<ILiceService, LiceService>();

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

            // Defining the generation of swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Uplata service",
                    Version = "1",
                    Description = "Service for handling Uplatas.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Dragana Zabaljac",
                        Email = "d.zabaljac@gmail.com"
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "FTN licence",
                        Url = new Uri("http://www.ftn.uns.ac.rs/")
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        ///  Methoc which will be called by the runtime and it configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">ApplicationBuilder object.</param>
        /// <param name="env">WebHostEnvironment object.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    // Tells swaggerUI where to locate the swagger.json file
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    // Allows swagger to be accessible from the base route
                    options.RoutePrefix = string.Empty;
                });
            }
            // Added custom middleware that handles HTTP requests and responses
            app.UseMiddleware<HttpMiddleware>();

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
