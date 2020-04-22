using System;
using System.Collections.Generic;
using System.Text;

namespace Clearch.Application.Abstractions
{
    public interface IExecutionContextAccessor
    {
        string UserId { get; }
    }
}
