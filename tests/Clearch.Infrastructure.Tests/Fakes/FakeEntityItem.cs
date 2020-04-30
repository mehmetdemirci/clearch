using Domain.DDD;

namespace Clearch.Infrastructure.IntegrationTests
{
    public class FakeEntityItem : EntityBase<int>
    {
        protected FakeEntityItem() : base(0)
        {
        }

        public FakeEntityItem(string property1)
        {
            Property1 = property1;
        }

        public string Property1 { get; protected set; }

        public int FakeEntityId { get; protected set; }

        public FakeEntity FakeEntity { get; protected set; }
    }
}