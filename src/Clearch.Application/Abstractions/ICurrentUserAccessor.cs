using System;
using System.Collections.Generic;
using System.Text;

namespace Clearch.Application.Abstractions
{
    public interface ICurrentUserAccessor
    {
        string UserId { get; }
    }
}
