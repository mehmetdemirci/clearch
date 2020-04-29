using System.Collections.Generic;

namespace Clearch.Application.Abstractions
{
    public interface IResult
    {
        IEnumerable<string> Messages { get; }

        IDictionary<string, string[]> ValidationMessages { get; }

        bool Succeeded { get; }
    }

    public interface IResult<T> : IResult
    {
        T Data { get; }
    }
}
