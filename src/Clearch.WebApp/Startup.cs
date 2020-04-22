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
        private readonly ExceptionBootstrapper exceptionBootstrapper;
        private readonly DependencyBootstrapper dependencyBootstrapper;
        private readonly MvcBootstrapper mvcBootstrapper;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;

            exceptionBootstrapper = new ExceptionBootstrapper(configuration, environment);
            dependencyBootstrapper = new DependencyBootstrapper(configuration, environment);
            mvcBootstrapper = new MvcBootstrapper(configuration, environment);

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            exceptionBootstrapper.ConfigureServices(services);
            dependencyBootstrapper.ConfigureServices(services);
            mvcBootstrapper.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation($"{env.ApplicationName} [{env.EnvironmentName}] Started");

            exceptionBootstrapper.Configure(app);
            dependencyBootstrapper.Configure(app);
            mvcBootstrapper.Configure(app);
        }
    }
}
