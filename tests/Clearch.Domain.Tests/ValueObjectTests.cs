using Xunit;

namespace Clearch.Domain.UnitTests
{
    public class ValueObjectTests
    {
        [Fact]
        public void Equals_GivenDifferentValues_ShouldReturnFalse()
        {
            var fake1 = new FakeValueObject(1, 2);
            var fake2 = new FakeValueObject(2, 1);

            Assert.False(fake1.Equals(fake2));
        }

        [Fact]
        public void Equals_GivenMatchingValues_ShouldReturnTrue()
        {
            var fake1 = new FakeValueObject(1, 2);
            var fake2 = new FakeValueObject(1, 2);

            Assert.True(fake1.Equals(fake2));
        }
    }
}