using System;
using System.Collections.Generic;
using Domain.DDD;

namespace Clearch.Domain.Entities.ReminderAggregate
{
    public class ReminderGroup : EntityBase<int>, IAggregateRoot
    {
        public ReminderGroup()
        {
            Items = new List<ReminderItem>();
        }

        public void Create(string title, string owner)
        {
            Title = title;
            Owner = owner;
        }
        public string Title { get; protected set; }

        public string Colour { get; protected set; }

        public IList<ReminderItem> Items { get; protected set; }

        public string Owner { get; protected set; }
    }
}
