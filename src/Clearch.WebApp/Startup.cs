using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Clearch.Infrastructure;
using Clearch.WebApp.Bootstrappers;
using Microsoft.Extensions.Logging;

namespace Clearch.WebApp
{
    public class Startup
    {
        private readonly BootstrapperConfigurator bootstrapperConfigurator;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;

            bootstrapperConfigurator = new BootstrapperConfigurator(configuration, environment);

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            bootstrapperConfigurator.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation($"{env.ApplicationName} [{env.EnvironmentName}] Started");
            bootstrapperConfigurator.Configure(app);
        }
    }
}
