using Clearch.Application.Abstractions;
using Clearch.Application.Abstractions.Commands;
using Clearch.Application.Common;
using Clearch.Domain.Entities.ReminderAggregate;
using Clearch.Infrastructure.Data.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clearch.Application.ReminderGroups.Commands.Create
{
    internal class CreateReminderGroupCommandHandler : ICommandHandler<CreateReminderGroupCommand,int>
    {
        private readonly ReminderDbContext reminderDbContext;
        private readonly IExecutionContextAccessor executionContextAccessor;

        public CreateReminderGroupCommandHandler(ReminderDbContext reminderDbContext, IExecutionContextAccessor executionContextAccessor)
        {
            this.reminderDbContext = reminderDbContext;
            this.executionContextAccessor = executionContextAccessor;
        }

        public Task<IResult<int>> Handle(CreateReminderGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new ReminderGroup();
            group.Create(request.Title, executionContextAccessor.UserId);

            reminderDbContext.Set<ReminderGroup>().Add(group);
            reminderDbContext.SaveChangesAsync();

            return Result<int>.SuccessAsync(group.Id);
        }
    }
}