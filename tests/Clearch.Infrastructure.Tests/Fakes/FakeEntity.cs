using Domain.DDD;
using System.Collections.Generic;

namespace Clearch.Infrastructure.IntegrationTests
{
    public class FakeEntity : EntityBase<int>
    {
        protected FakeEntity() : base(0)
        {
        }

        public FakeEntity(string propertyEntity)
        {
            PropertyEntity = propertyEntity;
        }

        public string PropertyEntity { get; protected set; }

        public ICollection<FakeEntityItem> Items { get; protected set; } = new List<FakeEntityItem>();

        public void AddItem(string propertyItem)
        {
            var item = new FakeEntityItem(propertyItem);

            Items.Add(item);
        }
    }
}