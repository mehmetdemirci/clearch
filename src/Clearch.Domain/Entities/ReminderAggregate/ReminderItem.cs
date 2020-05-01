using System;
using Domain.DDD;

namespace Clearch.Domain.Entities.ReminderAggregate
{
    public class ReminderItem : EntityBase<int>
    {
        public string Title { get; protected set; }

        public string Notes { get; protected set; }

        public bool Done { get; protected set; }

        public DateTime? ReminderDate { get; protected set; }

        public Priority Priority { get; protected set; }

        public int ReminderGroupId { get; protected set; }
        public ReminderGroup ReminderGroup { get; protected set; }

        public void Create(string title, string notes, Priority priority)
        {
            Title = title;
            Notes = notes;
            Priority = priority;
        }
    }
}
