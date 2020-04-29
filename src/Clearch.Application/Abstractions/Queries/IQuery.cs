using System;
using MediatR;

namespace Clearch.Application.Abstractions.Queries
{
    public interface IQuery<TResult> : IRequest<IResult<TResult>>
    {
    }
}
