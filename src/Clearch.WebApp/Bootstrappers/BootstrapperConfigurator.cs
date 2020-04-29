using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clearch.WebApp.Bootstrappers
{
    public class BootstrapperConfigurator
    {
        private readonly ExceptionBootstrapper exceptionBootstrapper;
        private readonly DependencyBootstrapper dependencyBootstrapper;
        private readonly SwaggerBootstrapper swaggerBootstrapper;
        private readonly MvcBootstrapper mvcBootstrapper;

        public BootstrapperConfigurator(IConfiguration configuration, IWebHostEnvironment environment)
        {
            exceptionBootstrapper = new ExceptionBootstrapper(configuration, environment);
            dependencyBootstrapper = new DependencyBootstrapper(configuration, environment);
            swaggerBootstrapper = new SwaggerBootstrapper(configuration, environment);
            mvcBootstrapper = new MvcBootstrapper(configuration, environment);
        }

        public void Configure(IApplicationBuilder app)
        {
            exceptionBootstrapper.Configure(app);
            dependencyBootstrapper.Configure(app);
            swaggerBootstrapper.Configure(app);
            mvcBootstrapper.Configure(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            exceptionBootstrapper.ConfigureServices(services);
            dependencyBootstrapper.ConfigureServices(services);
            swaggerBootstrapper.ConfigureServices(services);
            mvcBootstrapper.ConfigureServices(services);
        }
    }
}
