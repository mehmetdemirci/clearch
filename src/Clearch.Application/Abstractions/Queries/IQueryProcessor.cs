using System;
using System.Threading.Tasks;

namespace Clearch.Application.Abstractions.Queries
{
    public interface IQueryProcessor
    {
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}
