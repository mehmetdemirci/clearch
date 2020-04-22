using System;
using MediatR;

namespace Clearch.Application.Abstractions.Commands
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}
