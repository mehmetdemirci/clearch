using Clearch.Application.Abstractions;
using Clearch.Application.Abstractions.Commands;
using Clearch.Application.Common;
using Clearch.Application.Common.Exceptions;
using Clearch.Domain.Entities.ReminderAggregate;
using Clearch.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clearch.Application.ReminderGroups.Commands.AddReminderItem
{
    public class AddReminderItemCommandHandler : ICommandHandler<AddReminderItemCommand>
    {
        private readonly ReminderDbContext reminderDbContext;

        public AddReminderItemCommandHandler(ReminderDbContext reminderDbContext)
        {
            this.reminderDbContext = reminderDbContext;
        }

        public async Task<IResult> Handle(AddReminderItemCommand request, CancellationToken cancellationToken)
        {
            var reminderGroup = await this.reminderDbContext.Set<ReminderGroup>().FindAsync(request.ReminderGroupId);
            if (reminderGroup == null)
            {
                throw new NotFoundException(nameof(ReminderGroup), request.ReminderGroupId);
            }

            reminderGroup.AddItem(request.Title, request.Notes, request.Priority);

            this.reminderDbContext.Update(reminderGroup);
            await this.reminderDbContext.SaveChangesAsync();

            return Result.Success();
        }
    }
}
