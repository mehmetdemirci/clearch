using Clearch.WebApp.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clearch.WebApp.Bootstrappers
{
    public class ExceptionBootstrapper : BootstrapperBase
    {
        public ExceptionBootstrapper(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
        }

        public override void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            // Do nothing now!
        }
    }
}
