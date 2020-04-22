using System;
using MediatR;

namespace Clearch.Application.Abstractions.Queries
{
    public interface IQueryHandler<TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}
