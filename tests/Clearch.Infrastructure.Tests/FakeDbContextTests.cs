using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clearch.Infrastructure.IntegrationTests
{
    public class FakeDbContextTests : IClassFixture<FakeDbContextFixture>
    {
        private readonly FakeDbContext context;

        public FakeDbContextTests(FakeDbContextFixture fixture)
        {
            context = fixture.DbContext;
        }

        [Fact]
        public async Task SaveChangesAsync_GivenExistingEntity_ShouldAddItem()
        {
            var fake = await context.Set<FakeEntity>().FindAsync(1);

            var itemProp1 = "Item1";
            fake.AddItem(itemProp1);
            context.Update(fake);
            await context.SaveChangesAsync();

            fake.Id.Should().Be(1);
            fake.Items.First().Id.Should().Be(1);
            fake.Items.First().Property1.Should().Be(itemProp1);
        }

        [Fact]
        public async Task SaveChangesAsync_GivenNewEntity_ShouldSetProperties()
        {
            var prop1 = "Fake2";
            var fake = new FakeEntity(prop1);

            context.Set<FakeEntity>().Add(fake);
            await context.SaveChangesAsync();

            fake.Id.Should().Be(2);
            fake.Property1.Should().Be(prop1);
        }
    }
}