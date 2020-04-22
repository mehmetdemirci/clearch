using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public interface IBootstrapper
{
    string Name { get; }

    string FullName { get; }

    IConfiguration Configuration { get; }

    IWebHostEnvironment Environment { get; }

    void Configure(IApplicationBuilder app);

    void ConfigureServices(IServiceCollection services);
}