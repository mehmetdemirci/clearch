using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clearch.WebApp.Bootstrappers
{
    public abstract class BootstrapperBase : IBootstrapper
    {
        protected BootstrapperBase(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public string Name => GetType().Name;

        public string FullName => GetType().FullName;

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public abstract void Configure(IApplicationBuilder app);

        public abstract void ConfigureServices(IServiceCollection services);
    }
}
