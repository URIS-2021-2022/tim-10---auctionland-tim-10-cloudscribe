using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ZalbaService
{
    /// <summary>
    /// Entry point of application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Calling CreateHostBuilder 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates an instance of WebHostBuilder with pre-configured defaults
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
