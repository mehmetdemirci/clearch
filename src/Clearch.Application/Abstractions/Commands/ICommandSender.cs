using System;
using System.Threading.Tasks;

namespace Clearch.Application.Abstractions.Commands
{
    public interface ICommandSender
    {
        Task SendAsync(ICommand command);
        Task<TResult> SendAsync<TResult>(ICommand<TResult> command);
    }
}
