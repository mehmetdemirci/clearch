using System;
using System.Collections.Generic;
using System.Text;

namespace Clearch.Application.Abstractions.Queries
{
    public interface IListQuery<TResult>: IQuery<IEnumerable<TResult>>
    {
    }
}
