using System;
using System.Collections.Generic;
using Domain.DDD;

namespace Clearch.Domain.Entities.ReminderAggregate
{
    public class ReminderGroup : EntityBase<int>, IAggregateRoot
    {
        public string Title { get; protected set; }

        public string Colour { get; protected set; }

        public IList<ReminderItem> Items { get; protected set; } = new List<ReminderItem>();

        public string Owner { get; protected set; }

        public void Create(string title, string owner)
        {
            Title = title;
            Owner = owner;
        }

        public void AddItem(string title, string notes, Priority priority)
        {
            var item = new ReminderItem();
            item.Create(title, notes, priority);
            Items.Add(item);
        }
    }
}
