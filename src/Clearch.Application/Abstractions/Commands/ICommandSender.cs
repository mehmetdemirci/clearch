using System;
using System.Threading.Tasks;

namespace Clearch.Application.Abstractions.Commands
{
    public interface ICommandSender
    {
        Task<IResult> SendAsync(ICommand command);
        Task<IResult<TResult>> SendAsync<TResult>(ICommand<TResult> command);
    }
}
