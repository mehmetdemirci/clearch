using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clearch.Application.ReminderGroups.Commands.Create
{
    public class CreateReminderGroupCommandValidator : AbstractValidator<CreateReminderGroupCommand>
    {
        public CreateReminderGroupCommandValidator()
        {
            this.RuleFor(x => x.Title).NotEmpty().MinimumLength(5);
        }
    }
}
