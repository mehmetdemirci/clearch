using Microsoft.EntityFrameworkCore;
using System;

namespace Clearch.Infrastructure.IntegrationTests
{
    public class FakeDbContextFixture : IDisposable
    {
        public FakeDbContextFixture()
        {
            var options = new DbContextOptionsBuilder<FakeDbContext>().UseInMemoryDatabase("FakeTestDb").Options;

            DbContext = new FakeDbContext(options);

            var prop1 = "Fake1";
            var fake = new FakeEntity(prop1);

            DbContext.Set<FakeEntity>().Add(fake);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }

        public FakeDbContext DbContext { get; private set; }
    }
}