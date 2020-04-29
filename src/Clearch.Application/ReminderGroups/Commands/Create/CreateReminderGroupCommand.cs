using Clearch.Application.Abstractions;
using Clearch.Application.Abstractions.Commands;

namespace Clearch.Application.ReminderGroups.Commands.Create
{
    public class CreateReminderGroupCommand : CommandBase<int>
    {
        public CreateReminderGroupCommand()
        {
        }

        public string Title { get; set; }
    }
}