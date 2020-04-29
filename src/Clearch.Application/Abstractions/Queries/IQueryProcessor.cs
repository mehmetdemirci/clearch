using System;
using System.Threading.Tasks;

namespace Clearch.Application.Abstractions.Queries
{
    public interface IQueryProcessor
    {
        Task<IResult<TResult>> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}
