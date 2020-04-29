using Clearch.Application.Abstractions.Commands;
using Clearch.Domain.Entities.ReminderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clearch.Application.ReminderGroups.Commands.AddReminderItem
{
    public class AddReminderItemCommand : CommandBase
    {
        public int ReminderGroupId { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public Priority Priority { get; set; }
    }
}
