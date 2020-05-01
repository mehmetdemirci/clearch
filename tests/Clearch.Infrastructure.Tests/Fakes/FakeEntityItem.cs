using Domain.DDD;

namespace Clearch.Infrastructure.IntegrationTests
{
    public class FakeEntityItem : EntityBase<int>
    {
        protected FakeEntityItem() : base(0)
        {
        }

        public FakeEntityItem(string propertyItem)
        {
            PropertyItem = propertyItem;
        }

        public string PropertyItem { get; protected set; }

        public int FakeEntityId { get; protected set; }

        public FakeEntity FakeEntity { get; protected set; }
    }
}