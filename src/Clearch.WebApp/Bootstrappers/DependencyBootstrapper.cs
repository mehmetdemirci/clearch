using System;
using Clearch.Application;
using Clearch.Application.Abstractions;
using Clearch.Infrastructure;
using Clearch.WebApp.Accessors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clearch.WebApp.Bootstrappers
{
    public class DependencyBootstrapper : BootstrapperBase
    {
        public DependencyBootstrapper(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
        }

        public override void Configure(IApplicationBuilder app)
        {
            // Do nothing now!
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();
            services.AddApplication(Configuration);
            services.AddInfrastructure(Configuration);
        }
    }
}
