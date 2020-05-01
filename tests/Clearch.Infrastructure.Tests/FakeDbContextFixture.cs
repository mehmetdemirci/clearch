using Clearch.Infrastructure.IntegrationTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Clearch.Infrastructure.Tests
{
    public class FakeDbContextFixture : TestServiceProvider
    {
        public FakeDbContextFixture()
        {
            this.ConfigureServices(x => x.AddDbContext<FakeDbContext>(x => x.UseInMemoryDatabase("FakeTestDb")));
            
            DbContext = this.GetRequiredService<FakeDbContext>();

            var prop1 = "Fake1";
            var fake = new FakeEntity(prop1);

            DbContext.Set<FakeEntity>().Add(fake);
            DbContext.SaveChanges();
        }

        public override void Dispose()
        {
            base.Dispose();
            DbContext?.Dispose();
        }

        public FakeDbContext DbContext { get; private set; }
    }
}