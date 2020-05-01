using System;
using MediatR;

namespace Clearch.Application.Abstractions.Commands
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, IResult<TResult>>
        where TCommand : ICommand<TResult>
    {
    }
}
