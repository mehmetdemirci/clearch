using Domain.DDD;
using System.Collections.Generic;

namespace Clearch.Infrastructure.IntegrationTests
{
    public class FakeEntity : EntityBase<int>
    {
        protected FakeEntity() : base(0)
        {
        }

        public FakeEntity(string property1)
        {
            Property1 = property1;
        }

        public string Property1 { get; protected set; }

        public ICollection<FakeEntityItem> Items { get; protected set; } = new List<FakeEntityItem>();

        public void AddItem(string itemProperty1)
        {
            var item = new FakeEntityItem(itemProperty1);

            Items.Add(item);
        }
    }
}