using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clearch.Infrastructure.Tests
{
    public abstract class TestServiceProvider : IDisposable
    {
        private readonly IServiceCollection services;
        private IServiceProvider resolver;
        protected TestServiceProvider() => services = new ServiceCollection();

        public void Build()
        {
            resolver = services.BuildServiceProvider();
        }

        public virtual void Dispose()
        {
        }

        protected TestServiceProvider ConfigureServices(Action<IServiceCollection> builder)
        {
            builder(services);

            Build();
            return this;
        }
        protected T GetRequiredService<T>() => resolver.GetRequiredService<T>();

    }
}
