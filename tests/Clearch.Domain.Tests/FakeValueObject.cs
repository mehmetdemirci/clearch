using Domain.DDD;
using System.Collections.Generic;

namespace Clearch.Domain.UnitTests
{
    internal class FakeValueObject : ValueObject
    {
        private FakeValueObject()
        {
        }

        public FakeValueObject(int property1, int property2)
        {
            Property1 = property1;
            Property2 = property2;
        }

        public int Property1 { get; private set; }

        public int Property2 { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Property1;
            yield return Property2;
        }
    }
}