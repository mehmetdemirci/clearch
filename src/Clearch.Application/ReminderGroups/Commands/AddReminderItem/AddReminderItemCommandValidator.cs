using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clearch.Application.ReminderGroups.Commands.AddReminderItem
{
    public class AddReminderItemCommandValidator : AbstractValidator<AddReminderItemCommand>
    {
        public AddReminderItemCommandValidator()
        {
            this.RuleFor(x => x.ReminderGroupId).NotEmpty();
            this.RuleFor(x => x.Title).NotEmpty();
        }
    }
}
