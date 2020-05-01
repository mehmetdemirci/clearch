using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clearch.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Clearch.WebApp
{
    public class Program
    {
        protected Program()
        {

        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    // clear default logging providers
                    logging.ClearProviders();

                    // add built-in providers manually, as needed 
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
