using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clearch.Application.Abstractions;
using Clearch.Application.Abstractions.Commands;
using Clearch.Domain.Entities.ReminderAggregate;
using Clearch.Infrastructure.Data.Context;
using MediatR;

namespace Clearch.Application.TestReminder
{
    internal class CreateReminderGroupCommandHandler : ICommandHandler<CreateReminderGroupCommand>
    {
        private readonly ReminderDbContext reminderDbContext;
        private readonly IExecutionContextAccessor executionContextAccessor;
        public CreateReminderGroupCommandHandler(ReminderDbContext reminderDbContext, IExecutionContextAccessor executionContextAccessor)
        {
            this.reminderDbContext = reminderDbContext;
            this.executionContextAccessor = executionContextAccessor;
        }

        public Task<Unit> Handle(CreateReminderGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new ReminderGroup();

            group.Create("Reminder Group", this.executionContextAccessor.UserId);
            this.reminderDbContext.Set<ReminderGroup>().Add(group);

            this.reminderDbContext.SaveChangesAsync();

            return Unit.Task;
        }
    }
}
