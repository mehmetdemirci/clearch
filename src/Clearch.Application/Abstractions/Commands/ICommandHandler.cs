using System;
using MediatR;

namespace Clearch.Application.Abstractions.Commands
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, IResult>
        where TCommand : ICommand
    {
    }
}
