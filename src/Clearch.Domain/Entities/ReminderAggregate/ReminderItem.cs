using System;
using Domain.DDD;

namespace Clearch.Domain.Entities.ReminderAggregate
{
    public class ReminderItem : EntityBase<int>
    {
        public ReminderItem()
        {
        }

        public string Title { get; set; }

        public string Notes { get; set; }

        public bool Done { get; set; }

        public DateTime? ReminderDate { get; set; }

        public Priority Priority { get; set; }

        public int ReminderGroupId { get; set; }
        public ReminderGroup ReminderGroup { get; set; }
    }
}
